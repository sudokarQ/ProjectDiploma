namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public int DiscountPercent { get; set; }

        public List<ShopUser> ShopUsers { get; set; }
    }
}
