using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Airbase
{
    public static class Config
    {
        public const int Left = 0;
        public const int Right = 1;
        public const int Down = 2;
        public const int Up = 3;

        public static int X = 0;
        public static int Y = 1;

        public static int UpdateInterval = 100;
        public static int FormHeight;
        public static int FormWidth;

        public static int CreatePlanesTimer = 7800;
        public static int MovementStep = 10;
        public static int NotViewed = 140;

        public static string RaptorPic = "Raptor.png";
        public static string FalconPic = "Falcon.png";
        public static string FoxhoundPic = "Foxhound.png";
        public static string FoxhoundBrokenPic = "FoxhoundBroken.png";
        public static string FalconBrokenPic = "FalconBroken.png";
        public static string RaptorBrokenPic = "RaptorBroken.png";
        public static string GroundPic = "Ground.png";
        public static string RunwayPic = "Runway.png";
        public static string TaxiwayPic = "Taxiway.png";

        public static Image IRaptorPic = Image.FromFile(RaptorPic);
        public static Image IFalconPic = Image.FromFile(FalconPic);
        public static Image IFoxhoundPic = Image.FromFile(FoxhoundPic);
        public static Image IFalconBrokenPic = Image.FromFile(FalconBrokenPic);
        public static Image IRaptorBrokenPic = Image.FromFile(RaptorBrokenPic);
        public static Image IFoxhoundBrokenPic = Image.FromFile(FoxhoundBrokenPic);
        public static Image IGroundPic = Image.FromFile(GroundPic);
        public static Image IRunwayPic = Image.FromFile(RunwayPic);
        public static Image ITaxiwayPic = Image.FromFile(TaxiwayPic);

        public static Size RunwaySize = Image.FromFile(RunwayPic).Size;
        public static Size RaptorSize = Image.FromFile(RaptorPic).Size;
        public static Size FalconSize = Image.FromFile(FalconPic).Size;
        public static Size FoxhoundSize = Image.FromFile(FoxhoundPic).Size;
        public static Size TaxiwaySize = Image.FromFile(TaxiwayPic).Size;


        public static int StepsForRunway = RunwaySize.Width / MovementStep;
        public static int StepsForTaxiway = RunwaySize.Height / MovementStep;
    }
}
