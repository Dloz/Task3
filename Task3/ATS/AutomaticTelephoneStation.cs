using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Task3.BillingSystem;

namespace Task3 {
    public class AutomaticTelephoneStation {
        private readonly Dictionary<int, Tuple<Port, Contract>> _usersData;
        private readonly List<Tuple<int, int, Guid>> _connections;
        public List<CallHistory> CallHistory { get; set; }

        public AutomaticTelephoneStation() {
            _usersData = new Dictionary<int, Tuple<Port, Contract>>();
            _connections = new List<Tuple<int, int, Guid>>();
        }

        public Terminal GiveTerminal(Customer customer, Tariff tariff) {
            var contract = new Contract(customer, tariff);
            var port = new Port();

            port.PortCallEvent += Call;
            port.PortAnswerEvent += Answer;
            port.PortRejectEvent += Reject;
            
            var terminal = new Terminal(contract.TelephoneNumber, port);
            terminal.CallEvent += port.OutgoingCall;
            terminal.AnswerEvent += port.Answer;
            terminal.RejectEvent += port.Reject;
            terminal.ConnectEvent += port.Connect;
            terminal.DisconnectEvent += port.Disconnect;
            
            _usersData.Add(contract.TelephoneNumber, new Tuple<Port, Contract>(port,contract));

            return terminal;
        }

        private void Call(object sender, CallEventArgs e) {
            if (_usersData.ContainsKey(e.TargetNumber)) {
                if (e.TargetNumber != e.Number) {
                    var senderNumber = e.Number;
                    var targetNumber = e.TargetNumber;

                    var senderPort = _usersData[senderNumber].Item1;
                    var targetPort = _usersData[targetNumber].Item1;


                    Console.WriteLine("Station -> CallEvent");

                    _connections.Add(Tuple.Create(e.Number, e.TargetNumber, e.Id));
                    targetPort.IncomingCall(senderNumber, targetNumber, e.Id);  
                }
                else {
                    Console.WriteLine("You try to call yourself");
                }
            }
            else {
                Console.WriteLine("This number does not exist");
            }
        }

        private void Answer(object sender, AnswerEventArgs e) {
            var currentConnection = _connections.SingleOrDefault(x => x.Item3 == e.Id);

            if (currentConnection == null) return;
            Console.WriteLine("Station -> AnswerEvent");

            var targetPort = _usersData[e.TargetTelephoneNumber].Item1;
            targetPort.State = PortState.Busy;

            CallHistory.Add(new CallHistory(
                senderTelephoneNumber: currentConnection.Item1,
                targetTelephoneNumber: currentConnection.Item2,
                startCall: DateTime.Now,
                id: e.Id
            ));
        }

        private void Reject(object sender, RejectEventArgs e) {
            var currentConnection = _connections.SingleOrDefault(x => x.Item3 == e.Id);
            var inf = CallHistory.SingleOrDefault(x => x.Id == e.Id);

            if (currentConnection == null) return;
            var senderNumber = currentConnection.Item1;
            var targetNumber = currentConnection.Item2;

            var senderPort = _usersData[senderNumber].Item1;
            var targetPort = _usersData[targetNumber].Item1;

            if (senderNumber == e.Number) {
                targetPort.Reset();
            }
            else if (targetNumber == e.Number) {
                senderPort.Reset();
            }

            Console.WriteLine("Station -> RejectEvent");

            if (inf != null) {
                inf.EndCall = DateTime.Now;

                Console.WriteLine("Sender: {0}\tTarget: {1}\tDuration: {2} sec\n", senderNumber, targetNumber, inf.CallDuration.Seconds);
            }

            _connections.Remove(currentConnection);
        }
    }
}