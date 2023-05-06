using System;
using System.Collections.Generic;

namespace M05_UF3_P3_Frogger
{
    // - Clase Abstracta - ELEMENT
    public abstract class Element
    {
        // Propiedades publicas
        public Vector2Int pos { get; protected set; }   //posicion del elemento en el mapa
        public char character { get; protected set; }   //caracter que representa el elemento
        public readonly ConsoleColor foreground;    //color del primer plano para representar un elemento

        public Element(Vector2Int pos, char character = ' ', ConsoleColor foreground = ConsoleColor.White)
        // -> Constructor de clase: permite definir la posición, el carácter y el color del elemento.
        {
            this.pos = pos;
            this.character = character;
            this.foreground = foreground;
        }

        public virtual void Draw()
        // > Metodo virtual: dibuja elmento en consola con su posicion, caracter y color
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = foreground;
            Console.Write(character);
        }
        public virtual void Draw(ConsoleColor background)
        // > Permite definir un color adicional de fondo para el elemento
        {
            Console.BackgroundColor = background;
            Draw();
        }
        public abstract void Update();
        // - Metodo abstracto
    }

    // - Clase que HEREDA de Element : representa elemento con movimiento en el mapa
    public class DynamicElement : Element
    {

        public Vector2Int speed { get; protected set; }
        public DynamicElement(Vector2Int speed, Vector2Int pos, char character = ' ', ConsoleColor foreground = ConsoleColor.White) : base(pos, character, foreground)
        // -> Constructor de clase: permite definir la velocidad, posicion, caracter y el color del elemento
        {
            this.speed = speed;
        }

        public override void Update()
        // > Metodo que actualiza la posicion del elemento en el mapa en funccion de la velocidad
        {
            pos += speed;
            if(pos.x >= Utils.MAP_WIDTH)
            {
                pos.x = 0;
            }
            else if (pos.x < 0)
            {
                pos.x = Utils.MAP_WIDTH - 1;
            }
            if(pos.y >= Utils.MAP_HEIGHT)
            {
                pos.y = 0;
            }
            else if (pos.y < 0)
            {
                pos.y = Utils.MAP_HEIGHT - 1;
            }
        }
        public virtual void Update(Vector2Int dir)
        // > Permite definir una nueva direccion de movimiento para el elemento
        {
            speed = dir;
            Update();
        }
    }

    // - Clase que HEREDA de Element : representa al jugador del juego
    public class Player : DynamicElement
    {
        // - Define los caracteres del jugador dependiendo de la posicion
        public const char characterForward = '╧';
        public const char characterBackwards = '╤';
        public const char characterLeft = '╢';
        public const char characterRight = '╟';

        public Player() : base(Vector2Int.zero, new Vector2Int(Utils.MAP_WIDTH / 2, Utils.MAP_HEIGHT - 1), characterForward, ConsoleColor.Green)
        // -> Constructor de clase
        {
        }

        public Utils.GAME_STATE Update(Vector2Int dir, List<Lane> lanes)
        // > Metodo que actualiza la posicion del jugador y comprueba si ha ganado, perdido o sigue jugando
        {
            speed = dir;

            // - Se asigna el carácter correspondiente según la dirección del movimiento
            if (dir.y < 0)
            { character = characterForward; }
            else if (dir.y > 0)
            { character = characterBackwards;}
            else if (dir.x > 0)
            { character = characterRight; }
            else if (dir.x < 0)
            { character = characterLeft; }

            pos += speed;
            // - Si el jugador llega a la fila superior gana el juego
            if (pos.y <= 0)
            {
                return Utils.GAME_STATE.WIN;
            }
            // - Si el jugador llega a la última fila del mapa se queda en esa posición
            else if (pos.y >= Utils.MAP_HEIGHT)
            {
                pos.y = Utils.MAP_HEIGHT - 1;
            }

            // --> Comprueba si el jugador ha colisionado con algún elemento de las calles
            foreach (Lane lane in lanes)
            {
                if (lane.posY == pos.y)
                {
                    if (lane.speedPlayer) {
                        pos.x += lane.speedElements;
                    }
                    if (pos.x >= Utils.MAP_WIDTH)
                    {
                        pos.x = 0;
                    }
                    else if (pos.x < 0)
                    {
                        pos.x = Utils.MAP_WIDTH - 1;
                    }
                    if (lane.ElementAtPosition(pos) == null)
                    {
                        if (lane.damageBackground)
                        {
                            return Utils.GAME_STATE.LOOSE;
                        }
                        else
                        {
                            return Utils.GAME_STATE.RUNNING;
                        }
                    }
                    else
                    {
                        if (lane.damageElements)
                        {
                            return Utils.GAME_STATE.LOOSE;
                        }
                        else
                        {
                            return Utils.GAME_STATE.RUNNING;
                        }
                    }
                }
            }
            return Utils.GAME_STATE.RUNNING;
        }

        public void Draw(List<Lane> lanes)
        {
            foreach (Lane lane in lanes)
            {
                if (lane.posY == pos.y)
                {
                    Console.BackgroundColor = lane.background;
                }
            }
            base.Draw();
        }
    }
}
