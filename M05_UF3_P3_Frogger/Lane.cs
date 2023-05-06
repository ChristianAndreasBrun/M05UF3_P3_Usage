using System;
using System.Collections.Generic;
using System.Text;

namespace M05_UF3_P3_Frogger
{
    public class Lane
    {
        public readonly int posY;   // indica la posicion vertical del carril
        public readonly int speedElements;  // indica la velocidad de los elementos dinamicos que se mueven
        public readonly bool speedPlayer;   // indica si se mueve con el elemento o no
        public readonly ConsoleColor background;    // indica el color de fondo
        public readonly bool damageElements;    // indica si los elementos del carril pueden dañar al jugador
        public readonly bool damageBackground;  // indica si el fondo del carril puede dañar al jugador
        public List<DynamicElement> elements { get; protected set; } = new List<DynamicElement>();  // lista de elementos dinamicos que se mueven el carril


        public Lane(int posY, bool speedPlayer, ConsoleColor background, bool damageElements, bool damageBackground, float elementsPercent, char elementsChar, List<ConsoleColor> colorsElements)
        // -> Constructor de clase. Genera de forma random algunos elementos en el carril
        {
            this.posY = posY;
            this.speedElements = Utils.rnd.Next(-10, 10) < 0 ? 1 : -1;  
            this.speedPlayer = speedPlayer; 
            this.background = background;   
            this.damageElements = damageElements;   
            this.damageBackground = damageBackground;   

            for (int i = 0; i < Utils.MAP_WIDTH; i++)
            {
                if(Utils.rnd.NextDouble() < elementsPercent)
                {
                    this.elements.Add(
                        new DynamicElement(
                            new Vector2Int(speedElements, 0), 
                            new Vector2Int(i, posY),
                            elementsChar, 
                            colorsElements[Utils.rnd.Next(colorsElements.Count)]
                            ));
                }
            }
            this.elements.TrimExcess();
        }

        public void Draw()
        // Dibuja el carril
        {
            Console.SetCursorPosition(0, posY);
            Console.BackgroundColor = background;
            for (int i = 0; i < Utils.MAP_WIDTH; i++)
            {
                DynamicElement element = ElementAtPosition(new Vector2Int(i, posY));
                if (element == null)
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.ForegroundColor = element.foreground;
                    Console.Write(element.character);
                }
            }
        }
        public void Update()
        // Actualiza todos los elementos
        {
            foreach (DynamicElement element in elements)
            {
                element.Update();
            }
        }

        public DynamicElement ElementAtPosition(Vector2Int position)
        // Busca un elemento en una posicion en el carril y devuelve ese elemento
        {
            foreach (DynamicElement element in elements)
            {
                if(element.pos == position)
                    return element;
            }
            return null;
        }
    }
}
