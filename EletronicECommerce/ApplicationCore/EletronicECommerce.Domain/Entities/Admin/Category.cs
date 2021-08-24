namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Category : EntityBase
    {
        public Category(string name)
        {
            Name = name;
        }       

        public string Name { get; private set; }          
    }
}