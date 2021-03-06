﻿

namespace AndreiPopescu.CharazayPlus.Interpolate
{
  
  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   class MatlabInterpolant201606 : AndreiPopescu.CharazayPlus.Utils.MatlabInterpolator
  {

    private MatlabInterpolant201606 ( ) { }

    private static MatlabInterpolant201606 _instance = null;
    private static object _sync = new object();

    public static MatlabInterpolant201606 Instance
    {
      get
      {
        lock (_sync)
        {
          if (_instance == null)
          {
            _instance = new MatlabInterpolant201606();
          }
          return _instance;
        }
      }
    }

    public override double[,] G { get { return MatlabInterpolant201606._G; } }

    public override double[,] F { get { return MatlabInterpolant201606._F; } }

    public override double[,] C { get { return MatlabInterpolant201606._C; } }




    //Position: G
    static double[,] _G = new double[21, 5] { 
{ /*Age:*/ 15	, /*A:*/ 0.0357577	,   /*B:*/ 4.30858	, /*SSE:*/ 793.8	, /*#:*/ 72 },
{ /*Age:*/ 16	, /*A:*/ 2.83384e-006	, /*B:*/ 12.2325	, /*SSE:*/ 967.894	, /*#:*/ 57 },
{ /*Age:*/ 17	, /*A:*/ 6.09143e-005	, /*B:*/ 10.3694	, /*SSE:*/ 783.691	, /*#:*/ 46 },
{ /*Age:*/ 18	, /*A:*/ 1.53961e-005	, /*B:*/ 11.4119	, /*SSE:*/ 493.718	, /*#:*/ 48 },
{ /*Age:*/ 19	, /*A:*/ 2.26251e-005	, /*B:*/ 11.014	, /*SSE:*/ 68.7712	, /*#:*/ 46 },
{ /*Age:*/ 20	, /*A:*/ 0.000185297	, /*B:*/ 9.41368	, /*SSE:*/ 270.473	, /*#:*/ 40 },
{ /*Age:*/ 21	, /*A:*/ 8.31928e-005	, /*B:*/ 10.6827	, /*SSE:*/ 2265.59	, /*#:*/ 45 },
{ /*Age:*/ 22	, /*A:*/ 0.000914622	, /*B:*/ 8.65454	, /*SSE:*/ 2359.81	, /*#:*/ 45 },
{ /*Age:*/ 23	, /*A:*/ 2.85073e-006	, /*B:*/ 13.8521	, /*SSE:*/ 81.9001	, /*#:*/ 35 },
{ /*Age:*/ 24	, /*A:*/ 8.28603e-005	, /*B:*/ 10.9248	, /*SSE:*/ 467.321	, /*#:*/ 41 },
{ /*Age:*/ 25	, /*A:*/ 4.37048e-006	, /*B:*/ 13.4323	, /*SSE:*/ 730.24	, /*#:*/ 36 },
{ /*Age:*/ 26	, /*A:*/ 8.46015e-005	, /*B:*/ 10.932	, /*SSE:*/ 660.225	, /*#:*/ 37 },
{ /*Age:*/ 27	, /*A:*/ 9.41587e-005	, /*B:*/ 10.7992	, /*SSE:*/ 163.962	, /*#:*/ 28 },
{ /*Age:*/ 28	, /*A:*/ 2.81121e-005	, /*B:*/ 11.7392	, /*SSE:*/ 182.962	, /*#:*/ 39 },
{ /*Age:*/ 29	, /*A:*/ 4.09662e-005	, /*B:*/ 11.268	, /*SSE:*/ 501.287	, /*#:*/ 39 },
{ /*Age:*/ 30	, /*A:*/ 6.32659e-006	, /*B:*/ 12.9257	, /*SSE:*/ 54.1571	, /*#:*/ 37 },
{ /*Age:*/ 31	, /*A:*/ 1.73196e-005	, /*B:*/ 11.978	, /*SSE:*/ 290.732	, /*#:*/ 35 },
{ /*Age:*/ 32	, /*A:*/ 0.000101558	, /*B:*/ 10.4175	, /*SSE:*/ 1497.64	, /*#:*/ 32 },
{ /*Age:*/ 33	, /*A:*/ 3.95744e-007	, /*B:*/ 14.2531	, /*SSE:*/ 3.63338	, /*#:*/ 28 },
{ /*Age:*/ 34	, /*A:*/ 1.6396e-008	, /*B:*/ 17.7881	, /*SSE:*/ 112.034	, /*#:*/ 31 },
{ /*Age:*/ 35	, /*A:*/ 1.99653e-009	, /*B:*/ 19.1485	, /*SSE:*/ 22.871	, /*#:*/ 22 }, 
  };


    //Position: Forwards
    static double[,] _F = new double[21, 5] {
{ /*Age:*/ 15	, /*A:*/ 0.03227	,     /*B:*/ 4.99866	, /*SSE:*/ 2973.73	, /*#:*/ 68 },
{ /*Age:*/ 16	, /*A:*/ 3.9273e-006	, /*B:*/ 12.683	, /*SSE:*/ 5011.39	, /*#:*/ 44 },
{ /*Age:*/ 17	, /*A:*/ 3.27756e-005	, /*B:*/ 10.7455	, /*SSE:*/ 340.311	, /*#:*/ 37 },
{ /*Age:*/ 18	, /*A:*/ 9.93606e-006	, /*B:*/ 11.6704	, /*SSE:*/ 445.595	, /*#:*/ 42 },
{ /*Age:*/ 19	, /*A:*/ 0.000119979	, /*B:*/ 10.0007	, /*SSE:*/ 1121.08	, /*#:*/ 38 },
{ /*Age:*/ 20	, /*A:*/ 4.74701e-006	, /*B:*/ 12.587	, /*SSE:*/ 587.644	, /*#:*/ 40 },
{ /*Age:*/ 21	, /*A:*/ 0.000151526	, /*B:*/ 10.0066	, /*SSE:*/ 1234.71	, /*#:*/ 36 },
{ /*Age:*/ 22	, /*A:*/ 0.00027495	,   /*B:*/ 9.74545	, /*SSE:*/ 817.505	, /*#:*/ 34 },
{ /*Age:*/ 23	, /*A:*/ 8.30061e-005	, /*B:*/ 10.8732	, /*SSE:*/ 1160.01	, /*#:*/ 33 },
{ /*Age:*/ 24	, /*A:*/ 0.00365008	, /*B:*/ 7.62479	, /*SSE:*/ 1514.2	, /*#:*/ 35 },
{ /*Age:*/ 25	, /*A:*/ 0.000546022	, /*B:*/ 9.2296	, /*SSE:*/ 787.913	, /*#:*/ 33 },
{ /*Age:*/ 26	, /*A:*/ 0.00161525	, /*B:*/ 8.31671	, /*SSE:*/ 606.171	, /*#:*/ 30 },
{ /*Age:*/ 27	, /*A:*/ 0.000433449	, /*B:*/ 9.43674	, /*SSE:*/ 931.589	, /*#:*/ 33 },
{ /*Age:*/ 28	, /*A:*/ 9.67372e-005	, /*B:*/ 10.7193	, /*SSE:*/ 500.719	, /*#:*/ 34 },
{ /*Age:*/ 29	, /*A:*/ 7.79492e-005	, /*B:*/ 10.8388	, /*SSE:*/ 272.965	, /*#:*/ 35 },
{ /*Age:*/ 30	, /*A:*/ 0.000156725	, /*B:*/ 10.096	, /*SSE:*/ 339.159	, /*#:*/ 34 },
{ /*Age:*/ 31	, /*A:*/ 1.69044e-005	, /*B:*/ 12.1389	, /*SSE:*/ 460.218	, /*#:*/ 33 },
{ /*Age:*/ 32	, /*A:*/ 1.42896e-006	, /*B:*/ 14.3489	, /*SSE:*/ 822.041	, /*#:*/ 27 },
{ /*Age:*/ 33	, /*A:*/ 1.84883e-007	, /*B:*/ 15.3542	, /*SSE:*/ 9.41568	, /*#:*/ 25 },
{ /*Age:*/ 34	, /*A:*/ 6.51884e-008	, /*B:*/ 15.8031	, /*SSE:*/ 2.06848	, /*#:*/ 28 },
{ /*Age:*/ 35	, /*A:*/ 2.76552e-009	, /*B:*/ 18.5628	, /*SSE:*/ 8.34864	, /*#:*/ 20 }, 
  };



    //Position: Centers
    static double[,] _C = new double[21, 5] {
{ /*Age:*/ 15	, /*A:*/ 4.40723e-005	, /*B:*/ 10.0282	, /*SSE:*/ 6430.21	, /*#:*/ 60 },
{ /*Age:*/ 16	, /*A:*/ 0.000157438	, /*B:*/ 9.21784	, /*SSE:*/ 2672.98	, /*#:*/ 61 },
{ /*Age:*/ 17	, /*A:*/ 2.25118e-005	, /*B:*/ 11.3055	, /*SSE:*/ 1141.97	, /*#:*/ 45 },
{ /*Age:*/ 18	, /*A:*/ 0.000101763	, /*B:*/ 10.1031	, /*SSE:*/ 928.276	, /*#:*/ 50 },
{ /*Age:*/ 19	, /*A:*/ 5.9032e-005	, /*B:*/ 10.8252	, /*SSE:*/ 1804.01	, /*#:*/ 44 },
{ /*Age:*/ 20	, /*A:*/ 0.00135856	, /*B:*/ 8.318	, /*SSE:*/ 6183.26	, /*#:*/ 48 },
{ /*Age:*/ 21	, /*A:*/ 4.88493e-005	, /*B:*/ 11.1008	, /*SSE:*/ 4387.17	, /*#:*/ 44 },
{ /*Age:*/ 22	, /*A:*/ 0.00446795	, /*B:*/ 7.55489	, /*SSE:*/ 5720.3	, /*#:*/ 47 },
{ /*Age:*/ 23	, /*A:*/ 0.00146649	, /*B:*/ 8.60338	, /*SSE:*/ 2250.26	, /*#:*/ 41 },
{ /*Age:*/ 24	, /*A:*/ 0.00419381	, /*B:*/ 7.82198	, /*SSE:*/ 5960.64	, /*#:*/ 38 },
{ /*Age:*/ 25	, /*A:*/ 0.00168904	, /*B:*/ 8.49366	, /*SSE:*/ 1763.8	, /*#:*/ 38 },
{ /*Age:*/ 26	, /*A:*/ 0.000112573	, /*B:*/ 10.8091	, /*SSE:*/ 1270.83	, /*#:*/ 44 },
{ /*Age:*/ 27	, /*A:*/ 9.18203e-005	, /*B:*/ 10.8892	, /*SSE:*/ 426.542	, /*#:*/ 40 },
{ /*Age:*/ 28	, /*A:*/ 0.000197165	, /*B:*/ 10.3006	, /*SSE:*/ 784.787	, /*#:*/ 43 },
{ /*Age:*/ 29	, /*A:*/ 0.000152789	, /*B:*/ 10.4567	, /*SSE:*/ 119.188	, /*#:*/ 40 },
{ /*Age:*/ 30	, /*A:*/ 0.000598947	, /*B:*/ 9.0479	, /*SSE:*/ 331.61	, /*#:*/ 43 },
{ /*Age:*/ 31	, /*A:*/ 0.000146135	, /*B:*/ 10.2955	, /*SSE:*/ 301.632	, /*#:*/ 36 },
{ /*Age:*/ 32	, /*A:*/ 4.58206e-006	, /*B:*/ 13.1143	, /*SSE:*/ 87.2726	, /*#:*/ 37 },
{ /*Age:*/ 33	, /*A:*/ 1.53674e-006	, /*B:*/ 13.8646	, /*SSE:*/ 61.1645	, /*#:*/ 37 },
{ /*Age:*/ 34	, /*A:*/ 3.21515e-008	, /*B:*/ 16.6948	, /*SSE:*/ 5.05399	, /*#:*/ 31 },
{ /*Age:*/ 35	, /*A:*/ 9.14221e-008	, /*B:*/ 15.5075	, /*SSE:*/ 15.4099	, /*#:*/ 26 }, 
    };






  }


}
