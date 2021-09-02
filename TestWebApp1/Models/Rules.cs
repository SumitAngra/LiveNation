using System.Runtime.Serialization;

namespace TestWebApp1.Models
{
    [DataContract]
    public class Rules
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string RuleName { get; set; }

        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public string Operation { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string ComparisonOperation { get; set; }

        [DataMember]
        public string ComparisonValue { get; set; }

        [DataMember]
        public string Output { get; set; }

    }
}