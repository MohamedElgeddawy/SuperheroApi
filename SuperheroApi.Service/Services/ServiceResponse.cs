using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperheroApi.Service.Services
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Success";

        // ✅ Default constructor (no parameters)
        public ServiceResponse() { }

        public ServiceResponse(T data, bool isSuccess, string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
    }


}
