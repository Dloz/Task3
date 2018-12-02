using System.Threading;

namespace Task3 {
    internal class Program {
        public static void Main(string[] args) {
            var ats = new AutomaticTelephoneStation();
            var customer = new Customer();
            var customer2 = new Customer();
            var t1 = ats.GiveTerminal(customer, new Tariff());
            var t2 = ats.GiveTerminal(customer2, new Tariff());
            
            t1.Call(t2.Number);
            t2.Answer();
            Thread.Sleep(2000);
            t1.Reject();
        }
    }
}