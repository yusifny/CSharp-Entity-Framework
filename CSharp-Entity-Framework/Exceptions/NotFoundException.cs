using System;

namespace CSharp_Entity_Framework.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}