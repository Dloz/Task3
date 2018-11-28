using System;

namespace Task3 {
    public class Terminal {
        private int _number;
        private Port _port;
        public int Number => _number;
        
        public event EventHandler<CallEventArgs> CallEvent;
        public event EventHandler<AnswerEventArgs> AnswerEvent;
        public event EventHandler<RejectEventArgs> EndCallEvent;
        
        
        public Terminal(int number, Port port) {
            this._number = number;
            _port = port;
        }
        protected virtual void OnCallEvent(int targetNumber) {
            if (CallEvent != null) {
                CallEvent(this, new CallEventArgs(_number, targetNumber));
            }
        }

        protected virtual void OnAnswerEvent(int targetNumber, Guid id) {
            if (AnswerEvent != null) {
                AnswerEvent(this, new AnswerEventArgs(_number, targetNumber, id));
            }
        }

        protected virtual void OnEndCallEvent(Guid id) {
            if (EndCallEvent != null)
                EndCallEvent(this, new RejectEventArgs(id, _number));
        }

        public void Call(int targetNumber) {
            OnCallEvent(targetNumber);
        }
    }
}