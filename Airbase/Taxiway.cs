using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


namespace Airbase
{
    public class Taxiway : Way
    {
        public override double[] GetStartPos()
        {
            return new double[2] { planeStart[Config.X], planeStart[Config.Y] };
        }

        public Taxiway(double x, double y) : base(x, y)
        {
            pic = Config.ITaxiwayPic;
            this.size[Config.X] = Config.TaxiwaySize.Width;
            this.size[Config.Y] = Config.TaxiwaySize.Height;
            planeStart = new double[2];
            planeStart[Config.X] = pos[Config.X] - Config.NotViewed;
            planeStart[Config.Y] = pos[Config.Y] + Config.TaxiwaySize.Height / 2;
        }
    }
}
