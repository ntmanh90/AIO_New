using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.KhachSan
{
    public class KhachSanRequestValidator : AbstractValidator<CauHinhKhachSanRequiter>
    {

        public KhachSanRequestValidator()
        {
            RuleFor(a => a.TenKhachSan).NotEmpty().WithMessage("Tên khách sạn không được để trống").MaximumLength(20).WithMessage("Không quá 20 ký tự");   
        }

    }
}
