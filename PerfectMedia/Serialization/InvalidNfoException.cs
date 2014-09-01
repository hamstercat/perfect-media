using System;
using System.Runtime.Serialization;

namespace PerfectMedia.Serialization
{
    [Serializable]
    public class InvalidNfoException : Exception
    {
        public string NfoFilePath { get; private set; }

        public InvalidNfoException(string nfoFilePath, Exception inner)
            : base(FormatMessage(nfoFilePath), inner)
        {
            NfoFilePath = nfoFilePath;
        }

        private static string FormatMessage(string nfoFilePath)
        {
            return string.Format("Invalid file \"{0}\"", nfoFilePath);
        }
    }
}
