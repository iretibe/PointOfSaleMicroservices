namespace PointOfSaleMicroservices.Modules.Customers.Core.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public string Address { get; private set; }
        public string Nationality { get; private set; }
        public string Identity { get; private set; }
        public decimal Debit { get; private set; }
        public decimal Credit { get; private set; }
        public decimal CreditLimit { get; private set; }
        public bool IsActive { get; private set; }
        public string PhotoImage { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime? VerifiedAt { get; private set; }

        private Customer()
        {

        }

        public Customer(Guid id, string email, DateTime createdAt)
        {
            Id = id;
            Email = email;
            CreatedAt = createdAt;
        }
    }
}
