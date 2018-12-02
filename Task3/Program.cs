using System;
using System.Threading;
using Task3.ATS;
using Task3.BillingSystem;

namespace Task3 {
    internal class Program {
        public static void Main(string[] args) {
            var billing = new BillingSystem.BillingSystem();
            var ats = new AutomaticTelephoneStation();
            var customer = new Customer();
            var customer2 = new Customer();
            
            customer.SignContract(ats);
            customer2.SignContract(ats);
            
            customer2.Disconnect();
            customer.Terminal.Call(customer2.Terminal.Number);
            customer.Reject();
            customer2.Connect();
            customer.Terminal.Call(customer2.Terminal.Number);
            customer2.Answer();
            Thread.Sleep(3000);
            customer2.Reject();

            var reports = billing.GetReport(ats.CallHistory, customer.Contract);
            foreach (var report in reports) {
                Console.WriteLine("SenderNumber: {0} TargetNumber: {1} Date: {2} Duration: {3} Cost: {4:F}",
                    report.SenderTelephoneNumber,
                    report.TargetTelephoneNumber,
                    report.DateCall,
                    report.CallDuration,
                    report.Cost);
            }

        }
    }
}