using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Airbase
{
    public class DispatchTower
    {
        protected double[] pos;
        protected double[] size;
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

        private void Brake()
        {

        }

        private void NeedRepair()
        {
            Random rnd = new Random();
            int crashChance = rnd.Next(0, 100);
            if (crashChance > 80)
            {
                Brake();
            }
        }
    }
}
