using System;

namespace Task3 {
    public class Customer {
        public Port Port { get; }
        public Contract Contract { get; }

        public event EventHandler ConnectEvent;
        public event EventHandler DisconnectEvent;

        public Customer() {
            Port = new Port();
            Contract = new Contract(new Tariff());
        }

        public Customer(Port port, Contract contract) {
            Port = port;
            Contract = contract;
        }


        public void Connect() {
            Console.WriteLine("Terminal -> Connect"); 
            ConnectEvent?.Invoke(this, EventArgs.Empty);
        }
        
        public void Disconnect() {
            Console.WriteLine("Terminal -> Disconnect"); 
            DisconnectEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}