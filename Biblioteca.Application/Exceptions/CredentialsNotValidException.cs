namespace Biblioteca.Application.Exceptions;

public class CredentialsNotValidException : Exception
{
 
    public CredentialsNotValidException(string message) : base(message){}
    
}