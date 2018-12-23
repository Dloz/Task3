using System;
using System.Runtime.Serialization;

namespace ATS.EventArgs {
    [DataContract]
    public class RejectEventArgs {
        public int Number { get; private set; }
        public Guid Id { get; set; }

        public RejectEventArgs(int number) {
            Number = number;
        }
    }
}