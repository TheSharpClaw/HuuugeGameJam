using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class Flower : IEntity

    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        int sizeX = Globals.flowerTexture.Width;
        int sizeY = Globals.flowerTexture.Height;
        int incrementX = 0;
        int incrementY = 0;
        List<IEntity> _drawList;
        public Flower(List<IEntity> drawList)
        {
            _drawList = drawList;
            Texture = Globals.flowerTexture;
            Position = new Vector2(100, 100);
        }

        public void Draw()
        {       
            Globals.spriteBatch.Draw(Texture, new Rectangle(400-(incrementX/2), 400-(incrementY/2), incrementX, incrementY), Color.White);  
           
        }

        public void Update()
        {
            if (incrementX < sizeX)
                incrementX++;
            if (incrementY < sizeY)
                incrementY++;            
        } 
    }
}
