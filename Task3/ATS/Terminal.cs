using System;
using System.Runtime.Serialization;
using ATS.EventArgs;

namespace ATS.ATS {
    [DataContract]
    public sealed class Terminal {
        [DataMember]
        public int Number { get; private set; }
        [DataMember]
        public Port Port { get; private set; }

        public event EventHandler<CallEventArgs> CallEvent;
        public event EventHandler<AnswerEventArgs> AnswerEvent;
        public event EventHandler<RejectEventArgs> RejectEvent;

        public Terminal() {

        }
        
        public Terminal(int number, Port port) {
            Number = number;
            Port = port;
        }

        private void OnCallEvent(int targetNumber) {
            CallEvent?.Invoke(this, new CallEventArgs(Number, targetNumber));
        }

        private void OnAnswerEvent(int targetNumber) {
            AnswerEvent?.Invoke(this, new AnswerEventArgs(targetNumber));
        }

        private void OnEndCallEvent(int number) {
            RejectEvent?.Invoke(this, new RejectEventArgs(Number));
        }

        public void Call(int targetNumber) {
            //Console.WriteLine("Terminal -> Call");
            OnCallEvent(targetNumber);
        }
        
        public void Answer() {
            //Console.WriteLine("Terminal -> Answer");
            OnAnswerEvent(Number);
        }
        public void Reject() {
            //Console.WriteLine("Terminal -> Reject");
            OnEndCallEvent(Number);
        }

    }
}