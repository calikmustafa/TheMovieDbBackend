using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; } = null!;
        public string? UserSurname { get; set; } = null!;
        public string? UserEmail { get; set; } = null!;
        public string? UserPhone { get; set; } = null!;
        public byte[] UserPasswordHash { get; set; } = null!;
        public byte[] UserPasswordSalt { get; set; } = null!;
        public DateTime? UserRd { get; set; }
        public bool? UserCancel { get; set; }
    }
}
