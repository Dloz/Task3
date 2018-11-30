using System;

namespace Task3 {
    public class CallEventArgs {
        public int TargetNumber { get; set; }
        public int Number { get; set; }
        public Guid Id { get; set; }

        public CallEventArgs(int number, int targetNumber) {
            Number = number;
            TargetNumber = targetNumber;
        }

    }
}