using System;
using Task3.BillingSystem;

namespace Task3 {
    public class Contract {
        private static readonly Random Random = new Random();

        public Tariff Tariff { get; }
        public int TelephoneNumber { get; }

        public Contract(Tariff tariff) {
            Tariff = tariff;
            TelephoneNumber = Random.Next(100000, 999999);
        }
        
        public Contract(int telephoneNumber, Tariff tariff) {
            Tariff = tariff;
            TelephoneNumber = telephoneNumber;
        }
    }
}