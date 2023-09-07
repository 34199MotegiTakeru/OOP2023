using System;
using System.Xml;

namespace Exercise01 {
    internal class DataContractSerializer {
        private Type type;

        public DataContractSerializer(Type type) {
            this.type = type;
        }

        internal Employee[] ReadObject(XmlReader reader) {
            throw new NotImplementedException();
        }
    }
}