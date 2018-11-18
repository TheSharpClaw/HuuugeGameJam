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
        private int counter1,counter2;
        private bool isLoaded = false;
        public List<IEntity> DrawList { get; set; } = new List<IEntity>();
        public List<IEntity> UpdateList { get; set; } = new List<IEntity>();

        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            var hive = new Hive(this, new Vector2(500,500), 13);


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



            //FLOWER
            if (!IfDrawListHasFlower())
            {
                counter2 = 0;
                if (counter1< 60 * 3)
                     counter1++;
                  else
                {
                    DrawList.Insert(0, new Flower(this, GenerateNewPositionForFlower()));

                }
            }
            else
            {
                counter1= 0;
                if (counter2 < 60 * 8)
                    counter2++;
                else
                {
                    counter2 = 0;
                    DrawList.Remove(DrawList.Find(x=>x is Flower));
                    DrawList.Insert(0, new Flower(this, GenerateNewPositionForFlower()));
                }
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
