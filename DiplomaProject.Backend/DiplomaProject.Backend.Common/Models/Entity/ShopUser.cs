namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class ShopUser
    {
        public Guid ShopId { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
        public Shop Shop { get; set; }
    }
}
