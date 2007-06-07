namespace Mono.Sms.Core
{
    public class Result
    {
        private string message;
        private string error = null;

        #region ctor
        public Result(string message, string error)
        {
            this.message = message;
            this.error = error;
        }

        public Result(string message)
        {
            this.message = message;
            this.error = null;
        }

        public Result() { }

        #endregion

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }
    }
}