

namespace AndreiPopescu.CharazayPlus.Extensions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AndreiPopescu.CharazayPlus.Utils;
    using AndreiPopescu.CharazayPlus.Model;

    internal static class PlayerExtensions
    {
        #region assessed total player values

        /// <summary>
        /// stored values of player Development from age 15 to 32
        /// each week with training contribution, meaning 289 weeks of training
        /// </summary>
        internal static double[] StoredAssessedValues = new double[]
    {
     
   4.78     //4.81	4.63	4.80	4.82	4.86	
  ,4.93     //4.96	4.77	4.94	4.96	5.00	
  ,5.02     //5.07	4.86	5.03	5.05	5.10	
  ,5.11     //5.17	4.94	5.12	5.14	5.18	
  ,5.18     //5.27	5.02	5.18	5.18	5.24	
  ,5.24     //5.34	5.09	5.25	5.22	5.29	
  ,5.30     //5.41	5.15	5.31	5.29	5.34	
  ,5.35     //5.48	5.21	5.34	5.35	5.39	
  ,5.43     //5.55	5.26	5.43	5.41	5.50	
  ,5.51     //5.61	5.30	5.51	5.51	5.61	
  ,5.60     //5.68	5.38	5.59	5.61	5.72	
  ,5.68     //5.74	5.45	5.68	5.71	5.82	
  ,5.76     //5.82	5.53	5.74	5.80	5.89	
  ,5.82     //5.90	5.60	5.80	5.85	5.95	
  ,5.89     //5.98	5.71	5.84	5.91	6.01	
  ,5.96     //6.06	5.81	5.90	5.96	6.08	
  ,6.02     //6.12	5.86	5.96	6.01	6.14	
  ,6.06     //6.15	5.89	6.00	6.07	6.19	
  ,6.13     //6.23	5.95	6.07	6.13	6.26	
  ,6.20     //6.32	6.02	6.13	6.20	6.32	
  ,6.27     //6.40	6.08	6.20	6.27	6.39	
  ,6.32     //6.48	6.14	6.25	6.30	6.43	
  ,6.36     //6.53	6.19	6.30	6.32	6.47	
  ,6.41     //6.59	6.24	6.35	6.38	6.51	
  ,6.46     //6.65	6.30	6.37	6.43	6.55	
  ,6.52     //6.71	6.33	6.45	6.48	6.65	
  ,6.60     //6.77	6.37	6.52	6.57	6.75	
  ,6.67     //6.82	6.44	6.60	6.66	6.84	
  ,6.75     //6.88	6.51	6.67	6.75	6.94	
  ,6.82     //6.95	6.57	6.73	6.84	7.00	
  ,6.88     //7.03	6.64	6.78	6.89	7.06	
  ,6.94     //7.10	6.73	6.82	6.93	7.12	
  ,7.00     //7.17	6.82	6.88	6.98	7.17	
  ,7.06     //7.23	6.88	6.93	7.02	7.23	
  ,7.09     //7.24	6.93	6.94	7.08	7.27	
  ,7.16     //7.32	7.00	7.00	7.14	7.34	
  ,7.22     //7.39	7.06	7.06	7.20	7.40	
  ,7.29     //7.47	7.11	7.12	7.27	7.46	
  ,7.33     //7.54	7.17	7.17	7.29	7.50	
  ,7.38     //7.60	7.22	7.21	7.32	7.54	
  ,7.42     //7.65	7.27	7.26	7.37	7.57	
  ,7.47     //7.71	7.32	7.28	7.42	7.61	
  ,7.53     //7.76	7.35	7.35	7.47	7.70	
  ,7.59     //7.82	7.38	7.42	7.55	7.80	
  ,7.67     //7.87	7.45	7.49	7.64	7.89	
  ,7.74     //7.92	7.51	7.56	7.72	7.98	
  ,7.81     //7.99	7.58	7.62	7.80	8.04	
  ,7.86     //8.06	7.64	7.67	7.85	8.09	
  ,7.92     //8.13	7.73	7.70	7.89	8.15	
  ,7.98     //8.20	7.81	7.75	7.94	8.20	
  ,8.03     //8.25	7.87	7.80	7.98	8.25	
  ,8.07     //8.28	7.92	7.84	8.03	8.30	
  ,8.13     //8.35	7.98	7.89	8.09	8.35	
  ,8.19     //8.42	8.03	7.95	8.14	8.41	
  ,8.24     //8.48	8.08	8.00	8.20	8.46	
  ,8.29     //8.55	8.13	8.04	8.22	8.50	
  ,8.33     //8.60	8.18	8.08	8.24	8.53	
  ,8.37     //8.65	8.22	8.12	8.28	8.56	
  ,8.40     //8.69	8.26	8.14	8.33	8.59	
  ,8.46     //8.74	8.29	8.21	8.37	8.68	
  ,8.52     //8.79	8.32	8.27	8.45	8.76	
  ,8.58     //8.84	8.38	8.33	8.52	8.84	
  ,8.65     //8.89	8.44	8.39	8.60	8.92	
  ,8.70     //8.95	8.49	8.44	8.67	8.97	
  ,8.76     //9.01	8.55	8.49	8.71	9.02	
  ,8.80     //9.07	8.63	8.52	8.72	9.05	
  ,8.85     //9.13	8.70	8.56	8.76	9.09	
  ,8.89     //9.17	8.75	8.61	8.80	9.14	
  ,8.93     //9.20	8.80	8.64	8.84	9.17	
  ,8.99     //9.27	8.85	8.69	8.89	9.23	
  ,9.04     //9.33	8.90	8.74	8.94	9.28	
  ,9.09     //9.40	8.95	8.79	9.00	9.33	
  ,9.14     //9.46	9.00	8.83	9.02	9.37	
  ,9.17     //9.51	9.04	8.87	9.04	9.40	
  ,9.21     //9.55	9.08	8.91	9.08	9.43	
  ,9.25     //9.60	9.12	8.93	9.12	9.46	
  ,9.30     //9.64	9.15	8.99	9.17	9.54	
  ,9.36     //9.69	9.18	9.05	9.24	9.62	
  ,9.42     //9.73	9.23	9.11	9.31	9.70	
  ,9.48     //9.78	9.29	9.17	9.38	9.77	
  ,9.53     //9.84	9.34	9.21	9.45	9.82	
  ,9.58     //9.90	9.40	9.26	9.49	9.87	
  ,9.63     //9.96	9.47	9.29	9.53	9.91	
  ,9.68     //10.01	9.54	9.33	9.56	9.96	
  ,9.72     //10.06	9.59	9.37	9.60	10.00	
  ,9.76     //10.09	9.64	9.40	9.64	10.03	
  ,9.81     //10.15	9.68	9.45	9.69	10.09	
  ,9.86     //10.21	9.73	9.50	9.74	10.14	
  ,9.92     //10.27	9.78	9.55	9.79	10.19	
  ,9.95     //10.32	9.82	9.59	9.81	10.22	
  ,9.99     //10.37	9.86	9.62	9.83	10.25	
  ,10.02    //10.41	9.90	9.66	9.87	10.27	
  ,10.06    //10.46	9.94	9.67	9.91	10.30	
  ,10.10    //10.50	9.96	9.73	9.95	10.38	
  ,10.16    //10.54	9.99	9.79	10.02	10.45	
  ,10.22    //10.58	10.04	9.85	10.08	10.53	
  ,10.28    //10.63	10.10	9.90	10.15	10.60	
  ,10.33    //10.68	10.15	9.94	10.22	10.64	
  ,10.37    //10.74	10.20	9.99	10.25	10.69	
  ,10.41    //10.79	10.23	10.01	10.29	10.73	
  ,10.46    //10.85	10.29	10.06	10.32	10.77	
  ,10.50    //10.89	10.34	10.10	10.36	10.82	
  ,10.54    //10.92	10.39	10.12	10.40	10.85	
  ,10.58    //10.97	10.44	10.17	10.44	10.90	
  ,10.63    //11.03	10.48	10.22	10.49	10.94	
  ,10.68    //11.09	10.53	10.27	10.54	10.99	
  ,10.72    //11.14	10.57	10.30	10.56	11.02	
  ,10.75    //11.19	10.61	10.33	10.58	11.05	
  ,10.79    //11.23	10.65	10.37	10.61	11.08	
  ,10.82    //11.27	10.68	10.39	10.65	11.10	
  ,10.86    //11.31	10.71	10.44	10.69	11.17	
  ,10.92    //11.35	10.73	10.49	10.76	11.25	
  ,10.97    //11.39	10.78	10.55	10.82	11.32	
  ,11.03    //11.43	10.83	10.60	10.89	11.39	
  ,11.08    //11.49	10.88	10.64	10.95	11.43	
  ,11.12    //11.54	10.93	10.68	10.98	11.47	
  ,11.16    //11.59	10.99	10.71	11.02	11.51	
  ,11.21    //11.65	11.05	10.75	11.05	11.55	
  ,11.25    //11.68	11.10	10.79	11.08	11.59	
  ,11.28    //11.71	11.15	10.82	11.12	11.62	
  ,11.33    //11.76	11.19	10.86	11.16	11.67	
  ,11.37    //11.81	11.23	10.90	11.21	11.71	
  ,11.41    //11.86	11.27	10.94	11.25	11.75	
  ,11.45    //11.91	11.31	10.97	11.27	11.78	
  ,11.47    //11.95	11.34	11.00	11.28	11.80	
  ,11.51    //11.99	11.38	11.03	11.32	11.83	
  ,11.54    //12.03	11.41	11.05	11.35	11.85	
  ,11.58    //12.06	11.43	11.10	11.38	11.92	
  ,11.62    //12.10	11.45	11.15	11.44	11.98	
  ,11.68    //12.14	11.50	11.20	11.50	12.04	
  ,11.72    //12.17	11.54	11.24	11.56	12.11	
  ,11.77    //12.22	11.59	11.28	11.61	12.14	
  ,11.81    //12.27	11.63	11.32	11.64	12.18	
  ,11.84    //12.31	11.68	11.34	11.67	12.22	
  ,11.88    //12.36	11.73	11.38	11.70	12.25	
  ,11.92    //12.40	11.78	11.41	11.73	12.29	
  ,11.95    //12.42	11.83	11.44	11.77	12.31	
  ,12.00    //12.47	11.86	11.48	11.81	12.36	
  ,12.04    //12.52	11.90	11.52	11.85	12.40	
  ,12.08    //12.57	11.94	11.56	11.89	12.44	
  ,12.11    //12.61	11.98	11.59	11.91	12.46	
  ,12.14    //12.65	12.01	11.62	11.92	12.49	
  ,12.17    //12.69	12.04	11.65	11.95	12.51	
  ,12.20    //12.72	12.07	11.66	11.99	12.54	
  ,12.24    //12.76	12.09	11.71	12.02	12.60	
  ,12.28    //12.79	12.12	11.75	12.08	12.66	
  ,12.33    //12.83	12.16	11.80	12.13	12.72	
  ,12.37    //12.86	12.20	11.84	12.19	12.78	
  ,12.42    //12.91	12.24	11.88	12.24	12.81	
  ,12.46    //12.95	12.29	11.92	12.27	12.85	
  ,12.49    //13.00	12.34	11.94	12.30	12.88	
  ,12.53    //13.04	12.39	11.97	12.33	12.92	
  ,12.56    //13.08	12.43	12.01	12.35	12.95	
  ,12.59    //13.10	12.47	12.03	12.39	12.98	
  ,12.63    //13.14	12.51	12.07	12.42	13.01	
  ,12.67    //13.18	12.54	12.10	12.46	13.05	
  ,12.70    //13.23	12.57	12.14	12.49	13.09	
  ,12.73    //13.27	12.61	12.16	12.51	13.11	
  ,12.76    //13.30	12.64	12.19	12.52	13.13	
  ,12.78    //13.33	12.66	12.21	12.55	13.15	
  ,12.81    //13.36	12.69	12.23	12.58	13.17	
  ,12.84    //13.39	12.71	12.27	12.61	13.23	
  ,12.88    //13.42	12.73	12.31	12.66	13.28	
  ,12.92    //13.45	12.77	12.35	12.71	13.33	
  ,12.95    //13.47	12.80	12.33	12.75	13.38	
  ,12.98    //13.51	12.84	12.36	12.80	13.41	
  ,13.02    //13.55	12.88	12.40	12.83	13.44	
  ,13.05    //13.59	12.92	12.42	12.85	13.47	
  ,13.08    //13.62	12.96	12.44	12.88	13.50	
  ,13.11    //13.65	13.00	12.47	12.90	13.53	
  ,13.14    //13.68	13.04	12.49	12.93	13.56	
  ,13.17    //13.71	13.07	12.53	12.96	13.59	
  ,13.20    //13.75	13.10	12.56	12.99	13.62	
  ,13.24    //13.79	13.13	12.59	13.03	13.66	
  ,13.26    //13.83	13.16	12.61	13.04	13.68	
  ,13.29    //13.86	13.19	12.64	13.05	13.70	
  ,13.31    //13.89	13.21	12.66	13.08	13.72	
  ,13.33    //13.91	13.24	12.67	13.11	13.73	
  ,13.36    //13.94	13.25	12.71	13.13	13.78	
  ,13.40    //13.97	13.27	12.75	13.18	13.83	
  ,13.44    //14.00	13.31	12.78	13.22	13.88	
  ,13.47    //14.02	13.34	12.82	13.26	13.92	
  ,13.51    //14.06	13.37	12.85	13.30	13.95	
  ,13.54    //14.10	13.41	12.88	13.33	13.98	
  ,13.56    //14.13	13.44	12.89	13.35	14.01	
  ,13.59    //14.17	13.48	12.92	13.37	14.03	
  ,13.62    //14.19	13.52	12.94	13.39	14.06	
  ,13.64    //14.21	13.55	12.96	13.42	14.08	
  ,13.68    //14.25	13.58	12.99	13.45	14.11	
  ,13.71    //14.28	13.61	13.03	13.48	14.14	
  ,13.74    //14.32	13.64	13.06	13.51	14.17	
  ,13.77    //14.36	13.67	13.08	13.53	14.19	
  ,13.78    //14.38	13.69	13.10	13.54	14.21	
  ,13.81    //14.41	13.72	13.12	13.56	14.23	
  ,13.83    //14.44	13.74	13.14	13.59	14.25	
  ,13.86    //14.46	13.76	13.17	13.61	14.29	
  ,13.89    //14.49	13.77	13.20	13.66	14.34	
  ,13.93    //14.52	13.80	13.24	13.70	14.38	
  ,13.96    //14.54	13.84	13.27	13.74	14.43	
  ,14.00    //14.58	13.87	13.30	13.78	14.45	
  ,14.02    //14.61	13.90	13.33	13.80	14.48	
  ,14.05    //14.64	13.94	13.34	13.82	14.51	
  ,14.08    //14.68	13.97	13.37	13.84	14.53	
  ,14.10    //14.70	14.01	13.39	13.86	14.56	
  ,14.13    //14.72	14.04	13.41	13.89	14.58	
  ,14.16    //14.76	14.07	13.44	13.92	14.61	
  ,14.19    //14.79	14.10	13.47	13.95	14.64	
  ,14.22    //14.82	14.12	13.50	13.98	14.67	
  ,14.24    //14.86	14.15	13.52	13.99	14.69	
  ,14.26    //14.88	14.17	13.54	14.00	14.70	
  ,14.28    //14.91	14.19	13.56	14.03	14.72	
  ,14.31    //14.94	14.22	13.58	14.05	14.74	
  ,14.33    //14.96	14.23	13.61	14.07	14.78	
  ,14.36    //14.99	14.25	13.64	14.11	14.83	
  ,14.40    //15.01	14.28	13.67	14.15	14.87	
  ,14.43    //15.04	14.31	13.71	14.19	14.91	
  ,14.46    //15.07	14.34	13.73	14.23	14.94	
  ,14.49    //15.10	14.37	13.76	14.25	14.96	
  ,14.51    //15.13	14.41	13.78	14.27	14.98	
  ,14.54    //15.16	14.44	13.80	14.29	15.01	
  ,14.56    //15.19	14.47	13.82	14.31	15.03	
  ,14.59    //15.21	14.51	13.84	14.34	15.05	
  ,14.62    //15.24	14.53	13.87	14.36	15.08	
  ,14.64    //15.27	14.55	13.89	14.39	15.11	
  ,14.67    //15.30	14.58	13.92	14.41	15.13	
  ,14.69    //15.33	14.60	13.94	14.42	15.15	
  ,14.70    //15.35	14.62	13.95	14.43	15.16	
  ,14.72    //15.37	14.64	13.97	14.46	15.18	
  ,14.74    //15.39	14.66	13.98	14.48	15.19	
  ,14.77    //15.42	14.67	14.01	14.50	15.23	
  ,14.79    //15.44	14.69	14.04	14.53	15.27	
  ,14.82    //15.46	14.72	14.07	14.56	15.30	
  ,14.85    //15.48	14.74	14.10	14.60	15.34	
  ,14.88    //15.51	14.77	14.12	14.63	15.36	
  ,14.90    //15.54	14.79	14.14	14.65	15.38	
  ,14.92    //15.56	14.82	14.16	14.67	15.40	
  ,14.95    //15.59	14.85	14.18	14.68	15.43	
  ,14.97    //15.61	14.88	14.20	14.70	15.45	
  ,14.99    //15.63	14.91	14.21	14.72	15.46	
  ,15.01    //15.66	14.93	14.24	14.75	15.49	
  ,15.03    //15.68	14.95	14.26	14.77	15.51	
  ,15.06    //15.71	14.98	14.28	14.79	15.54	
  ,15.08    //15.74	15.00	14.30	14.81	15.55	
  ,15.10    //15.76	15.02	14.32	14.82	15.57	
  ,15.12    //15.78	15.04	14.34	14.84	15.58	
  ,15.13    //15.80	15.05	14.35	14.86	15.60	
  ,15.15    //15.82	15.07	14.37	14.88	15.63	
  ,15.18    //15.84	15.08	14.40	14.91	15.67	
  ,15.21    //15.86	15.11	14.43	14.94	15.70	
  ,15.23    //15.88	15.13	14.45	14.97	15.73	
  ,15.26    //15.91	15.16	14.47	15.00	15.75	
  ,15.28    //15.94	15.18	14.50	15.02	15.77	
  ,15.30    //15.96	15.21	14.51	15.03	15.79	
  ,15.32    //15.99	15.24	14.53	15.05	15.81	
  ,15.34    //16.01	15.26	14.55	15.07	15.83	
  ,15.36    //16.02	15.29	14.56	15.09	15.85	
  ,15.38    //16.05	15.31	14.58	15.11	15.87	
  ,15.40    //16.07	15.33	14.60	15.13	15.89	
  ,15.42    //16.09	15.34	14.62	15.15	15.91	
  ,15.44    //16.11	15.36	14.64	15.16	15.92	
  ,15.45    //16.13	15.38	14.65	15.16	15.93	
  ,15.47    //16.15	15.39	14.67	15.18	15.95	
  ,15.48    //16.16	15.41	14.67	15.20	15.96	
  ,15.50    //16.18	15.42	14.70	15.21	15.99	
  ,15.52    //16.20	15.43	14.72	15.24	16.01	
  ,15.54    //16.21	15.45	14.74	15.26	16.04	
  ,15.56    //16.23	15.47	14.76	15.29	16.07	
  ,15.58    //16.25	15.49	14.78	15.31	16.08	
  ,15.60    //16.27	15.51	14.79	15.32	16.10	
  ,15.62    //16.29	15.53	14.81	15.34	16.12	
  ,15.63    //16.31	15.55	14.82	15.35	16.13	
  ,15.65    //16.33	15.57	14.84	15.37	16.15	
  ,15.67    //16.34	15.60	14.85	15.38	16.16	
  ,15.68    //16.36	15.61	14.87	15.40	16.18	
  ,15.70    //16.38	15.63	14.88	15.42	16.20	
  ,15.72    //16.40	15.64	14.90	15.44	16.22	
  ,15.74    //16.42	15.66	14.92	15.45	16.23	
  ,15.75    //16.44	15.68	14.93	15.45	16.24	
  ,15.76    //16.45	15.69	14.94	15.47	16.25	
  ,15.77    //16.47	15.70	14.95	15.48	16.26	
  ,15.79    //16.48	15.71	14.97	15.50	16.29	
  ,15.81    //16.50	15.73	14.99	15.52	16.31	
  ,15.83    //16.52	15.74	15.01	15.54	16.34	
  ,15.85    //16.53	15.76	15.03	15.57	16.36	
  ,15.87    //16.55	15.78	15.04	15.59	16.38	
  ,15.88    //16.57	15.80	15.06	15.60	16.39	
  ,15.90    //16.59	15.82	15.07	15.61	16.41	
  ,15.92    //16.61	15.84	15.08	15.63	16.42	
  ,15.93    //16.62	15.86	15.10	15.64	16.43	
    };

        #endregion

        static ST_PlayerPositionEnum GetPositionFromQualitativePositionHeight(QualitativePositionHeight qph)
        {
            switch (qph)
            {
                case QualitativePositionHeight.ShortPG:
                case QualitativePositionHeight.BelowAveragePG:
                case QualitativePositionHeight.AboveAveragePG:
                case QualitativePositionHeight.TallPG:
                    return ST_PlayerPositionEnum.PG;

                case QualitativePositionHeight.ShortSG:
                case QualitativePositionHeight.BelowAverageSG:
                case QualitativePositionHeight.AboveAverageSG:
                case QualitativePositionHeight.TallSG:
                    return ST_PlayerPositionEnum.SG;

                case QualitativePositionHeight.ShortSF:
                case QualitativePositionHeight.BelowAverageSF:
                case QualitativePositionHeight.AboveAverageSF:
                case QualitativePositionHeight.TallSF:
                    return ST_PlayerPositionEnum.SF;

                case QualitativePositionHeight.ShortPF:
                case QualitativePositionHeight.BelowAveragePF:
                case QualitativePositionHeight.AboveAveragePF:
                case QualitativePositionHeight.TallPF:
                    return ST_PlayerPositionEnum.PF;

                case QualitativePositionHeight.ShortC:
                case QualitativePositionHeight.BelowAverageC:
                case QualitativePositionHeight.AboveAverageC:
                case QualitativePositionHeight.TallC:
                    return ST_PlayerPositionEnum.C;

                default:
                    return ST_PlayerPositionEnum.Unknown;
            }
        }

        /// <summary>
        /// Method gets most adequate <see cref="PlayerPosition"/> based on height
        /// by balancing position height averages
        /// </summary>
        /// <param name="Height">player height</param>
        /// <returns>most adequate player position</returns>
        public static ST_PlayerPositionEnum MostAdequatePositionForHeight(byte Height)
        {
            if (Height < Defines.AverageHeightPg)
                return ST_PlayerPositionEnum.PG;
            else
            {
                if (Height < Defines.AverageHeightSg)
                {
                    return Math.Abs(Height - Defines.AverageHeightPg) < Math.Abs(Height - Defines.AverageHeightSg) ? ST_PlayerPositionEnum.PG : ST_PlayerPositionEnum.SG;
                }
                else
                {
                    if (Height < Defines.AverageHeightSf)
                    {
                        return Math.Abs(Height - Defines.AverageHeightSg) < Math.Abs(Height - Defines.AverageHeightSf) ? ST_PlayerPositionEnum.SG : ST_PlayerPositionEnum.SF;
                    }
                    else
                    {
                        if (Height < Defines.AverageHeightPf)
                        {
                            return Math.Abs(Height - Defines.AverageHeightSf) < Math.Abs(Height - Defines.AverageHeightPf) ? ST_PlayerPositionEnum.SF : ST_PlayerPositionEnum.PF;
                        }
                        else
                        {
                            if (Height < Defines.AverageHeightC)
                            {
                                return Math.Abs(Height - Defines.AverageHeightPf) < Math.Abs(Height - Defines.AverageHeightC) ? ST_PlayerPositionEnum.PF : ST_PlayerPositionEnum.C;
                            }
                            else return ST_PlayerPositionEnum.C;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static List<ST_PlayerPositionEnum> MostAdequatePositionsForAgeAndHeight(byte Age, byte Height)
        {
            var list = new List<ST_PlayerPositionEnum>();
            if (Age < 18)
            {
                list.Add(MostAdequatePositionForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseMin)));
                list.Add(MostAdequatePositionForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseAvg)));
                list.Add(MostAdequatePositionForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseMax)));
            }
            else
            {
                list.Add(MostAdequatePositionForHeight(Height));
            }
            return list.Distinct().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static IEnumerable<QualitativePositionHeight> QualitativePositionsForHeight(byte Height)
        {
            if (Height < Defines.MinHeightPg) yield return QualitativePositionHeight.ShortPG;
            else if (Height >= Defines.MinHeightPg && Height < Defines.AverageHeightPg)
            {
                yield return QualitativePositionHeight.BelowAveragePG;
                yield return QualitativePositionHeight.ShortSG;
            }
            else if (Height >= Defines.AverageHeightPg && Height < Defines.MinHeightSg)
            {
                yield return QualitativePositionHeight.AboveAveragePG;
                yield return QualitativePositionHeight.ShortSG;
            }
            else if (Height >= Defines.MinHeightSg && Height < Defines.AverageHeightSg)
            {
                yield return QualitativePositionHeight.AboveAveragePG;
                yield return QualitativePositionHeight.BelowAverageSG;
            }
            else if (Height >= Defines.AverageHeightSg && Height < Defines.MinHeightSf)
            {
                yield return QualitativePositionHeight.TallPG;
                yield return QualitativePositionHeight.AboveAverageSG;
                yield return QualitativePositionHeight.ShortSF;
            }
            else if (Height >= Defines.MinHeightSf && Height < Defines.AverageHeightSf)
            {
                yield return QualitativePositionHeight.TallSG;
                yield return QualitativePositionHeight.BelowAverageSF;
            }
            else if (Height >= Defines.AverageHeightSf && Height < Defines.MaxHeightSf /* == Defines.MinHeightC*/ )
            {
                yield return QualitativePositionHeight.AboveAverageSF;
                yield return QualitativePositionHeight.BelowAveragePF;
                yield return QualitativePositionHeight.ShortC;
            }
            else if (Height >= Defines.MaxHeightSf && Height < Defines.AverageHeightPf)
            {
                yield return QualitativePositionHeight.TallSF;
                yield return QualitativePositionHeight.BelowAveragePF;
                yield return QualitativePositionHeight.BelowAverageC;
            }
            else if (Height >= Defines.AverageHeightPf && Height < Defines.MaxHeightPf)
            {
                yield return QualitativePositionHeight.TallSF;
                yield return QualitativePositionHeight.AboveAveragePF;
                yield return QualitativePositionHeight.BelowAverageC;
            }
            else if (Height >= Defines.MaxHeightPf && Height < Defines.MaxHeightC)
            {
                yield return QualitativePositionHeight.TallPF;
                yield return QualitativePositionHeight.AboveAverageC;
            }
            else yield return QualitativePositionHeight.TallC;
        }

        public static IEnumerable<QualitativePositionHeight> QualitativePositionsForAgeAndHeight(byte Age, byte Height)
        {
            if (Age < 18)
            {
                var lo = QualitativePositionsForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseMin));
                var avg = QualitativePositionsForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseAvg));
                var hi = QualitativePositionsForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseMax));
                foreach (var qph in lo.Union(avg).Union(hi).Distinct())
                    yield return qph;
            }
            else
                foreach (var qph in QualitativePositionsForHeight(Height))
                    yield return qph;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static IEnumerable<ST_PlayerPositionEnum> PotentialPositionsForHeight(byte Height)
        {
            return QualitativePositionsForHeight(Height).Select(qph => GetPositionFromQualitativePositionHeight(qph));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static IEnumerable<ST_PlayerPositionEnum> PotentialPositionsForAgeAndHeight(byte Age, byte Height)
        {
            if (Age < 18)
            {
                var lo = PotentialPositionsForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseMin));
                var avg = PotentialPositionsForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseAvg));
                var hi = PotentialPositionsForHeight((byte)(Height + (18 - Age) * Defines.HeighRaiseMax));
                foreach (var pos in lo.Union(avg).Union(hi).Distinct())
                    yield return pos;
            }
            else
                foreach (var pos in PotentialPositionsForHeight(Height))
                    yield return pos;
        }

        /// <summary>
        /// Best position for a player based on total score
        /// </summary>
        /// <param name="pg">PG aspect</param>
        /// <param name="sg">SG Aspect</param>
        /// <param name="sf">SF aspect</param>
        /// <param name="pf">PF aspect</param>
        /// <param name="M">C aspect</param>
        /// <returns></returns>
        public static Player DecideOnTotalScore(PG pg, SG sg, SF sf, PF pf, C c)
        {
            double maxTotalScore = pg.TotalScore;
            Player p = pg;

            if (sg.TotalScore > maxTotalScore)
            {
                p = sg;
                maxTotalScore = sg.TotalScore;
            }

            if (sf.TotalScore > maxTotalScore)
            {
                p = sf;
                maxTotalScore = sf.TotalScore;
            }

            if (pf.TotalScore > maxTotalScore)
            {
                p = pf;
                maxTotalScore = pf.TotalScore;
            }

            if (c.TotalScore > maxTotalScore)
            {
                p = c;
                maxTotalScore = c.TotalScore;
            }

            return p;
        }

        /// <summary>
        /// Best position for a player based on total score
        /// </summary>
        /// <param name="players">player pool</param>
        /// <returns>player whose total score is max</returns>
        public static Player DecideOnTotalScore(IEnumerable<Player> players)
        {
            double maxTotalScore = 0;
            Player pmax = null;

            foreach (var p in players)
            {
                if (p.TotalScore > maxTotalScore)
                {
                    pmax = p;
                    maxTotalScore = p.TotalScore;
                }
            }
            return pmax;
        }

    }
}
