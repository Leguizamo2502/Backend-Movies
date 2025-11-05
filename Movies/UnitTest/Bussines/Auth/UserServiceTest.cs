namespace UnitTest.Bussines.Auth
{
    public class UserServiceTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IDataGeneric<User>> _dataMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _service;

        public UserServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _dataMock = new Mock<IDataGeneric<User>>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _service = new UserService(_mapperMock.Object, _dataMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_WhenEmailAlreadyExists_ThrowsValidationException()
        {
            var dto = new UserCreateDto
            {
                Email = "existing@example.com",
                Name = "Existing",
                Password = "Password1"
            };

            _userRepositoryMock.Setup(r => r.ExistsByEmailAsync(dto.Email)).ReturnsAsync(true);

            await Assert.ThrowsAsync<ValidationException>(() => _service.CreateAsync(dto));
        }

        [Fact]
        public async Task CreateAsync_WhenPasswordInvalid_ThrowsBusinessException()
        {
            var dto = new UserCreateDto
            {
                Email = "new@example.com",
                Name = "New User",
                Password = "short"
            };

            _userRepositoryMock.Setup(r => r.ExistsByEmailAsync(dto.Email)).ReturnsAsync(false);

            await Assert.ThrowsAsync<BusinessException>(() => _service.CreateAsync(dto));
        }

        [Fact]
        public async Task CreateAsync_WithValidInput_EncryptsPasswordAndReturnsDto()
        {
            var dto = new UserCreateDto
            {
                Email = "valid@example.com",
                Name = "Valid User",
                Password = "Password1"
            };
            var encryptedPassword = EncriptePassword.EncripteSHA256("Password1");
            var entity = new User
            {
                Id = 1,
                Email = dto.Email,
                Name = dto.Name,
                Password = encryptedPassword
            };

            _userRepositoryMock.Setup(r => r.ExistsByEmailAsync(dto.Email)).ReturnsAsync(false);
            _mapperMock
                .Setup(m => m.Map<User>(It.Is<UserCreateDto>(d => d.Email == dto.Email && d.Password == encryptedPassword && d.Name == dto.Name)))
                .Returns(entity);
            _userRepositoryMock.Setup(r => r.CreateAsync(entity)).ReturnsAsync(entity);
            _mapperMock
                .Setup(m => m.Map<UserCreateDto>(entity))
                .Returns(new UserCreateDto { Email = entity.Email, Name = entity.Name, Password = entity.Password });

            var result = await _service.CreateAsync(dto);

            Assert.Equal(dto.Email, result.Email);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(encryptedPassword, result.Password);
            _userRepositoryMock.Verify(r => r.CreateAsync(It.Is<User>(u => u.Password == encryptedPassword)), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_WhenEmailAlreadyExists_ThrowsValidationException()
        {
            var dto = new UserUpdateDto
            {
                Id = 5,
                Email = "existing@example.com",
                Name = "Existing",
                Password = "Password1"
            };

            _userRepositoryMock.Setup(r => r.ExistsByEmailAsync(dto.Email)).ReturnsAsync(true);

            await Assert.ThrowsAsync<ValidationException>(() => _service.UpdateAsync(dto));
        }

        [Fact]
        public async Task UpdateAsync_WhenPasswordInvalid_ThrowsBusinessException()
        {
            var dto = new UserUpdateDto
            {
                Id = 6,
                Email = "new@example.com",
                Name = "New",
                Password = "short"
            };

            _userRepositoryMock.Setup(r => r.ExistsByEmailAsync(dto.Email)).ReturnsAsync(false);

            await Assert.ThrowsAsync<BusinessException>(() => _service.UpdateAsync(dto));
        }

        [Fact]
        public async Task UpdateAsync_WithValidInput_EncryptsPasswordAndReturnsRepositoryResult()
        {
            var dto = new UserUpdateDto
            {
                Id = 10,
                Email = "valid@example.com",
                Name = "Valid User",
                Password = "Password1"
            };
            var encryptedPassword = EncriptePassword.EncripteSHA256("Password1");
            var entity = new User
            {
                Id = dto.Id,
                Email = dto.Email,
                Name = dto.Name,
                Password = encryptedPassword
            };

            _userRepositoryMock.Setup(r => r.ExistsByEmailAsync(dto.Email)).ReturnsAsync(false);
            _mapperMock
                .Setup(m => m.Map<User>(It.Is<UserUpdateDto>(d => d.Id == dto.Id && d.Email == dto.Email && d.Password == encryptedPassword)))
                .Returns(entity);
            _userRepositoryMock.Setup(r => r.UpdateAsync(entity)).ReturnsAsync(true);

            var result = await _service.UpdateAsync(dto);

            Assert.True(result);
            _userRepositoryMock.Verify(r => r.UpdateAsync(It.Is<User>(u => u.Password == encryptedPassword)), Times.Once);
        }
    }
}
