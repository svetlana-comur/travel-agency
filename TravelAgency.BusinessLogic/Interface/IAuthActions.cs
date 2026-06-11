using TravelAgency.Domains.Models.Base;
using TravelAgency.Domains.Models.User;

namespace TravelAgency.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        ResponceAction LoginActionFlow(UserAuthAction auth);

        ResponceMsg SendEmailConfirmationCode(string email);
        ResponceMsg ConfirmEmail(ConfirmEmailDto dto);

        ResponceMsg SendResetPasswordCode(string email);
        ResponceMsg ResetPassword(ResetPasswordDto dto);
    }
}