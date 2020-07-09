using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Sol_Api.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember(EmitDefaultValue = false)]
        public decimal? UserId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public UserLoginModel UserLogin { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<UserCommunicationModel> UserCommunicationList { get; set; }
    }
}