using System;
using System.Runtime.Serialization;

namespace ATS.BillingSystem {
    [DataContract]
    public class CallHistory {
        public TimeSpan CallDuration => EndCall > StartCall ? (EndCall - StartCall) : TimeSpan.Zero;
        public DateTime StartCall { get; }
        public DateTime EndCall { get; set; }
        public int TargetTelephoneNumber { get; }
        public int SenderTelephoneNumber { get; }
        public Guid Id { get; }

        public string Info { get; private set; }

        public CallHistory(int senderTelephoneNumber, int targetTelephoneNumber, DateTime startCall, Guid id) {
            SenderTelephoneNumber = senderTelephoneNumber;
            TargetTelephoneNumber = targetTelephoneNumber;
            StartCall = startCall;
            EndCall = new DateTime(0);
            Id = id;
            Info = this.ToString();
        }

        public sealed override string ToString() {
            return $"Start: {StartCall.ToShortTimeString()}\n" +
                $"End: {EndCall.ToShortTimeString()}\n" +
                $"Target number: {TargetTelephoneNumber}\n" +
                $"Sender number: {SenderTelephoneNumber}\n" +
                $"Id: {Id.ToString()}\n" +
                $"Call duration: {CallDuration}\n\n";
        }
    }
}