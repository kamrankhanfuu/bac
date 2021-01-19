using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BACAgent.Models.Response
{
    public class ApiResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }


        public async static Task<ApiResponse<U>> CreateResponse<U>(Func<Task<U>> func)
        {
            try
            {
                U result = await func();
                return new ApiResponse<U>
                {
                    Data = result,
                    IsSuccessful = true
                };
            }
            catch (Exception e)
            {
                return new ApiResponse<U>
                {
                    Message = e.Message,
                    IsSuccessful = false
                };
            }
        }

        public async static Task<ApiResponse<T>> ErrorResponse(string message)
        {
            return await Task.Run(() => new ApiResponse<T>() {
                IsSuccessful = false,
                Message = message
            });
        }
    }
}