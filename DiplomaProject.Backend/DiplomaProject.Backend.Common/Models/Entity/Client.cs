namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
        public int BonusCount { get; set; }
        
        public Company Company { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
