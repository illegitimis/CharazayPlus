
namespace CharazayPlus.WebApi.Infrastructure
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;

  public abstract class ConvertibleTo<T> 
  {
    public abstract T Convert();

    //public abstract static implicit operator T(ConvertibleTo<T> dto);
    public /*abstract*/ T Convert (ConvertibleTo<T> dto)
    {
      return dto.Convert();
    }
  }
}