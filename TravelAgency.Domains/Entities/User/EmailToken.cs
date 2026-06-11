using System;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domains.Entities.User
{
    public class EmailToken
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public string Type { get; set; } // confirm / reset

        public DateTime ExpireAt { get; set; }

        public bool Used { get; set; }
    }
}