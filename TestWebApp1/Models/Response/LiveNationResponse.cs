using System.Runtime.Serialization;

namespace TestWebApp1.Models.Response
{
    [DataContract]
    public class LiveNationResponse
    {
        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public SummaryResponse Summary { get; set; }
    }
}