namespace EletronicECommerce.Domain.Entities.Shared
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string PassWord { get; set; }             
    }
}