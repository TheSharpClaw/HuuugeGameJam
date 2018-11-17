using HuuugeGame.Content.Behaviour;
using HuuugeGame.Content.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Behaviour.Hive
{
    class Hive : IEntity, IMovable
    {
        public Vector2 Position { get; set; } = new Vector2(200, 200);
        public Texture2D Texture { get; set; } = Globals.MotherFlyTexture;

        public List<ChildrenFly> ChildrenFlies { get; set; } = new List<ChildrenFly>();

        public Hive(int offsprings = 0)
        {
            for (int i = 0; i < offsprings; i++)
                ChildrenFlies.Add(new ChildrenFly(this));
        }

        public void Update()
        {
            foreach (var fly in ChildrenFlies)
                fly.Update();
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.MotherFlyTexture, Position, Color.White);

            foreach (ChildrenFly fly in ChildrenFlies)
                fly.Draw();
        }
    }
}
