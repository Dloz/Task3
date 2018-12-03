using System;

namespace Task3.EventArgs {
    public class AnswerEventArgs {
        public int TargetTelephoneNumber { get; }
        public Guid Id { get; set; }
        
        public AnswerEventArgs(int number) {
            TargetTelephoneNumber = number;
        }
    }
}