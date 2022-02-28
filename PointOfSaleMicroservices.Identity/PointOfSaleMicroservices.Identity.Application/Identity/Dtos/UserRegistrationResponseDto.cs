namespace PointOfSaleMicroservices.Identity.Application.Identity.Dtos
{
    /*
    A record is a reference type and follows value-based equality semantics. 
    You can define a record struct to create a record that is a value type. 
    To enforce value semantics, the compiler generates several methods for your record type 
    (both for record class types and record struct types 
    
    This is the stand out reason why you would want to use C# Records they are ideal in 
    situations where you are going to need to compare objects and maybe you want to ensure 
    the property values of an object cannot be changed during the execution of other processes
    */
    public record UserRegistrationResponseDto(string Id, string UserName, 
        string FirstName, string LastName);
}
