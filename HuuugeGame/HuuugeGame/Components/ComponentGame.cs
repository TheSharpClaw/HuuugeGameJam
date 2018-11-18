using HuuugeGame.Behaviour.Hive;
using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class ComponentGame : StateTemplate, Behaviour.IComponent
    {
        private bool isLoaded = false;
        public List<IEntity> DrawList { get; set; } = new List<IEntity>();
        public List<IEntity> UpdateList { get; set; } = new List<IEntity>();


        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            DrawList.Add(new Spider(new Vector2(32, 32), new Vector2(100, 100), 3));
            DrawList.Add(new Hive(200));
            //HACK: Do rozróżnienia?
            UpdateList = DrawList;
        }

        //OBLICZENIA
        public void Update()
        {
            if (!isLoaded)
            {
                OnLoad();
                isLoaded = true;
            }

            foreach (IEntity entity in UpdateList)
                entity.Update();

            Draw();
        }

        //RYSOWANIE NA EKRANIE
        public void Draw()
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(Globals.backgroundTexture, new Vector2(0, 0), Color.White);
            foreach (IEntity entity in DrawList)
            {
                entity.Draw();
            }
            Globals.spriteBatch.End();
        }
    }
}
