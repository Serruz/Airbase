using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Airbase
{
    public class Foxhound : Plane
    {
        protected override void BrokenPic()
        {
            pic = Config.IFoxhoundBrokenPic;
        }
        public Foxhound(int runway, double x, double y) : base(runway, x, y)
        {
            this.stability = 90;
            pic = Config.IFoxhoundPic;
            this.size[Config.X] = Config.FoxhoundSize.Width;
            this.size[Config.Y] = Config.FoxhoundSize.Height;
        }
    }
}
