using System;
using System.Runtime.Serialization;
using ATS.Enums;
using ATS.EventArgs;

namespace ATS.ATS {
    [DataContract]
    public sealed class Port {
        [DataMember]
        public PortState State;
        [DataMember]
        public string Name { get; private set; }
        private Guid CurrentCallId { get; set; }

        public event EventHandler<CallEventArgs> PortCallEvent;
        public event EventHandler<AnswerEventArgs> PortAnswerEvent;
        public event EventHandler<RejectEventArgs> PortRejectEvent;
        public event EventHandler<CallEventArgs> IncomingCallEvent;

        public Port() {
            Name = "Default port";
        }

        public void OutgoingCall(object sender, CallEventArgs e) {
            if (State != PortState.Connected) {
                return;
            }
            State = PortState.Busy;

            CurrentCallId = Guid.NewGuid();
            e.Id = CurrentCallId;
            Console.WriteLine(@"Port -> OutgoingCall: id {0}", CurrentCallId);

            PortCallEvent?.Invoke(sender, e);
        }
        
        public void IncomingCall(int telephoneNumber, int targetTelephoneNumber, Guid id) {
            if (State != PortState.Connected) {
                return;
            }
            State = PortState.Busy;

            CurrentCallId = id;

            Console.WriteLine(@"Port -> IncomingCall: id {0}", CurrentCallId);
            IncomingCallEvent?.Invoke(this, new CallEventArgs(telephoneNumber, targetTelephoneNumber));
        }
        
        public void Answer(object sender, AnswerEventArgs e){
            if (State != PortState.Busy) {
                return;
            }
            e.Id = CurrentCallId;
            Console.WriteLine(@"Port -> CallStarted: id {0}", CurrentCallId);
            PortAnswerEvent?.Invoke(sender, e);
        }

        public void Reject(object sender, RejectEventArgs e){
            if (State != PortState.Busy) {
                return;
            }
            State = PortState.Connected;

            e.Id = CurrentCallId;
            //Console.WriteLine("Port -> CallRejecting: id {0}", CurrentCallId);
            CurrentCallId = Guid.Empty;
            PortRejectEvent?.Invoke(sender, e);
        }
        
        public void Reset() {
            State = PortState.Connected;
            CurrentCallId = Guid.Empty;
        }
        
        public void Connect(object sender, System.EventArgs e) {
            State = PortState.Connected;
        }

        public void Disconnect(object sender, System.EventArgs e) {
            State = PortState.Disconnected;
        }

        public override string ToString() {
            return Name;
        }
    }
}