using HuuugeGame.Components;
using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Behaviour.Hive
{
    class Hive : IEntity
    {
        public Vector2 Position { get; set; }
        public AnimatedSprite animatedSprite;
        int counterTimer = 0;

        public Texture2D Texture { get; set; } = Globals.motherFlyTexture;

        public Rectangle BoundingBox { get; set; }

        public Vector2 Center { get => BoundingBox.Center.ToVector2(); }

        public int minRadious { get; } = 30;

        public int maxRadious { get => 45 + ChildrenFlies.Count / 10; }

        public List<ChildrenFly> ChildrenFlies { get; set; } = new List<ChildrenFly>();

        public int Velocity { get; set; } = 3;
        private float angle = 0;
        Vector2 origin = new Vector2(Globals.motherFlyTexture.Width / 2, Globals.motherFlyTexture.Height / 2);
        public Vector2 Size { get; set; } = new Vector2(32, 32);

        public IComponent stage { get; private set; }

        public Hive(IComponent stage, Vector2 position, int offsprings = 0)
        {
            this.stage = stage;

            Position = position;
            BoundingBox = new Rectangle(Position.ToPoint(), BoundingBox.Size);

            for (int i = 0; i < offsprings; i++)
                ChildrenFlies.Add(new ChildrenFly(this.stage, this));
            animatedSprite = new AnimatedSprite(Globals.motherFlyTexture, 2, 2);
        }

        public void Update()
        {
            BoundingBox = new Rectangle(Position.ToPoint(), BoundingBox.Size);

            var keys = Keyboard.GetState().GetPressedKeys().Cast<Keys>().ToList();

            if (counterTimer++ % 6 == 0) animatedSprite.Update();

            HiveControls();
            HiveCollision();
            foreach (var fly in ChildrenFlies)
                fly.Update();
        }

        public void Draw()
        {
            animatedSprite.Draw(Position, angle, Color.White);
            foreach (ChildrenFly fly in ChildrenFlies)
                fly.Draw();
        }


        public void HiveControls()
        {
            var keys = Keyboard.GetState().GetPressedKeys().Cast<Keys>().ToList();

            if (keys.Contains(Keys.Left) && keys.Contains(Keys.Right))
            {
                keys.Remove(Keys.Left);
                keys.Remove(Keys.Right);
            }

            if (keys.Contains(Keys.Up) && keys.Contains(Keys.Down))
            {
                keys.Remove(Keys.Up);
                keys.Remove(Keys.Down);
            }

            foreach (var key in keys)
            {
                switch (key)
                {
                    case Keys.Up:
                        {
                            if (keys.Contains(Keys.Left) || keys.Contains(Keys.Right))
                            {
                                if (keys.Contains(Keys.Left))
                                {
                                    Position += new Vector2((float)-Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)-Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 1.75f;
                                }
                                else
                                {
                                    Position += new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)-Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 0.25f;
                                }

                                break;
                            }

                            Position += new Vector2(0, -Velocity);
                            angle = 0;

                            break;
                        }
                    case Keys.Down:
                        {
                            if (keys.Contains(Keys.Left) || keys.Contains(Keys.Right))
                            {
                                if (keys.Contains(Keys.Left))
                                {
                                    Position += new Vector2((float)-Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 1.25f;
                                }
                                else
                                {
                                    Position += new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 0.75f;
                                }
                                break;
                            }

                            Position += new Vector2(0, Velocity);
                            angle = (float)Math.PI;

                            break;
                        }
                    case Keys.Left:
                        {
                            if (keys.Contains(Keys.Up) || keys.Contains(Keys.Down))
                                break;

                            Position += new Vector2(-Velocity, 0);
                            angle = (float)Math.PI * 1.5f;
                            break;
                        }
                    case Keys.Right:
                        {
                            if (keys.Contains(Keys.Up) || keys.Contains(Keys.Down))
                                break;

                            Position += new Vector2(Velocity, 0);
                            angle = (float)Math.PI * 0.5f;
                            break;
                        }
                }
            }

        }

        public void HiveCollision()
        {
            //GAMESPACE
            if (Position.X < 24) Position = new Vector2(24, Position.Y);

            else if (Position.X + BoundingBox.Width > Globals.screenSize.X - 24) Position = new Vector2(Globals.screenSize.X - 24 - BoundingBox.Width, Position.Y);

            if (Position.Y < 24) Position = new Vector2(Position.X, 24);

            else if (Position.Y + BoundingBox.Height > Globals.screenSize.Y - 24) Position = new Vector2(Position.X, Globals.screenSize.Y - 24 - BoundingBox.Height);

            //FLOWER COLLISION         
            for (int i = 0; i < stage.DrawList.Count(); i++)
            {
                if(stage.DrawList[i] is Flower) {
                    if (stage.DrawList[i].BoundingBox.Intersects(this.BoundingBox))
                    {
                        stage.DrawList.Remove(stage.DrawList[i]);
                        //FLOWER - EATEN = ADD 10 SMALL BITCHES
                        for (int k = 0; k < 10; k++)
                            ChildrenFlies.Add(new ChildrenFly(this.stage, this));

                    }
                    break;
                }

            }
        }
    }
}
