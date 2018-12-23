using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ATS.ATS;
using ATS.BillingSystem;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ATS {
    public static class Program {
        public static AutomaticTelephoneStation Ats = new AutomaticTelephoneStation();
        [STAThread]
        public static void Main(string[] args) {
            var billing = new BillingSystem.BillingSystem();
            var rand = new Random();
            for (var i = 0; i < 100; i++) {
                var customer = new Customer();
                customer.SignContract(Ats);
            }
            //var customer1 = new Customer();
            //var customer2 = new Customer();
            //customer2.SignContract(ats);
            //customer1.SignContract(ats);

            //customer2.Call(customer1.Terminal.Number);

            var json = new DataContractJsonSerializer(typeof(AutomaticTelephoneStation));
            //using (var fstr = new FileStream("ATS.json", FileMode.OpenOrCreate)) {
            //    json.WriteObject(fstr, ats);
            //}

            using (var fstr = new FileStream("ATS.json", FileMode.OpenOrCreate)) {
                Ats = json.ReadObject(fstr) as AutomaticTelephoneStation;
                Ats?.SubscribeEvents();
            }

            CallGenerator.Generate(Ats);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}