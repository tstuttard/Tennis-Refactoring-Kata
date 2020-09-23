using System;
using System.Runtime.Serialization;

namespace Tennis
{
    [Serializable]
    public class PlayerNotFoundException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public PlayerNotFoundException()
        {
        }

        public PlayerNotFoundException(string message) : base(message)
        {
        }

        public PlayerNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PlayerNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}