using System;

namespace Task3.EventArgs {
    public class CallEventArgs {
        public int TargetNumber { get; }
        public int Number { get; }
        public Guid Id { get; set; }

        public CallEventArgs(int number, int targetNumber) {
            Number = number;
            TargetNumber = targetNumber;
        }

    }
}