using System;
using System.Collections.Generic;
using System.Linq;
using ATS.BillingSystem;
using ATS.Enums;
using ATS.EventArgs;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ATS.ATS {
    [DataContract]
    public class AutomaticTelephoneStation: IDisposable {
        [DataMember]
        private Dictionary<int, Customer> _usersData;
        [DataMember]
        private List<Tuple<int, int, Guid>> _connections = new List<Tuple<int, int, Guid>>();
        [DataMember]
        public List<CallHistory> CallHistory { get; private set; }
        public Dictionary<int, Customer> UsersData { get => _usersData;
            private set => _usersData = value; }
        public List<Tuple<int, int, Guid>> Connections { get => _connections;
            private set => _connections = value; }

        public AutomaticTelephoneStation() {
            UsersData = new Dictionary<int, Customer>();
            Connections = new List<Tuple<int, int, Guid>>();
            CallHistory = new List<CallHistory>();
        }

        public Terminal GiveTerminal(Customer customer, Tariff tariff) {
            var contract = new Contract(tariff);
            while (UsersData.ContainsKey(contract.TelephoneNumber)) {
                contract = new Contract(tariff);
            }
            var port = new Port();
            
            port.PortCallEvent += Call;
            port.PortAnswerEvent += Answer;
            port.PortRejectEvent += Reject;
            var terminal = new Terminal(contract.TelephoneNumber, port);
            terminal.CallEvent += port.OutgoingCall;
            terminal.AnswerEvent += port.Answer;
            terminal.RejectEvent += port.Reject;

            
            UsersData.Add(contract.TelephoneNumber, new Customer(port, contract, terminal));

            return terminal;
        }

        private void Call(object sender, CallEventArgs e) {
            if (UsersData.ContainsKey(e.TargetNumber)) {
                if (e.TargetNumber != e.Number) {
                    var senderNumber = e.Number;
                    var targetNumber = e.TargetNumber;

                    var senderPort = UsersData[senderNumber].Port;
                    var targetPort = UsersData[targetNumber].Port;


                    Console.WriteLine(@"Station -> CallEvent");

                    Connections.Add(Tuple.Create(e.Number, e.TargetNumber, e.Id));
                    targetPort.IncomingCall(senderNumber, targetNumber, e.Id);  
                }
                else {
                   Console.WriteLine(@"You try to call yourself");
                }
            }
            else {
                Console.WriteLine(@"This number does not exist");
            }
        }

        private void Answer(object sender, AnswerEventArgs e) {
            var currentConnection = Connections.FirstOrDefault(x => x.Item3 == e.Id);

            if (currentConnection == null) return;
            Console.WriteLine(@"Station -> AnswerEvent");

            var targetPort = UsersData[e.TargetTelephoneNumber].Port;
            targetPort.State = PortState.Busy;

            CallHistory.Add(new CallHistory(
                senderTelephoneNumber: currentConnection.Item1,
                targetTelephoneNumber: currentConnection.Item2,
                startCall: DateTime.Now,
                id: e.Id
            ));
        }

        private void Reject(object sender, RejectEventArgs e) {
            var currentConnection = Connections.ToList().FirstOrDefault(x => x.Item3 == e.Id);
            var inf = CallHistory.ToList().FirstOrDefault(x => x.Id == e.Id);

            if (currentConnection == null) return;
            var senderNumber = currentConnection.Item1;
            var targetNumber = currentConnection.Item2;

            var senderPort = UsersData[senderNumber].Port;
            var targetPort = UsersData[targetNumber].Port;

            if (senderNumber == e.Number) {
                targetPort.Reset();
            }
            else if (targetNumber == e.Number) {
                senderPort.Reset();
            }

            Console.WriteLine(@"Station -> RejectEvent");

            if (inf != null) {
                inf.EndCall = DateTime.Now;

               Console.WriteLine(@"Sender: {0}	Target: {1}	Duration: {2} sec
", senderNumber, targetNumber, inf.CallDuration.Seconds);
            }

            Connections.Remove(currentConnection);
        }

        public void SubscribeEvents() {
            foreach (var item in _usersData.Values) {
                item.Port.PortCallEvent += Call;
                item.Port.PortAnswerEvent += Answer;
                item.Port.PortRejectEvent += Reject;

                item.Terminal.CallEvent += item.Port.OutgoingCall;
                item.Terminal.AnswerEvent += item.Port.Answer;
                item.Terminal.RejectEvent += item.Port.Reject;
            }
            
        }

        public void Dispose() {
            UsersData = null;
            Connections = null;
            CallHistory = null;
        }
    }
}