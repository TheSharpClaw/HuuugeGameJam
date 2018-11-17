using HuuugeGame.Behaviour.Hive;
using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Components
{
    class ComponentTest : StateTemplate, Behaviour.IComponent
    {
        public List<IEntity> DrawList { get; set; } = new List<IEntity>();
        public List<IEntity> UpdateList { get; set; } = new List<IEntity>();

        public ComponentTest()
        {
            DrawList.Add(new Hive(1000));

            UpdateList = DrawList;
        }

        public void Draw()
        {
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();

            foreach (IEntity entity in DrawList)
                entity.Draw();

            Globals.spriteBatch.End();
        }

        public void Update()
        {
            foreach (IEntity entity in UpdateList)
                entity.Update();

            Draw();
        }
    }
}
