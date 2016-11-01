using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Airbase
{
    public abstract class Plane
    {
        protected int runId;
        protected double[] size;
        protected int stability;
        protected double[] pos;
        protected int direct;
        protected bool broken;
        protected Image pic;
        protected Timer moveTimer;
        private int stepsCount;

        public int Stability
        {
            get
            {
                return stability;
            }
            set
            {
                stability = value;
            }
        }

        public double[] Size
        {
            get
            {
                return size;
            }
        }

        public double[] Pos
        {
            get
            {
                return pos;
            }
        }

        public int Direct
        {
            get
            {
                return direct;
            }
            set
            {
                direct = value;
            }
        }

        public Image Pic
        {
            get
            {
                return pic;
            }
        }

        protected abstract void BrokenPic();

        public void Move(Object source, ElapsedEventArgs e)
        {
            if (!CrashCheck() && !broken)
            {
                KeepRunwayMoving();
            }
            else if(!broken) Break();
            Delete();
        }

        private bool CrashCheck()
        {
            double[] frontPoint = GetFrontCoord();
            return Airfield.FindPlaneInPoint(frontPoint, this);
        }

        private void Break()
        {
            broken = true;
            BrokenPic();
            Airfield.RemovePoint();
        }

        private void LandingFailure()
        {
            Random rnd = new Random();
            int crashChance = rnd.Next(0, 100);
            if (crashChance > stability)
            {
                Break();
            }
        }
        private void KeepRunwayMoving()
        {
            if (stepsCount < Config.StepsForRunway)
            {
                    switch (direct)
                    {
                        case (Config.Right):
                            pos[Config.X] += Config.MovementStep;
                            stepsCount++;
                            break;
                        case (Config.Left):
                            pos[Config.X] -= Config.MovementStep;
                            stepsCount++;
                            break;
                        case (Config.Up):
                            pos[Config.Y] -= Config.MovementStep;
                            stepsCount++;
                            break;
                        case (Config.Down):
                            pos[Config.Y] += Config.MovementStep;
                            break;
                }
                if (stepsCount == Config.StepsForRunway / 2) LandingFailure();
            }
            else
            {
                stepsCount = 0;
                if (runId==0) direct = Config.Up;
                else if (runId == 1) direct = Config.Down;
            }
        }


        public double[] GetFrontCoord()
        {
            double[] frontCoord = new double[2];
            switch (direct)
            {
                case Config.Right:
                    frontCoord[Config.X] = pos[Config.X] + size[Config.X];
                    frontCoord[Config.Y] = pos[Config.Y] + size[Config.Y] /2;
                    break;
                case Config.Left:
                    frontCoord[Config.X] = pos[Config.X] - size[Config.X];
                    frontCoord[Config.X] = pos[Config.Y] - size[Config.Y] / 2;
                    break;
            }
            return frontCoord;
        }

        private void Delete()
        {
            if (!IsVisible() && !Airfield.drawing)
            {
                moveTimer.Stop();
                Airfield.planes.Remove(this);
                Airfield.AddPoint();
            }
        }
        private bool IsVisible()
        {
            try
            {
                if (pos[Config.X] + size[Config.X] < 0 || pos[Config.X] - size[Config.X] > Program.mainForm.width) return false;
                else if (pos[Config.Y] + size[Config.X] < 0 || pos[Config.Y] - size[Config.X] > Program.mainForm.height) return false;
                else return true;
            }
            catch
            {
                return true;
            }
        }
        public Plane(int runway, double x, double y)
        {
            runId = runway;
            pos = new double[2] { x, y };
            size = new double[2];
            stepsCount = 0;
            broken = false;
            moveTimer = new Timer(Config.UpdateInterval);
            moveTimer.AutoReset = true;
            moveTimer.Elapsed += Move;
            moveTimer.Start();
        }
    }
}
