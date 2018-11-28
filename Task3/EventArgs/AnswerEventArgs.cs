using System;

namespace Task3 {
    public class AnswerEventArgs {
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }
        public Guid Id { get; private set; }
        
        
        public AnswerEventArgs(int number, int target, Guid id) {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            Id = id;
        }
    }
}