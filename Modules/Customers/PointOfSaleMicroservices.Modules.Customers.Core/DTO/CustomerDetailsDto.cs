namespace PointOfSaleMicroservices.Modules.Customers.Core.DTO
{
    internal class CustomerDetailsDto : CustomerDto
    {
        public string Address { get; set; }
        public IdentityDto Identity { get; set; }
        public string Notes { get; set; }
    }
}
