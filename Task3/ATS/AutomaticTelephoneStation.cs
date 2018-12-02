using System;
using System.Collections.Generic;
using System.Linq;
using Task3.BillingSystem;
using Task3.EventArgs;

namespace Task3.ATS {
    public class AutomaticTelephoneStation: IDisposable {
        private Dictionary<int, Customer> _usersData;
        private List<Tuple<int, int, Guid>> _connections;
        public List<CallHistory> CallHistory { get; set; }

        public AutomaticTelephoneStation() {
            _usersData = new Dictionary<int, Customer>();
            _connections = new List<Tuple<int, int, Guid>>();
            CallHistory = new List<CallHistory>();
        }

        public Terminal GiveTerminal(Customer customer, Tariff tariff) {
            var contract = new Contract(tariff);
            var port = new Port();
            
            port.PortCallEvent += Call;
            port.PortAnswerEvent += Answer;
            port.PortRejectEvent += Reject;
            
            var terminal = new Terminal(contract.TelephoneNumber, port);
            terminal.CallEvent += port.OutgoingCall;
            terminal.AnswerEvent += port.Answer;
            terminal.RejectEvent += port.Reject;
            
            _usersData.Add(contract.TelephoneNumber, new Customer(port,contract));

            return terminal;
        }

        private void Call(object sender, CallEventArgs e) {
            if (_usersData.ContainsKey(e.TargetNumber)) {
                if (e.TargetNumber != e.Number) {
                    var senderNumber = e.Number;
                    var targetNumber = e.TargetNumber;

                    var senderPort = _usersData[senderNumber].Port;
                    var targetPort = _usersData[targetNumber].Port;


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

            var targetPort = _usersData[e.TargetTelephoneNumber].Port;
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

            var senderPort = _usersData[senderNumber].Port;
            var targetPort = _usersData[targetNumber].Port;

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

        public void Dispose() {
            _usersData = new Dictionary<int, Customer>();
            _connections = new List<Tuple<int, int, Guid>>();
            CallHistory = new List<CallHistory>();
        }
    }
}