using AIO.BackendServer.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Authorization
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(FunctionCode functionId, CommandCode commandId)
            : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { functionId, commandId };
        }
    }
}