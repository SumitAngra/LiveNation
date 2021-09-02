using System.Runtime.Serialization;

namespace TestWebApp1.Models
{
    [DataContract]
    public class LiveNationInput
    {
        [DataMember]
        public int Input { get; set; }
    }
}