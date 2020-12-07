using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.CongTy
{
    public class CongTyRequestValidator : AbstractValidator<CongTyRequest>
    {

        public CongTyRequestValidator()
        {
            RuleFor(a => a.MaCongTy).NotEmpty().WithMessage("Nhập mã công ty").MaximumLength(20).WithMessage("Không quá 20 ký tự");
            RuleFor(a => a.TenCongTy).NotEmpty().WithMessage("Nhập tên công ty");          
        }

    }
}
