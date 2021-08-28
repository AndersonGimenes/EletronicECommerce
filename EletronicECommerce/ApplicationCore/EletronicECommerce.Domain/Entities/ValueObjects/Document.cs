using EletronicECommerce.Domain.Entities.Enums;

namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class Document
    {
        public Document(string number, DocumentType documentType)
        {
            Number = number;
            DocumentType = documentType;
        }
        
        public string Number { get; }
        public DocumentType DocumentType { get; }
        
    }
}