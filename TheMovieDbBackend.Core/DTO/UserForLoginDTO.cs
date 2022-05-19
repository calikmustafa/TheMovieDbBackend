using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.DTO
{
    public class UserForLoginDTO
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Parola en az 6 haneli olmalıdır.")]
        public string Password { get; set; } = null!;
    }
}
    