using HuuugeGame.Behaviour;
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
	class Obstacle : IEntity
	{
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }

        IComponent stage { get; private set; }

        int sizeX = Texture.Width;
        int sizeY = Texture.Height;

        public Obstacle(IComponent stage, Vector2 position, Texture2D texture)
        {
            Stage = stage;
            Position = position;
            Texture = texture;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);          
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, BoundingBox, Color.White);
        }

        public void Update()
        {
            
        }
    }
}