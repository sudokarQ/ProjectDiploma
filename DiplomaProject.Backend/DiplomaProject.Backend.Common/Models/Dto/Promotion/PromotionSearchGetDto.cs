namespace DiplomaProject.Backend.Common.Models.Dto.Promotion
{
    public class PromotionSearchGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ServiceId { get; set; }
    }
}
