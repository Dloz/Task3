using System;

namespace Task3.Exceptions {
    public class BusyException: ApplicationException {
        private const string Format = "The line is busy";
        public override string Message => string.Format(Format);

        public BusyException() {
            
        }
    }
}