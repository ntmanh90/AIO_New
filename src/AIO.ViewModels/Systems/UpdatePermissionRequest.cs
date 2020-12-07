using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems
{
    public class UpdatePermissionRequest
    {
        public List<PermissionVm> Permissions { get; set; } = new List<PermissionVm>();
    }
}