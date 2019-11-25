namespace RecipieAPI.Ref
{
    public class ResponseCodes
    {
        public enum ResponseTable
        {
            Success = 200,
            Failure = 300,
            ConnectionFailed = 301,
            IncorrectDataSchema = 302,
            AuthenticationFailure = 303,
            WrongRoute = 304,
            BadInput = 305
        }
    }
}
