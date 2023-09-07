using System.Runtime.Serialization;

namespace Exercise02 {
    internal class DataTimeFormat : DateTimeFormat {
        public DataTimeFormat(string formatString) : base(formatString) {
        }
    }
}