using System.Runtime.Serialization;

namespace TestWebApp1.Models.Response
{
    [DataContract]
    public class SummaryResponse
    {
        [DataMember]
        public int Live { get; set; }

        [DataMember]
        public int Nation { get; set; }

        [DataMember]
        public int LiveNation { get; set; }

        [DataMember]
        public int Integer { get; set; }
    }
}