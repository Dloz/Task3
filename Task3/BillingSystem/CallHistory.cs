using System;

namespace Task3.BillingSystem {
    public class CallHistory {
        public TimeSpan CallDuration => EndCall > StartCall ? (EndCall - StartCall) : TimeSpan.Zero;
        public DateTime StartCall { get; }
        public DateTime EndCall { get; set; }
        public int TargetTelephoneNumber { get; }
        public int SenderTelephoneNumber { get; }
        public Guid Id { get; }

        public CallHistory(int senderTelephoneNumber, int targetTelephoneNumber, DateTime startCall, Guid id) {
            SenderTelephoneNumber = senderTelephoneNumber;
            TargetTelephoneNumber = targetTelephoneNumber;
            StartCall = startCall;
            EndCall = new DateTime(0);
            Id = id;
        }
    }
}