using EletronicECommerce.Domain.Entities.Enums;

namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Document
    {
        public string Number { get; private set; }
        public DocumentType DocumentType { get; private set; }
        
    }
}