using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Components
{
    class ComponentInfo : StateTemplate
    {


        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(Globals.spiderTexture, new Rectangle((int)Globals.screenSize.X / 4 - Globals.spiderTexture.Width, 100,Globals.spiderTexture.Width*2,Globals.spiderTexture.Height*2),Color.White);
           // Globals.spriteBatch.Draw(Globals.)
            Globals.spriteBatch.End();
        }

        public void Update()
        {
            Draw();
        }
    }
}
