using System;

namespace Task3 {
    public class Port {
        public PortState State;

        public event EventHandler<CallEventArgs> PortCallEvent;
        public event EventHandler<AnswerEventArgs> PortAnswerEvent;
        public event EventHandler<RejectEventArgs> PortRejectEvent;


        protected virtual void OnPortCallEvent(int number, int targetNumber) {
            PortCallEvent?.Invoke(this, new CallEventArgs(number, targetNumber));
        }

        protected virtual void OnPortAnswerEvent(AnswerEventArgs e) {
            PortAnswerEvent?.Invoke(this, e);
        }

        protected virtual void OnPortRejectEvent(RejectEventArgs e) {
            PortRejectEvent?.Invoke(this, e);
        }

        public void Call(int number, int targetNumber) {
            OnPortCallEvent(number, targetNumber);
        }
    }
}