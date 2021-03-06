﻿using HuuugeGame.Behaviour;
using HuuugeGame.Behaviour.Hive;
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
        public Texture2D Texture { get; set; } = Globals.flowerTexture;
        public Rectangle BoundingBox { get; set; }

        public IComponent stage { get; private set; }

        int sizeX = Globals.flowerTexture.Width;
        int sizeY = Globals.flowerTexture.Height;

        int incrementX = 0;
        int incrementY = 0;


        public Flower(IComponent stage, Vector2 position)
        {
            this.stage = stage;
            Position = position;
            updateBoundingBox();
        }

        private void updateBoundingBox()
        {
            BoundingBox = new Rectangle((int)Position.X - (incrementX / 2), (int)Position.Y - (incrementY / 2), incrementX, incrementY);
        }

        public void Draw()
        {       
            Globals.spriteBatch.Draw(Texture, BoundingBox, Color.White);  
        }

        public void Update()
        {
            if (incrementX < sizeX)
            {
                incrementX++;
                updateBoundingBox();
            }
            if (incrementY < sizeY)
            {
                incrementY++;
                updateBoundingBox();
            }           
        } 
    }
}
