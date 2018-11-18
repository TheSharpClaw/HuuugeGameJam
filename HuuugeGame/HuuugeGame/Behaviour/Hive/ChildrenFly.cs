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
        public Texture2D Texture { get; set; } = Globals.childrenFlyTexture;
        public Rectangle BoundingBox { get; set; }
        public IComponent stage { get; private set;  }

        private Hive hive;

        private bool chasingMode = false;
        private int chaseRadious = 5;

        private int velocity = 2;

        private Color childColor;
        private static Color[] ColorsArray =
        {
            Color.LawnGreen,
            Color.Red,
            Color.Magenta,
            Color.CornflowerBlue,
            Color.Yellow,
            Color.HotPink,
            Color.OrangeRed
        };

        private Direction choose { get; set; } = Direction.None;


        enum Direction
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

        public ChildrenFly(IComponent stage, Hive hive)
        {
            this.stage = stage;

            this.hive = hive;

            Position = hive.Position + new Vector2(Globals.RandomBitches.Next(-100, 100), Globals.RandomBitches.Next(-100, 100));
            childColor = ColorsArray[Globals.RandomBitches.Next(0, ColorsArray.Length - 1)];
            BoundingBox = Texture.Bounds;

        }

        private Vector2 GetVectorFromDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new Vector2(-velocity, 0);
                case Direction.NorthEast:
                    return new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * -velocity, (float)Math.Cos((Math.PI / 180 * 45)) * velocity);
                case Direction.East:
                    return new Vector2(0, velocity);
                case Direction.SouthEast:
                    return new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * velocity, (float)Math.Cos((Math.PI / 180 * 45)) * velocity);
                case Direction.South:
                    return new Vector2(velocity, 0);
                case Direction.SouthWest:
                    return new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * velocity, (float)Math.Cos((Math.PI / 180 * 45)) * -velocity);
                case Direction.West:
                    return new Vector2(0, -velocity);
                case Direction.NorthWest:
                    return new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * -velocity, (float)Math.Cos((Math.PI / 180 * 45)) * -velocity);
                default:
                    return new Vector2(0, 0);
            }
        }

        private Vector2 NextDirection()
        {
            var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

            var distance = Vector2.Distance(Position, hive.Center);

            directions.Remove(Direction.None);
            directions.Remove(choose);

            while (true)
            {
                choose = directions[Globals.RandomBitches.Next(0, directions.Count)];

                var resultVector = Position + GetVectorFromDirection(choose);
                var resultDistance = Vector2.Distance(resultVector, hive.Center);

                if (!chasingMode)
                {
                    if (!(distance > hive.maxRadious && resultDistance > distance) && !(distance < hive.minRadious && resultDistance < distance))
                    {
                        return resultVector;
                    }
                }
                else
                {
                    if (!(distance > chaseRadious && resultDistance > distance))
                    {
                        return resultVector;
                    }
                }

                if (directions.Count == 1)
                    return resultVector;

                directions.Remove(choose);
            }
        }

        public void Update()
        {
            var distance = Vector2.Distance(Position, hive.Center);

            if (!chasingMode)
            {
                if (distance > hive.maxRadious + 10)
                    chasingMode = true;
            }
            else
            {
                if (distance < chaseRadious)
                    chasingMode = false;
            }

            Position = NextDirection();
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, childColor);
        }
    }
}
