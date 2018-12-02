using System;

namespace Task3.Exceptions {
    public class CallException: ApplicationException {
        private const string Format = "Couldn't receive answer from abonent";
        public override string Message => string.Format(Format);

        public CallException() {

        }

    }
}