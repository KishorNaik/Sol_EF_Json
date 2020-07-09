using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Sol_Api.Models
{
    [DataContract]
    public class UserCommunicationModel
    {
        [DataMember(EmitDefaultValue = false)]
        public decimal? UserCommunicationId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String MobileNo { get; set; }
    }
}