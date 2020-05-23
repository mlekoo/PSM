using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2
{
    class MomentInTime
    {
        public double gx { get; set; }
        public double gy { get; set; }

        public double dt { get; set; }
        public double xStartPos { get; set; }
        public double yStartPos { get; set; }

        public double xStartVel { get; set; }
        public double yStartVel { get; set; }

        public double dsx { get; set; }

        public double dsy { get; set; }
        public double dvx { get; set; }
        public double dvy { get; set; }
       

        public MomentInTime(double xStartPos,
                            double yStartPos,
                            double xStartVel,
                            double yStartVel,
                            double dsx,
                            double dsy,
                            double dvx,
                            double dvy,
                            double gx,
                            double gy,
                            double dt
                            )
        {
            this.xStartPos = xStartPos;
            this.yStartPos = yStartPos;
            this.xStartVel = xStartVel;
            this.yStartVel = yStartVel;
            this.dsx = dsx;
            this.dsy = dsy;
            this.dvx = dvx;
            this.dvy = dvy;
            this.gx = gx;
            this.gy = gy;
            this.dt = dt;
            

        }
        public MomentInTime(MomentInTime mit)
        {
            this.xStartPos = mit.xStartPos;
            this.yStartPos = mit.yStartPos;
            this.xStartVel = mit.xStartVel;
            this.yStartVel = mit.yStartVel;
            this.dsx = mit.dsx;
            this.dsy = mit.dsy;
            this.dvx = mit.dvx;
            this.dvy = mit.dvy;
            this.gx = mit.gx;
            this.gy = mit.gy;
            this.dt = mit.dt;


        }
        public MomentInTime getNewMoment() {
            
            double xStartPos = this.xStartPos + this.dsx;
            double yStartPos = this.yStartPos + this.dsy;
            double xStartVel = this.xStartVel + this.dvx;
            double yStartVel = this.yStartVel + this.dvy;
            double dsx = xStartVel * this.dt;
            double dsy = yStartVel * this.dt;
            double dvx = gx * this.dt;
            double dvy = gy * this.dt;                           
            return new MomentInTime(xStartPos,
                                    yStartPos,
                                    xStartVel,
                                    yStartVel,
                                    dsx,
                                    dsy,
                                    dvx,
                                    dvy,
                                    this.gx,
                                    this.gy,
                                    this.dt
                                    );
        }

        public override string ToString()
        {
           // Console.WriteLine($"{xStartPos} {yStartPos} {xStartVel} {yStartVel} {dsx} {dsy} {dvx} {dvy} ---------------------- {gx} {gy} {dt}");
            return $"{xStartPos} {yStartPos}";
        }
    }

}
