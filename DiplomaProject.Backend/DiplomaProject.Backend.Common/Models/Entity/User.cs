namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<ShopUser> ShopUsers { get; set; }
    }
}
