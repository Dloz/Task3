using System;
using System.Runtime.Serialization;

namespace ATS.EventArgs {
    [DataContract]
    public class CallEventArgs {
        public int TargetNumber { get; }
        public int Number { get; }
        public Guid Id { get; set; }

        public CallEventArgs(int number, int targetNumber) {
            Number = number;
            TargetNumber = targetNumber;
            Id = Guid.NewGuid();
        }

    }
}