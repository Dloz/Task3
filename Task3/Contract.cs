using System;

namespace Task3 {
    public class Contract {
        private static Random _random = new Random();
        
        private readonly Customer _customer;
        private readonly Tariff _tariff;
        private int _telephoneNumber;
        
        public Customer Customer => _customer;
        public Tariff Tariff => _tariff;
        public int TelephoneNumber => _telephoneNumber;

        public Contract(Customer customer, Tariff tariff) {
            _customer = customer;
            _tariff = tariff;
            _telephoneNumber = _random.Next(100000, 999999);
        }

    }
}