using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvagoReliabilityTest
{
    class PowerSolutionExt
    {
        #region Fields
        private double rbw;
        private double nbw;
        private double span;
        private double[] points;
        private double interval;
        private long numPoints;

        public double Rbw
        {
            get { return rbw; }
            set { rbw = value; }
        }
        public double Nbw
        {
            get { return nbw; }
            set { nbw = value; }
        }
        public double Span
        {
            get { return span; }
            set { span = value; }
        }
        public double[] Points
        {
            get { return points; }
            set { points = value; }
        }
        public double Interval
        {
            get { return interval; }
            set { interval = value; }
        }
        public long NumPoints
        {
            get { return numPoints; }
            set { numPoints = value; }
        }
        #endregion

        #region Contructors
        // Look at constructor below to figure out parameters.
        public PowerSolutionExt(
            double rbw,
            double nbw,
            double span,
            long numPoints,
            double[] points,
            bool dbmOrIQPairs
        )
        {
            this.rbw = rbw;
            this.nbw = nbw;
            this.span = span;
            // Convert pairs to dbm if in pairs, else just leave alone.
            if (dbmOrIQPairs)
            {
                this.points = points;
            }
            else
            {
                this.points = new double[points.Length >> 1];
                for (int i = 0; i < this.points.Length; i++)
                {
                    int pi = i << 1;
                    this.points[i] = 10 * Math.Log(points[pi] * points[pi] + points[pi + 1] * points[pi + 1]);
                }
            }
            this.interval = 0;
            this.numPoints = numPoints;
        }

        /// <summary>
        /// Constructor with all possible parameters.
        /// </summary>
        /// <param name="rbw"> Target resolution bandwidth; RBW of the equation. </param>
        /// <param name="nbw"> Noise band width, according to Bob generally a constant around 1.05 </param>
        /// <param name="span"> The frequency length of the signal being measured (frequency length of points). 
        ///                     The span MUST BE >= 1.0 </param>
        /// <param name="points"> The data points being integrated over. </param>
        /// <param name="dbmOrIQPairs"> True means points are coming in in dbm, false means IQ pairs. </param>
        /// <param name="interval"> The frequency length of a single bucket. </param>
        public PowerSolutionExt(
            double rbw,
            double nbw,
            double span,
            double[] points,
            bool dbmOrIQPairs,
            double interval,
            long numPoints
        )
        {
            this.rbw = rbw;
            this.nbw = nbw;
            this.span = span;
            // Convert pairs to dbm if in pairs, else just leave alone.
            if (dbmOrIQPairs)
            {
                this.points = points;
            }
            else
            {
                this.points = new double[points.Length >> 1];
                for (int i = 0; i < this.points.Length; i++)
                {
                    int pi = i << 1;
                    this.points[i] = 10 * Math.Log(points[pi] * points[pi] + points[pi + 1] * points[pi + 1]);
                }
            }
            this.interval = interval;
            this.numPoints = numPoints;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculates the integrated power for the entire span.
        /// </summary>
        public double getWholeSpanIntegratedPower()
        {
            return getSpanIntegratedPower(0, points.Length);
        }

        /// <summary>
        /// Gets the integrated power of an interval. Here, start and end refer to the indices in 
        /// the points array to integrate over.
        /// </summary>
        /// <param name="start"> Inclusive, starts from index start. </param>
        /// <param name="end"> Not inclusive, will not include the end-th point </param>
        /// <returns></returns>
        private double getSpanIntegratedPower(
            long start,
            long end
            )
        {
            double power = 10 * Math.Log10(span / (rbw * nbw * (numPoints - 1)));
            double summation = 0.0;
            for (long i = start; i < end; i++)
            {
                summation += Math.Pow(10, points[i] / 10);
            }
            return power + 10 * Math.Log10(summation);
        }
        #endregion
    }
}