using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// The exception that is thrown when metadata can't be found for a movie.
    /// </summary>
    [Serializable]
    public class MovieNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieNotFoundException"/> class.
        /// </summary>
        public MovieNotFoundException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MovieNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public MovieNotFoundException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieNotFoundException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected MovieNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
