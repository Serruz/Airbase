using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Airbase
{
    public class Way
    {
        protected double[] pos;
        protected double[] size;
        protected double[] planeStart;
        protected Image pic;

        public double[] Pos
        {
            get
            {
                return pos;
            }
        }

        public double[] Size
        {
            get
            {
                return size;
            }
        }

        public Image Pic
        {
            get
            {
                return pic;
            }
        }

        public virtual double[] GetStartPos()
        {
            return new double[2] { 0, 0 };
        }

        public Way(double x, double y)
        {
            pos = new double[2] { x, y };
            size = new double[2];
        }
    }
}
