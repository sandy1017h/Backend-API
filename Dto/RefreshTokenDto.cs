using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dto
{
    public class RefreshTokenDto
    {
        public string AccessToken { get; set; }

         public string RefreshToken { get; set; }
    }
}