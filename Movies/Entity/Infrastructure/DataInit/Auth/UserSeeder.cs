using Entity.Domain.Models.Implements.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Infrastructure.DataInit.Auth
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var date = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            builder.HasData(
                new User
                {
                    Id = 1,
                    Email = "example@gmail.com",
                    Password = "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", //Admin123
                    Name = "Example User",
                    CreatedAt = date,
                    Active = true,
                    IsDeleted = false
                }
            );
        }
    }
}
