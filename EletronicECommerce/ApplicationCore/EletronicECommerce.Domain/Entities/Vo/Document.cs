using EletronicECommerce.Domain.Entities.Enums;

namespace EletronicECommerce.Domain.Entities.Vo
{
    public class Document
    {
        public string Number { get; private set; }
        public DocumentType DocumentType { get; private set; }

        public Document(string number, DocumentType documentType)
        {
            Number = number;
            DocumentType = documentType;
        }
    }
}