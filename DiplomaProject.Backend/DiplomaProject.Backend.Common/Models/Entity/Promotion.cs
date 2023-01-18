namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Promotion
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double DiscountPercent { get; set; }
    }
}
