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
        int counterTimer;
        public List<IEntity> DrawList { get; set; } = new List<IEntity>();
        public List<IEntity> UpdateList { get; set; } = new List<IEntity>();


        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            DrawList.Add(new Spider(new Vector2(32, 32), new Vector2(100, 100), 3));
            counterTimer = 0;
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
            Spider ourSpider = null;
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(Globals.backgroundTexture, new Vector2(0, 0), Color.White);
            foreach (IEntity entity in DrawList)
            {
                entity.Draw();
                if (entity is Spider)
                    ourSpider = (Spider) entity;
            }
            //counterTimer == 60 - upłynęła 1 sekunda
            if (counterTimer++ > (60*3))
            {
                if (ourSpider.spiderWebPower < 90)
                {
                    ourSpider.spiderWebPower+=10;
                }
                counterTimer = 0;
            }
            #region drawSpiderWebPower
            Globals.spriteBatch.Draw(Globals.hpBar, new Rectangle((int)ourSpider.Position.X-10, (int)ourSpider.Position.Y - 20, 50, Globals.hpBar.Height), Color.White);
            Globals.spriteBatch.Draw(Globals.hpBar_green, new Rectangle((int)ourSpider.Position.X-10, (int)ourSpider.Position.Y - 20, ourSpider.spiderWebPower/2, Globals.hpBar.Height), Color.White);
            #endregion

            Globals.spriteBatch.End();
        }
    }
}
