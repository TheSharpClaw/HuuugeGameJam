using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Behaviour.Hive
{
    class ChildrenFly : IEntity
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        private Hive hive;

        private Directions lastDirection { get; set; } = Directions.None;

        enum Directions
        {
            None,
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        }

        private Vector2 NextDirections()
        {
            var directions = Enum.GetValues(typeof(Directions)).Cast<Directions>().ToList();

            directions.Remove(Directions.None);
            directions.Remove(lastDirection);

            lastDirection = directions[Globals.RandomBitches.Next(0, 7)];

            switch (lastDirection)
            {
                case Directions.None:
                    return new Vector2(0,0);
                case Directions.North:
                    return new Vector2(-2, 0);
                case Directions.NorthEast:
                    return new Vector2(-2, 2);
                case Directions.East:
                    return new Vector2(0, 2);
                case Directions.SouthEast:
                    return new Vector2(2, 2);
                case Directions.South:
                    return new Vector2(2, 0);
                case Directions.SouthWest:
                    return new Vector2(2, -2);
                case Directions.West:
                    return new Vector2(0, -2);
                case Directions.NorthWest:
                    return new Vector2(-2, -2);
                default:
                    throw new NotImplementedException();
            }
        }

        public ChildrenFly(Hive hive)
        {
            this.hive = hive;
            
            Position = hive.Position + new Vector2(Globals.RandomBitches.Next(-100, 100), Globals.RandomBitches.Next(-100, 100));
        }

        public void Update()
        {
            Position += NextDirections();
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.childrenFlyTexture, Position, Color.White);
        }
    }
}
