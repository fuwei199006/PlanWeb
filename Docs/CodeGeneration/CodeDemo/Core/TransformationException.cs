﻿using System;

namespace CodeDemo.Core
{
    [Serializable]
    public class TransformationException : Exception
    {
        public TransformationException() { }
        public TransformationException(string message) : base(message) { }
        public TransformationException(string message, Exception inner) : base(message, inner) { }
        protected TransformationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
