using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Responses
{
    // Generic type <T>
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
