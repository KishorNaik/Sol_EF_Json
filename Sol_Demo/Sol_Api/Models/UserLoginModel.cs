using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Sol_Api.Models
{
    [DataContract]
    public class UserLoginModel
    {
        [DataMember(EmitDefaultValue = false)]
        public decimal? UserId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String UserName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String Password { get; set; }
    }
}