using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lane> lineas = new List<Lane>();
            
            lineas.Add(new Lane(1, false, ConsoleColor.Green, false, false, 0, ' ', new List<ConsoleColor> {ConsoleColor.Green}));
            lineas.Add(new Lane(2, true, ConsoleColor.Blue, false, true, 0, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(3, true, ConsoleColor.Blue, false, true, 0, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(4, true, ConsoleColor.Blue, false, true, 0, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(5, true, ConsoleColor.Blue, false, true, 0, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(6, true, ConsoleColor.Blue, false, true, 0, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(7, false, ConsoleColor.Green, false, false, 0, ' ', new List<ConsoleColor> {ConsoleColor.Green}));
            lineas.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(12, false, ConsoleColor.Black, true, false, 0, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(13, false, ConsoleColor.Green, false, false, 0, ' ', new List<ConsoleColor> {ConsoleColor.Green}));

         

            while (true)
            {
                Input();
                Logic();
                foreach (Lane map in lineas)
                {
                    map.Draw();
                }
            }

            void Input()
            {
                
            }

            void Logic()
            {

            }
        }
    }
}
