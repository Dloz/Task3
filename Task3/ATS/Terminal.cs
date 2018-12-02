using System;
using Task3.EventArgs;

namespace Task3.ATS {
    public class Terminal {
        public int Number { get; }
        public Port Port { get; }

        public event EventHandler<CallEventArgs> CallEvent;
        public event EventHandler<AnswerEventArgs> AnswerEvent;
        public event EventHandler<RejectEventArgs> RejectEvent;

        
        
        public Terminal(int number, Port port) {
            Number = number;
            Port = port;
        }
        protected virtual void OnCallEvent(int targetNumber) {
            CallEvent?.Invoke(this, new CallEventArgs(Number, targetNumber));
        }

        protected virtual void OnAnswerEvent(int targetNumber) {
            AnswerEvent?.Invoke(this, new AnswerEventArgs(targetNumber));
        }

        protected virtual void OnEndCallEvent(int number) {
            RejectEvent?.Invoke(this, new RejectEventArgs(Number));
        }

        public void Call(int targetNumber) {
            Console.WriteLine("Terminal -> Call");
            OnCallEvent(targetNumber);
        }
        
        public void Answer() {
            Console.WriteLine("Terminal -> Answer");
            OnAnswerEvent(Number);
        }
        public void Reject() {
            Console.WriteLine("Terminal -> Reject");
            OnEndCallEvent(Number);
        }

    }
}