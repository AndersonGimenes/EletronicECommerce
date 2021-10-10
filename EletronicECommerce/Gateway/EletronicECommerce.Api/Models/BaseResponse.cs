namespace EletronicECommerce.Api.Models
{
    public class GenericResponse
    {
        public GenericResponse(bool result, string errorMessage, object objectResult, string objectName)
        {
            Result = result? "Success" : "Error" ;
            ErrorMessage =  errorMessage;
            ObjectResult = objectResult;
            ObjectName = objectName;
        }

        public string ObjectName { get; }
        public string Result { get; }
        public string ErrorMessage { get; }
        public object ObjectResult { get; }         
    }
}