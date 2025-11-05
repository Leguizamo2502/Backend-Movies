using Entity.Domain.Models.Base;

namespace UnitTest.Dto
{
    public class FakeEntity : BaseModel
    {
        public string? Name { get; set; }
    }

    public class FakeCreateDto
    {
        public string? Name { get; set; }
    }
    public class FakeUpdate
    {
        public string? Name { get; set; }
    }

    public class FakeSelectDto
    {
        public string? Name { get; set; }
    }
}
