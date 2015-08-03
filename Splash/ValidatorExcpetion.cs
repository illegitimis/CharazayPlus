using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AndreiPopescu.CharazayPlus.Splash
{
  public class ValidatorExcpetion : Exception
  {
    public ValidatorExcpetion ( ) { }

    public ValidatorExcpetion (string message) : base(message) { }

    public ValidatorExcpetion (SerializationInfo info, StreamingContext context)
      : base(info, context) { }

    public ValidatorExcpetion (string message, Exception innerException)
      : base(message, innerException) { }
  }
}
