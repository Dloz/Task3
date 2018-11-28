using System;

namespace Task3 {
    public class RejectEventArgs {
        public Guid Id { get; private set; }
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }

        public RejectEventArgs(Guid id, int number) {
            Id = id;
            TelephoneNumber = number;
        }
    }
}