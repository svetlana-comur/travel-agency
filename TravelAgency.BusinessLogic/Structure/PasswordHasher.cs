using System.Security.Cryptography;
using System.Text;

namespace TravelAgency.BusinessLogic.Structure
{
    public static class PasswordHasher
    {
        // Fixed suffix appended to every password before hashing.
        // Even if the DB is leaked, public MD5 hashes for trivial passwords
        // (e.g. "qwerty" -> d8578edf8458ce06fbc5bb76a58c5ca4) won't match,
        // because the actual MD5 input is "qwerty" + suffix.
        private const string PasswordSuffix = "tw_curs2026";

        public static string Hash(string password)
        {
            var input = password + PasswordSuffix;
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = MD5.HashData(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
