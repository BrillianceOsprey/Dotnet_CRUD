using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Shared.Dtos
{
    public class ResCodeMessage
    {
        public dynamic? v_data { get; set; }
        public string? v_rescode { get; set; } = "201";
        public string? v_resmessage { get; set; }

    }
}