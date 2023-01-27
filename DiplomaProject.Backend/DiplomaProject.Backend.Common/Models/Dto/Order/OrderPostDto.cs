namespace DiplomaProject.Backend.Common.Models.Dto.Order
{
    public class OrderPostDto
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool OnDelivery { get; set; }
    }
}
