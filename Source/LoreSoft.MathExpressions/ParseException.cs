using System;

namespace LoreSoft.MathExpressions
{
    /// <summary>
    /// The exception that is thrown when there is an error parsing a math expression.
    /// </summary>
    [Serializable]
    public class ParseException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="ParseException"/> class.</summary>
        public ParseException()
            : base()
        { }

        /// <summary>Initializes a new instance of the <see cref="ParseException"/> class.</summary>
        /// <param name="message">The message.</param>
        public ParseException(string message)
            : base(message)
        { }

        /// <summary>Initializes a new instance of the <see cref="ParseException"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ParseException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
