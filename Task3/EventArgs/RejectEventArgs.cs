using System;

namespace Task3 {
    public class RejectEventArgs {
        public int Number { get; private set; }
        public Guid Id { get; set; }

        public RejectEventArgs(int number) {
            Number = number;
        }
    }
}