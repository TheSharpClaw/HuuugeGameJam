using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class ComponentGame : StateTemplate
    {
        //RYSOWANIE NA EKRANIE
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            //Globals.spriteBatch.Draw(Globals.backgroundTexture, new Rectangle(0, 0, 500, 500), Color.White);
            Globals.spriteBatch.End();
        }

        //OBLICZENIA
        public void Update()
        {
            Draw();
        }
    }
}
