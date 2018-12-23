using ATS.ATS;
using ATS.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Task3;

namespace ATS {
    public static class CallGenerator {
        private static readonly Random Random = new Random();
        public static void Generate(object obj) {
            var ats = obj as AutomaticTelephoneStation;
            var i = 0;
            while (i < 5) {
                foreach (var item in ats.UsersData.Values) {
                    var number = Random.Next(100, 999);
                    if (!ats.UsersData.ContainsKey(number)) continue;
                    GenerateCall(ats, item, number);
                    Thread.Sleep(50);
                    i++;
                }
            }
        }

        private static void GenerateCall(AutomaticTelephoneStation ats, ICustomer customer, int number) {
            var random = new Random();
            customer.Call(number); // Calling
            ats.UsersData.Values
                .FirstOrDefault(x => x.Terminal.Number == number)
                ?.Answer(); // Answering at Call
            Thread.Sleep(50);
            customer.Reject(); // Rejecting
        }
        

        private static void LoadData(string fileName) {
        }

    }
}
