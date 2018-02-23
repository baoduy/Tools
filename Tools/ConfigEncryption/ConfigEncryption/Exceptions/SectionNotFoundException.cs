using System;

namespace ConfigEncryption.Exceptions
{
    sealed class SectionNotFoundException : Exception
    {
        public SectionNotFoundException(string name) : base($"The section {name} is not found in config file.")
        {
        }
    }
}
