using System;

namespace Task3 {
    public class Contract {
        private static Random _random = new Random();

        public Tariff Tariff { get; }
        public int TelephoneNumber { get; }

        public Contract(Tariff tariff) {
            Tariff = tariff;
            TelephoneNumber = _random.Next(100000, 999999);
        }

    }
}