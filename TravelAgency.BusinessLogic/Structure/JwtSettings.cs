namespace TravelAgency.BusinessLogic.Structure
{
    public static class JwtSettings
    {
        public const string Issuer = "TravelAgencyApi";
        public const string Audience = "TravelAgencyClients";
        public const string SecretKey = "something_secret_no_one_should_see_200000!!!!";
        public const int ExpireMinutes = 60;
    }
}
