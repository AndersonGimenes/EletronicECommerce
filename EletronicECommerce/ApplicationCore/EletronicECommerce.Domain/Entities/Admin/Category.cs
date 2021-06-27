namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Category : EntityBase
    {
        public string Name { get; private set; }  

        public Category(string name)
        {
            Name = name;
        }       
    }
}