using System;
using System.Runtime.Serialization;

namespace Lab3OOP
{
    public class ExceptionClass: Exception
    {
        public ExceptionClass(string message) : base(message)
        {
            
        }
    }
    
    public class IniSectionNotExists: Exception
    {
        public IniSectionNotExists()
        {
            
        }
    }
    
    public class IniConvertNotExists: Exception
    {
        public IniConvertNotExists()
        {
            
        }
    }
    
    public class IniWrongFormat: Exception
    {
        public IniWrongFormat()
        {
            
        }
    }
}