using HuuugeGame.Behaviour;
using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HuuugeGame
{
    class Obstacle : IEntity
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }
        public IComponent stage { get; private set; }
        public Obstacle(IComponent stage, Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)Texture.Width, (int)Texture.Height);

            this.stage = stage;
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