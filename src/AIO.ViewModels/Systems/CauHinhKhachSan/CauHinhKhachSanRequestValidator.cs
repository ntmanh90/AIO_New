using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.CauHinhKhachSan
{
    public class CauHinhKhachSanRequestValidator : AbstractValidator<CauHinhKhachSanRequest>
    {

        public CauHinhKhachSanRequestValidator()
        {
            RuleFor(a => a.EmailNhanPhong).NotEmpty().WithMessage("Email nhận phòng không thể trống");
            RuleFor(a => a.EmailNhanThongBao).NotEmpty().WithMessage("Email nhận thông báo không thể trống");

        }

    }
}
