using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Airbase
{
    public class Raptor : Plane
    {
        protected override void BrokenPic()
        {
            pic = Config.IRaptorBrokenPic;
        }
        public Raptor(int runway, double x, double y) : base(runway, x, y)
        {
            this.stability = 85;
            pic = Config.IRaptorPic;
            this.size[Config.X] = Config.RaptorSize.Width;
            this.size[Config.Y] = Config.RaptorSize.Height;
        }
    }
}
