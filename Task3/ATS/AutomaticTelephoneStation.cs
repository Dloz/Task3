using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Task3 {
    public class AutomaticTelephoneStation {
        private Dictionary<int, Tuple<Port, Contract>> usersData;

        public AutomaticTelephoneStation() {
            usersData = new Dictionary<int, Tuple<Port, Contract>>();
        }

        public Terminal GiveTerminal(Customer customer, Tariff tariff) {
            var contract = new Contract(customer, tariff);
            var port = new Port();

            port.PortCallEvent += Call;
            port.PortAnswerEvent += Answer;
            port.PortRejectEvent += Reject;
            
            var terminal = new Terminal(contract.TelephoneNumber, port);
            
            usersData.Add(contract.TelephoneNumber, new Tuple<Port, Contract>(port,contract));

            return terminal;
        }

        private void Call(object sender, CallEventArgs e) {
            
        }

        private void Answer(object sender, AnswerEventArgs e) {
            
        }

        private void Reject(object sender, RejectEventArgs e) {
            
        }
    }
}