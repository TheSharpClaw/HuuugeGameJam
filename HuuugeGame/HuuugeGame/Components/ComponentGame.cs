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
        public List<Obstacle> ObstacleList { get; set; } = new List<Obstacle>(); 

        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            var hive = new Hive(this, new Vector2(500,500), 13);

            ObstacleList = GenerateListOfRandomObstacles();

            foreach(IEntity obstacle in ObstacleList)
            {
                DrawList.Add(obstacle);
            }

            DrawList.Add(new Spider(this, new Vector2(32, 32), new Vector2(100, 100), 2));
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

            List<ChildrenFly> ListOfChildrenFlies = ((Hive)DrawList.Find(x => x is Hive)).ChildrenFlies;

            Globals.spriteBatch.Draw(Globals.hpBar, new Rectangle(30, 2, 100, 22), new Color(0, 0, 0, 150));
            Globals.spriteBatch.DrawString(Globals.defaultFont, "My Hive: " + ListOfChildrenFlies.Count.ToString(), new Vector2(36, 4), Color.White);
            Globals.spriteBatch.End();
        }

        private List<Obstacle> RandomizeObstacles()
        {
            List<Obstacle> listOfRandomizedObstacles = new List<Obstacle>();

            Random rnd = new Random();
            int x = 0;
            int y = 0;
            int t = 0;
            Texture2D texture = null;

            for(int i = 0; i <= 5; i++)
            {
                int t = rnd.Next(0, 7); 

                switch (switch_on)
	            {
		            case 0:
                        texture = Globals.stone1Texture;
                    break;
                    case 1:
                        texture = Globals.stone2Texture;
                    break;
                    case 2:
                        texture = Globals.stone3Texture;
                    break;
                    case 3:
                        texture = Globals.stone4Texture;
                    break;
                    case 4:
                        texture = Globals.stumpTexture;
                    break;
                    case 5:
                        texture = Globals.holeTexture;
                    break;
                    case 6:
                        texture = Globals.bushTexture;
                    break;
	            }

                int x = rnd.Next(64, 636 - texture.Width);
                int y = rnd.Next(64, 536 - texture.Height);

                listOfRandomizedObstacles.Add(new Obstacle(this, new Vector2(x, y), texture));
            }

            return listOfRandomizedObstacles;
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
