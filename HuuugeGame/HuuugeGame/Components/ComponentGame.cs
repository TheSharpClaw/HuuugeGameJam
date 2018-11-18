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
        private int i;
        private bool isLoaded = false;
        public List<IEntity> DrawList { get; set; } = new List<IEntity>();
        public List<IEntity> UpdateList { get; set; } = new List<IEntity>();

        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {       
            DrawList.Add(new Spider(this, new Vector2(32, 32), new Vector2(100, 100), 3));
            DrawList.Add(new Hive(this, new Vector2(500, 500), 10));
            //DrawList.Insert(0, new Flower(this, new Vector2(300,300)));

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

            for (int i = 0; i < UpdateList.Count(); i++)
            {
                UpdateList[i].Update();
            }
            Draw();
            if (!IfDrawListHasFlower())
            {
                if (i< 60 * 3)
                     i++;
                  else
                {
                    DrawList.Insert(0, new Flower(this, GenerateNewPositionForFlower()));

                }
            }
            else
            {
                i= 0;
            }
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

       private Vector2 GenerateNewPositionForFlower()
        {
            int posX, posY;
            Random rnd = new Random();
            posX = rnd.Next(24 + Globals.flowerTexture.Width / 2, (int)Globals.screenSize.X - 24 - Globals.flowerTexture.Width / 2);
            posY = rnd.Next(24 + Globals.flowerTexture.Height / 2, (int)Globals.screenSize.Y - 24 - Globals.flowerTexture.Height / 2);
            //TODO: Check if not collide with any created Obstacle
            return new Vector2(posX,posY);
        }
        private bool IfDrawListHasFlower()
        {
            return DrawList.Find(x => x is Flower)!=null;
        }
    }
}
