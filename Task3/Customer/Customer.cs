using System;
using Task3.ATS;
using Task3.BillingSystem;

namespace Task3 {
    public sealed class Customer: ICustomer {
        public Port Port { get; private set; }
        public Contract Contract { get; private set; }
        public Terminal Terminal { get; private set; }

        public event EventHandler ConnectEvent;
        public event EventHandler DisconnectEvent;

        public Customer() {
        }

        public Customer(Port port, Contract contract) {
            Port = port;
            Contract = contract;
        }

        public void SignContract(AutomaticTelephoneStation ats) {
            Terminal = ats.GiveTerminal(this, new Tariff());
            Contract = new Contract(Terminal.Number, new Tariff());
            Port = Terminal.Port;
            
            ConnectEvent += Port.Connect; 
            DisconnectEvent += Port.Disconnect;
        }

        public void Call(int targetNumber) {
            Terminal.Call(targetNumber);
        }

        public void Answer() {
            Terminal.Answer();
        }

        public void Reject() {
            Terminal.Reject();
        }
        
        public void Connect() {
            OnConnectEvent();
        }
        
        public void Disconnect() {
            OnDisconnectEvent();
        }

        private void OnConnectEvent() {
            ConnectEvent?.Invoke(this, System.EventArgs.Empty);
        }

        private void OnDisconnectEvent() {
            DisconnectEvent?.Invoke(this, System.EventArgs.Empty);
        }
    }
}