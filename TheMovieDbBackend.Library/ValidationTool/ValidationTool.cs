using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Library.ValidationTool
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, dynamic entity)
        {
            var context = new ValidationContext<object>(entity);//product için doğrulama yapıcam diyoruz.

            var result = validator.Validate(context);//yazdığımız validate ile bağdaştırdık
            if (!result.IsValid)//sonuç geçerli değil ise
            {
                throw new ValidationException(result.Errors);//hata fırlat
            }
        }
    }
}
