using System;
using EntityFramework.Metadata.Test.CodeFirst.Domain.ComplexTypes;

namespace EntityFramework.Metadata.Test.CodeFirst.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Contact FirstContact { get; set; }
        public Contact SecondContact { get; set; }
        public Address BusinessAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public DateTime BusinessStartDate { get; set; }
    }
}
