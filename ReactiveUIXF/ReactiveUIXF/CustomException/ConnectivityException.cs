namespace ReactiveUIXF.CustomException
{
    using System;

    public class ConnectivityException : Exception
    {
        public ConnectivityException() : base("Opps, without internet conection")
        {

        }
    }
}