using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroApi.Service.Services
{
    public class ServiceResponse<T>
    {
        public int StatusCode { get; set; }  // HTTP status code
        public object Response { get; set; } // Data or error message

        public ServiceResponse(int statusCode, object response)
        {
            StatusCode = statusCode;
            Response = response;
        }
    }
}
