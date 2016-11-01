using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Airbase
{
    public class Runway : Way
    {
        public override double[] GetStartPos()
        {
            return new double[2] { planeStart[Config.X], planeStart[Config.Y] };
        }


        public Runway(double x, double y) : base(x, y)
        {
            pic = Config.IRunwayPic;
            this.size[Config.X] = Config.RunwaySize.Width;
            this.size[Config.Y] = Config.RunwaySize.Height;
            planeStart = new double[2];
            planeStart[Config.X] = pos[Config.X] - Config.NotViewed;
            planeStart[Config.Y] = pos[Config.Y] + Config.RunwaySize.Height / 4;
        }

    }


}