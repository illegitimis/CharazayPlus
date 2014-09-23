﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndreiPopescu.CharazayPlus.Utils
{
  internal static class MatlabInterpolant
  {
    #region data
    //age, A, B
    static double[,] C = new double[21, 3] {
{15, 0.0077067,   7.0558 },
{16, 0.0039195,   7.097  },
{17, 2.5022e-005, 11.156 },
{18, 0.00022995,  9.3358 },
{19, 0.00036645,  9.2067 },
{20, 0.0016786,   8.1619 },
{21, 8.3881e-006, 12.4104},
{22, 0.0016938,   8.1762 },
{23, 0.0010796,   8.7792 },
{24, 0.00107,     8.8438 },
{25, 0.00045826,  9.6119 },
{26, 0.00020818,  10.2586},
{27, 7.2024e-005, 11.0771},
{28, 0.00036566,  9.7925 },
{29, 0.00043645,  9.6059 },
{30, 0.0019404,   8.1264 },
{31, 0.00019515,  10.0829},
{32, 3.6795e-005, 11.3889},
{33, 5.5153e-006, 12.8095},
{34, 8.1344e-008, 15.9509},
{35, 1.8951e-008, 16.902 },
    };

    //f
    static double[,] F = new double[21, 3] {
{15, 0.016218,    6.2627  },
{16, 4.7853e-006, 13.063  },
{17, 5.1939e-005, 10.4259 },
{18, 0.00042559,  8.2682  },
{19, 0.00028409,  9.2845  },
{20, 1.5483e-005, 11.7858 },
{21, 0.0001417,   10.1302 },
{22, 4.1095e-005, 11.4033 },
{23, 0.0092186,   6.6062  },
{24, 0.0025501,   7.8799  },
{25, 4.3463e-005, 11.2636 },
{26, 0.0071527,   7.1715  },
{27, 0.00062654,  9.0761  },
{28, 0.00047889,  9.3853  },
{29, 0.00038446,  9.5935  },
{30, 0.0033965,   7.5631  },
{31, 0.00013381,  10.4203 },
{32, 1.852e-005,  11.982  },
{33, 1.8104e-006, 13.8469 },
{34, 6.1378e-008, 16.2691 },
{35, 8.8147e-007, 12.1012 },
    };
    //g
    static double[,] G = new double[21, 3] {
{15, 0.00073661,  8.2863  },
{16, 1.7843e-006, 13.5505 },
{17, 2.6712e-006, 12.643  },
{18, 2.4563e-005, 11.0377 },
{19, 1.17e-005,   12.0504 },
{20, 4.0657e-005, 11.2886 },
{21, 8.6232e-005, 10.72   },
{22, 0.00010393,  10.8214 },
{23, 4.7351e-006, 13.4236 },
{24, 6.0014e-005, 11.1529 },
{25, 0.001471,    7.9739  },
{26, 3.4196e-005, 11.8632 },
{27, 0.00033858,  9.9272  },
{28, 0.0031301,   7.8196  },
{29, 0.0019316,   8.0869  },
{30, 0.001018,    8.6758  },
{31, 2.9523e-005, 11.8266 },
{32, 1.8556e-005, 12.1875 },
{33, 4.5405e-006, 13.2841 },
{34, 3.4316e-008, 17.4206 },
{35, 2.2935e-008, 17.9461 },
  };
    
    #endregion

    public static double GetTMValue (byte age, char pos, double x)
    {
      double[,] data = null;
      switch (pos)
      {
        case 'G': data = MatlabInterpolant.G; break;
        case 'F': data = MatlabInterpolant.F; break;
        case 'C': data = MatlabInterpolant.C; break;
      }
      //
      double dage = Math.Min(35d, (double)age);
      dage = Math.Max(15d, dage);
      //
      for (int i=0; i < 21; i++)
      {
        if (data[i, 0] == age)
        {
          return data[i, 1] * Math.Exp(data[i, 2] * x);          
        }
      }
      return double.NaN;
    }

    public static void GetAB (byte age, char pos, out double a, out double b)
    {
      double[,] data = null;
      switch (pos)
      {
        case 'G': data = MatlabInterpolant.G; break;
        case 'F': data = MatlabInterpolant.F; break;
        case 'C': data = MatlabInterpolant.C; break;
      }
      a = b = Double.NaN;
      //
      double dage = Math.Min(35d, (double)age);
      dage = Math.Max(15d, dage);
      //
      for (int i=0; i < 21; i++)
      {
        if (data[i, 0] == age)
        {
          a = data[i, 1];
          b = data[i, 2];
          return;
        }
      }
     
    }

  }
}
