using System;

namespace Task3 {
    public class Terminal {
        private readonly int _number;
        private Port _port;
        public int Number => _number;
        
        public event EventHandler<CallEventArgs> CallEvent;
        public event EventHandler<AnswerEventArgs> AnswerEvent;
        public event EventHandler<RejectEventArgs> RejectEvent;

        
        
        public Terminal(int number, Port port) {
            _number = number;
            _port = port;
        }
        protected virtual void OnCallEvent(int targetNumber) {
            CallEvent?.Invoke(this, new CallEventArgs(_number, targetNumber));
        }

        protected virtual void OnAnswerEvent(int targetNumber) {
            AnswerEvent?.Invoke(this, new AnswerEventArgs(targetNumber));
        }

        protected virtual void OnEndCallEvent(int number) {
            RejectEvent?.Invoke(this, new RejectEventArgs(_number));
        }

        public void Call(int targetNumber) {
            Console.WriteLine("Terminal -> Call");
            OnCallEvent(targetNumber);
        }
        
        public void Answer() {
            Console.WriteLine("Terminal -> Answer");
            OnAnswerEvent(_number);
        }
        public void Reject() {
            Console.WriteLine("Terminal -> Reject");
            OnEndCallEvent(_number);
        }

    }
}