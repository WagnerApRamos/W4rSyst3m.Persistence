#region Using

using System;

#endregion

namespace W4rSyst3m.Persistence.Tools
{
    /// <summary>
    /// Exception to throw when an unexpeted error happpens
    /// </summary>
    public class PersistenceException 
        : Exception
    {
        public PersistenceException(string message) :
            base(message)
        { }

        public PersistenceException(string message, Exception innerException) :
            base(message, innerException)
        { }
    }
}
