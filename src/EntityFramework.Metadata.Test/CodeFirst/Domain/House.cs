using EntityFramework.Metadata.Test.CodeFirst.Domain.ComplexTypes;

namespace EntityFramework.Metadata.Test.CodeFirst.Domain
{
    public class House
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // complex type must be the last member
        public Address Address { get; set; }
    }
}
