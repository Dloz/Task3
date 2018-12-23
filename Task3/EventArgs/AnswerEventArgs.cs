using System;
using System.Runtime.Serialization;

namespace ATS.EventArgs {
    [DataContract]
    public class AnswerEventArgs {
        public int TargetTelephoneNumber { get; }
        public Guid Id { get; set; }
        
        public AnswerEventArgs(int number) {
            TargetTelephoneNumber = number;
        }
    }
}