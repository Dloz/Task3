using System;

namespace Task3 {
    public class AnswerEventArgs {
        public int TargetTelephoneNumber { get; set; }
        public Guid Id { get; set; }
        
        public AnswerEventArgs(int number) {
            TargetTelephoneNumber = number;
        }
    }
}