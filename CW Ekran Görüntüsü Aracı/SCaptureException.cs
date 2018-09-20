using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CW_Ekran_Görüntüsü_Aracı
{

    public class SCaptureException : Exception
    {
        [DebuggerHidden]
        public SCaptureException()
        {
        }
        [DebuggerHidden]
        public SCaptureException(string message) : base(message)
        {
        }
        [DebuggerHidden]
        public SCaptureException(string message, Exception ex) : base(message, ex)
        {
        }
        [DebuggerHidden]
        protected SCaptureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}