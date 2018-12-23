using System.Collections.Generic;
using System.Linq;

namespace ATS.BillingSystem {
    public class BillingSystem {
        
        public IEnumerable<Report> GetReport(IEnumerable<CallHistory> callHistory, Contract contract) {
            return callHistory
                .Where(x => x.SenderTelephoneNumber == contract.TelephoneNumber ||
                            x.TargetTelephoneNumber == contract.TelephoneNumber)
                .Select(x => new Report(
                    callDuration: x.CallDuration,
                    dateCall: x.StartCall,
                    senderTelephoneNumber: x.SenderTelephoneNumber,
                    targetTelephoneNumber: x.TargetTelephoneNumber, 
                    cost: x.CallDuration.TotalMinutes * contract.Tariff.CostPerMinute
                ));
        }

        public IEnumerable<Report> GetReport(IEnumerable<CallHistory> callHistory) {
            return callHistory
                .Select(x => new Report(
                    callDuration: x.CallDuration,
                    dateCall: x.StartCall,
                    senderTelephoneNumber: x.SenderTelephoneNumber,
                    targetTelephoneNumber: x.TargetTelephoneNumber,
                    cost: x.CallDuration.TotalMinutes * 10d
                ));
        }
    }
}