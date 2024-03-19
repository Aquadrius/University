using System.Net;

namespace University.Controllers.UserController
{
    public class ApiResponse
    {
        internal HttpStatusCode StatusCode;

        public bool IsSuccess { get; internal set; }
        
     }
}