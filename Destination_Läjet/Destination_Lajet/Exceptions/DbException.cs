using System;

namespace Destination_Lajet.Exceptions
{
    public class DbException : Exception
    {
        public DbException(string message) : base(message)
        { }
    }
}
