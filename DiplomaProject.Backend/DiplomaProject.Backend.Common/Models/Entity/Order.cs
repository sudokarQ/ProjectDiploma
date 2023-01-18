namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }

        public Client Client { get; set; }
        public Service Service { get; set; }
    }
}
