using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Systems
{
    public class CommandAssignRequest
    {
        public string[] CommandIds { get; set; }

        public bool AddToAllFunctions { get; set; }
    }
}