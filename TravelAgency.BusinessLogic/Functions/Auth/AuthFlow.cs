using TravelAgency.BusinessLogic.Core.Auth;
using TravelAgency.BusinessLogic.Interface;
using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponceAction LoginActionFlow(UserAuthAction auth)
        {
            var user = ValidateLoginExecution(auth);

            if (user == null)
            {
                return new ResponceAction
                {
                    IsSuccess = false,
                    Message = "Invalid username or password."
                };
            }

            var token = GenerateUserToken(user);

            return new ResponceAction
            {
                IsSuccess = true,
                Message = token,
                Id = user.Id
            };
        }

        public ResponceMsg SendEmailConfirmationCode(string email)
            => SendEmailConfirmationCode(email);

        public ResponceMsg SendResetPasswordCode(string email)
            => SendResetPasswordCode(email);

        public ResponceMsg ConfirmEmail(ConfirmEmailDto dto)
            => ExecuteConfirmEmail(dto.Email, dto.Code);

        public ResponceMsg ResetPassword(ResetPasswordDto dto)
            => ExecuteResetPassword(dto.Email, dto.Code, dto.NewPassword);
    }
}