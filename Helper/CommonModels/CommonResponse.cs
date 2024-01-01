using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CommonModels
{
    public enum AttendanceList
    {
        Present = 1,
        Absent = 2,
        HalfDay = 3
    }

    public class CommonResponse
    {
        public bool Status { get; set; } = false;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public string Message { get; set; } = "Something went wrong! Please try again.";
        public dynamic Data { get; set; } = null;
    }
}
