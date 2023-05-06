using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using static M05_UF3_P3_Frogger.Program;
using static M05_UF3_P3_Frogger.Utils;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utils.GAME_STATE estado = Utils.GAME_STATE.RUNNING;

            List<Lane> lineas = new List<Lane>();

            lineas.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0, ' ', new List<ConsoleColor> { ConsoleColor.DarkGreen }));
            lineas.Add(new Lane(1, true, ConsoleColor.Blue, false, true, 0.5f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(2, true, ConsoleColor.Blue, false, true, 0.4f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(3, true, ConsoleColor.Blue, false, true, 0.4f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(4, true, ConsoleColor.Blue, false, true, 0.5f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(5, true, ConsoleColor.Blue, false, true, 0.5f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lineas.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0, ' ', new List<ConsoleColor> { ConsoleColor.DarkGreen }));
            lineas.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lineas.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0, ' ', new List<ConsoleColor> { ConsoleColor.DarkGreen }));
            lineas.Add(new Lane(13, false, ConsoleColor.DarkGreen, false, false, 0, ' ', new List<ConsoleColor> { ConsoleColor.DarkGreen }));


            Player jugador = new Player();

            while (true)
            {
                // - INPUTS -!
                Vector2Int input = Utils.Input();
                estado = jugador.Update(input, lineas);
                

                // - LOGIC -!
                foreach (Lane linea in lineas)
                {
                    linea.Update();
                }

                if (estado != Utils.GAME_STATE.RUNNING)
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 1);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(estado == Utils.GAME_STATE.WIN ? "Has ganado!" : "Has perdido...");
                    break;
                }


                // - DRAW -!
                foreach (Lane map in lineas)
                {
                    map.Draw(); ;
                }
                jugador.Draw();

                TimeManager.NextFrame();
            }
        }
    }
}