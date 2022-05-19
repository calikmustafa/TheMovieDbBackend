using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.DTO
{
    public class UserForRegisterDTO
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string UserSurname { get; set; } = null!;
        [Required]
        [EmailAddress(ErrorMessage = "Girilen Adres geçerli bir mail değil")]
        public string UserEmail { get; set; } = null!;
        public string? UserPhone
        {
            get; set;
        }
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Parola en az 6 haneli olmalıdır.")]
        public string? Password { get; set; }
    }
}
