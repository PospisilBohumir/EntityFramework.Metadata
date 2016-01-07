using System.Data.Entity.Spatial;

namespace EntityFramework.Metadata.Test.CodeFirst.Domain.ComplexTypes
{
    public class Address
    {
        public string Country { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }

#if !NET40
        public DbGeography Location { get; set; }
        public DbGeometry Shape { get; set; }
#endif
    }
}