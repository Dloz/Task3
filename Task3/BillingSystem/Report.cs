using System;

namespace Task3.BillingSystem {
    public class Report {
        public TimeSpan CallDuration { get; private set; }
        public DateTime DateCall { get; private set; }
        public int SenderTelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }
        public double Cost { get; private set; }

        public Report(TimeSpan callDuration, DateTime dateCall, int senderTelephoneNumber, int targetTelephoneNumber, double cost) {
            CallDuration = callDuration;
            DateCall = dateCall;
            SenderTelephoneNumber = senderTelephoneNumber;
            TargetTelephoneNumber = targetTelephoneNumber;
            Cost = cost;    
        }
    }
}