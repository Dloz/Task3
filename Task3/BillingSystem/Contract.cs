using System;
using System.Runtime.Serialization;
using ATS.BillingSystem;

namespace ATS {
    [DataContract]
    public class Contract {
        private static readonly Random Random = new Random();
        [DataMember]
        public Tariff Tariff { get; private set; }
        [DataMember]
        public int TelephoneNumber { get; private set; }

        public Contract() {

        }
        public Contract(Tariff tariff) {
            Tariff = tariff;
            TelephoneNumber = Random.Next(100, 999);
        }
        
        public Contract(int telephoneNumber, Tariff tariff) {
            Tariff = tariff;
            TelephoneNumber = telephoneNumber;
        }
    }
}