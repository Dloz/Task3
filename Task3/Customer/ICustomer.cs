using ATS.ATS;

namespace ATS {
    public interface ICustomer {
        void SignContract(AutomaticTelephoneStation ats);
        void Call(int targetNumber);
        void Answer();
        void Reject();
        void Connect();
        void Disconnect();
    }
}