using System;

namespace Cw2
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Siła = Masa * Przyspieszenie");

            Console.WriteLine("F = m * a");
            double dt = 0.1;
            double gx = 0;
            double gy = -10;

            double xSTARTPOS = 0;
            double ySTARTPOS = 0;
            double xVELOCITY = 10;
            double yVELOCITY = 10;

            bool isLayingOnTheGround = false;

            MomentInTime mit = new MomentInTime(xSTARTPOS,ySTARTPOS,xVELOCITY,yVELOCITY,1,1,0,-1,gx,gy,dt);
            

            while (!isLayingOnTheGround) {

               
                
                mit = mit.getNewMoment();

                if (Math.Round(mit.yStartPos) <= ySTARTPOS) {
                    isLayingOnTheGround = true;

                }

                Console.WriteLine(mit.ToString());
               
            }
            


            


        }
    }
}
