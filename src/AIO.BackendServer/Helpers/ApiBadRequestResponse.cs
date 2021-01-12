using AIO.ViewModels.Statistics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Helpers
{
    public class ApiBadRequestResponse : ApiResponse
    {
        // trả về lỗi của model state
        public IEnumerable<ErrorResponVm> Errors { get; }
        public string ErrorMsg { get; }

        public ApiBadRequestResponse(ModelStateDictionary modelState)
            : base(400)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }

            Errors = modelState.Select(x => new ErrorResponVm{
                key = x.Key,
                error= string.Join(",", x.Value.Errors.Select(a => a.ErrorMessage).ToList())
            }).ToArray();
            ErrorMsg = string.Join("," , Errors.Select(a => a.error).ToList());
        }

        public ApiBadRequestResponse(IdentityResult identityResult)
           : base(400)
        {
            Errors = identityResult.Errors
                .Select(x => new ErrorResponVm{
                key = x.Code,
                error= x.Description
            }).ToArray();
        }

        public ApiBadRequestResponse(string message)
           : base(400, message)
        {
        }
    }
}