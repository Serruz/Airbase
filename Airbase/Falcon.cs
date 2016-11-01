using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Airbase
{
    public class Falcon : Plane
    {
        protected override void BrokenPic()
        {
            pic = Config.IFalconBrokenPic;
        }
        public Falcon(int runway, double x, double y) : base(runway, x, y)
        {
            this.stability = 75;
            pic = Config.IFalconPic;
            this.size[Config.X] = Config.FalconSize.Width;
            this.size[Config.Y] = Config.FalconSize.Height;
        }
    }
}
