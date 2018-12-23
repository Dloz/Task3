using System;
using System.Runtime.Serialization;
using ATS.ATS;
using ATS.BillingSystem;

namespace ATS {
    [DataContract]
    public sealed class Customer: ICustomer {
        [DataMember]
        public Port Port { get; private set; }
        [DataMember]
        public Contract Contract { get; private set; }
        [DataMember]
        public Terminal Terminal { get; private set; }
        [DataMember]
        public string Name { get; private set; }

        public event EventHandler ConnectEvent;
        public event EventHandler DisconnectEvent;

        public Customer() {
        }

        public Customer(Port port, Contract contract) {
            Port = port;
            Contract = contract;
        }

        public Customer(Port port, Contract contract, Terminal terminal): this(port, contract) {
            Terminal = terminal;
            Name = $"A{terminal.Number}";
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

        public override string ToString() {
            return $"Name: {Name}\n" +
                $"Number: {Terminal.Number}\n";
        }
    }
}