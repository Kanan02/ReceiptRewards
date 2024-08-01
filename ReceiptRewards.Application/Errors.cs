using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application
{
    public class Errors
    {
        public static readonly ApiError IncorrectUser = new("Errors.incorrectUser", "User is not found");
        public static readonly ApiError UnverifiedUser = new("Errors.unverifiedUser", "User is unverified");
        public static readonly ApiError WrongPassword = new("Errors.wrongPassword", "Password is wrong");
        public static readonly ApiError EmptyMsisdn = new ("Errors.emptymsisdn", "Msisdn field is empty");
        public static readonly ApiError NullPhoto = new ("Errors.nullPhoto", "Photo is null");
        public static readonly ApiError UserNotFound = new ("Errors.userNotFound", "User is not found");
        public static readonly ApiError OtpError = new ("Errors.OtpError", "Otp error is occured");
        public static readonly ApiError WrongCode = new ("Errors.wrongCode", "Code  is wrong");
        public static readonly ApiError NotExist = new ("Errors.notExist", "Not found");
        
    }
}
