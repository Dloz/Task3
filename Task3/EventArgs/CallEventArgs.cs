namespace Task3 {
    public class CallEventArgs {
        private int _number;
        private int _targetNumber;

        public CallEventArgs(int number, int targetNumber) {
            _number = number;
            _targetNumber = targetNumber;
        }
    }
}