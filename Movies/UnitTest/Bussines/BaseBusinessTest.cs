using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using MapsterMapper;
using Moq;
using UnitTest.Dto;

namespace UnitTest.Bussines
{
    public class BaseBusinessTest
    {
        private readonly Mock<IDataGeneric<FakeEntity>> _dataMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BaseBusiness<FakeEntity, FakeSelectDto, FakeCreateDto, FakeUpdateDto> _service;

        public BaseBusinessTest()
        {
            _dataMock = new Mock<IDataGeneric<FakeEntity>>();
            _mapperMock = new Mock<IMapper>();
            _service = new BaseBusiness<FakeEntity, FakeSelectDto, FakeCreateDto, FakeUpdateDto>(_mapperMock.Object, _dataMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsMappedDtos()
        {
            var entities = new List<FakeEntity> { new() { Id = 1, Name = "A" } };
            var mapped = new List<FakeSelectDto> { new() { Name = "A" } };

            _dataMock.Setup(d => d.GetAllAsync()).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<IEnumerable<FakeSelectDto>>(entities)).Returns(mapped);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            var list = result.ToList();
            Assert.Single(list);
            Assert.Equal("A", list[0].Name);
        }

        [Fact]
        public async Task GetAllAsync_WithStrategy_ReturnsMappedDtos()
        {
            var entities = new List<FakeEntity> { new() { Id = 1, Name = "Deleted" } };
            var mapped = new List<FakeSelectDto> { new() { Name = "Deleted" } };

            _dataMock.Setup(d => d.GetDeletes()).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<IEnumerable<FakeSelectDto>>(entities)).Returns(mapped);

            var result = await _service.GetAllAsync(GetAllType.GetAllDeletes);

            Assert.NotNull(result);
            var list = result.ToList();
            Assert.Single(list);
            Assert.Equal("Deleted", list[0].Name);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsMappedDto()
        {
            var entity = new FakeEntity { Id = 1, Name = "A" };
            var mapped = new FakeSelectDto { Name = "A" };

            _dataMock.Setup(d => d.GetByIdAsync(1)).ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map<FakeSelectDto>(entity)).Returns(mapped);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("A", result!.Name);
        }

        [Fact]
        public async Task CreateAsync_MapsEntityAndReturnsDto()
        {
            var dto = new FakeCreateDto { Name = "New" };
            var entity = new FakeEntity { Id = 1, Name = "New" };

            _mapperMock.Setup(m => m.Map<FakeEntity>(dto)).Returns(entity);
            _dataMock.Setup(d => d.CreateAsync(entity)).ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map<FakeCreateDto>(It.IsAny<FakeEntity>())).Returns(dto);

            var result = await _service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("New", result.Name);
        }

        [Fact]
        public async Task UpdateAsync_MapsEntityAndReturnsRepositoryResult()
        {
            var dto = new FakeUpdateDto { Id = 1, Name = "Updated" };
            var entity = new FakeEntity { Id = 1, Name = "Updated" };

            _mapperMock.Setup(m => m.Map<FakeEntity>(dto)).Returns(entity);
            _dataMock.Setup(d => d.UpdateAsync(entity)).ReturnsAsync(true);

            var result = await _service.UpdateAsync(dto);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsRepositoryResult()
        {
            _dataMock.Setup(d => d.DeleteAsync(1)).ReturnsAsync(true);

            var result = await _service.DeleteAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_WithStrategy_UsesRepositoryDeleteLogic()
        {
            _dataMock.Setup(d => d.DeleteLogicAsync(2)).ReturnsAsync(true);

            var result = await _service.DeleteAsync(2, DeleteType.Logical);

            Assert.True(result);
        }

        [Fact]
        public async Task RestoreLogical_ReturnsRepositoryResult()
        {
            _dataMock.Setup(d => d.RestoreAsync(3)).ReturnsAsync(true);

            var result = await _service.RestoreLogical(3);

            Assert.True(result);
        }
    }
}
