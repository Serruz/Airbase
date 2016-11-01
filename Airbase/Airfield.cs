using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Airbase
{
    public static class Airfield
    {
        public static List<Plane> planes = new List<Plane>();
        public static Timer createVehicles = new Timer(Config.CreatePlanesTimer);
        public static bool startDrawing = false;
        public static Way[] runways = new Way[4];
        public static Random rand = new Random();
        public static bool drawing = false;
        public static int points { get; set; }

        public static int AddPoint()
        {
            points += 10;
            return points;
        }

        public static int RemovePoint()
        {
            points -= 5;
            return points;
        }
        public static void GenerateRunways()
        {
            runways[0] = new Runway(100, Config.TaxiwaySize.Height);
            runways[1] = new Runway(100, Config.TaxiwaySize.Height * 2);
            runways[2] = new Taxiway(Config.RunwaySize.Width*0.93,0);
            runways[3] = new Taxiway(Config.RunwaySize.Width*0.93, Config.TaxiwaySize.Height*2.55);
           
            createVehicles.AutoReset = true;
            createVehicles.Elapsed += CreatePlanes;
            createVehicles.Start();
        }
        public static void CreatePlanes(Object source, ElapsedEventArgs e)
        {
            int whereToCreate = rand.Next(2);
            Way whereToCreateRunway = runways[whereToCreate];
            double[] startPos = whereToCreateRunway.GetStartPos();
            int pType = rand.Next(3);
            Plane p;
            switch (pType)
            {
                case 0:
                    p = new Raptor(whereToCreate,startPos[Config.X], startPos[Config.Y]);
                    break;
                case 1:
                    p = new Falcon(whereToCreate,startPos[Config.X], startPos[Config.Y]);
                    break;
                case 2:
                default:
                    p = new Foxhound(whereToCreate, startPos[Config.X], startPos[Config.Y]);
                    break;
            }
            p.Direct = Config.Right;
            if (!drawing && !FindPlaneInPoint(p.GetFrontCoord(), p)) planes.Add(p);
        }
        public static bool FindPlaneInPoint(double[] pos, Plane current)
        {
            int i = 0;
            Plane veh;
            bool check = false;
            while (i < planes.Count && !check)
            {
                if (i < planes.Count)
                {
                    veh = planes[i];
                    if (veh != current)
                    {
                        switch (veh.Direct)
                        {
                            case Config.Up:
                                check = (InBounds(pos[Config.X], veh.Pos[Config.X], veh.Pos[Config.X] + veh.Size[Config.Y])) &&
                                    (InBounds(pos[Config.Y], veh.Pos[Config.Y], veh.Pos[Config.Y] - veh.Size[Config.X]));
                                break;
                            case Config.Down:
                                check = (InBounds(pos[Config.X], veh.Pos[Config.X], veh.Pos[Config.X] - veh.Size[Config.Y])) &&
                                     (InBounds(pos[Config.Y], veh.Pos[Config.Y], veh.Pos[Config.Y] + veh.Size[Config.X]));
                                break;
                            case Config.Left:
                                check = (InBounds(pos[Config.X], veh.Pos[Config.X], veh.Pos[Config.X] - veh.Size[Config.X])) &&
                                         (InBounds(pos[Config.Y], veh.Pos[Config.Y], veh.Pos[Config.Y] - veh.Size[Config.Y]));
                                break;
                            case Config.Right:
                                check = (InBounds(pos[Config.X], veh.Pos[Config.X], veh.Pos[Config.X] + veh.Size[Config.X])) &&
                                           (InBounds(pos[Config.Y], veh.Pos[Config.Y], veh.Pos[Config.Y] + veh.Size[Config.Y]));
                                break;
                        }
                    }
                }
                i++;
            }
            return check;
        }
        public static bool InBounds(double point, double first, double second)
        {
            return ((point >= first && point <= second) || (point >= second && point <= first));
        }
        public static void Draw(Graphics g)
        {
            g.Clear(Color.White);
            g.DrawImage(Config.IGroundPic, 0, 0);
            for (int i = 0; i < runways.Count(); i++)
            {
                g.DrawImage(runways[i].Pic, (float)runways[i].Pos[Config.X], (float)runways[i].Pos[Config.Y]);
            }
            drawing = true;
            foreach (Plane plane in planes)
            {
                g.TranslateTransform((float)plane.Pos[Config.X], (float)plane.Pos[Config.Y]);
                //g.DrawRectangle(Pens.Red, 0, 0, 10, 10);//надо закомментить
                switch (plane.Direct)
                {
                    case Config.Up:
                        g.RotateTransform(-90);
                        g.DrawImage(plane.Pic, 0, 0);
                        break;
                    case Config.Down:
                        g.RotateTransform(90);
                        g.DrawImage(plane.Pic, 0, 0);
                        break;
                    case Config.Left:
                        g.RotateTransform(180);
                        g.DrawImage(plane.Pic, 0, 0);
                        break;
                    case Config.Right:
                        g.RotateTransform(0);
                        g.DrawImage(plane.Pic, 0, 0);
                        break;
                }
                g.ResetTransform();
            }
            drawing = false;
            g.DrawString(planes.Count.ToString(), new Font("Arial", 16), Brushes.Black, 0, 0);
            g.DrawString(points.ToString(), new Font("Arial", 18), Brushes.Red, 250, 0);
        }
    }
}
