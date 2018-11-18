using HuuugeGame.Behaviour;
using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HuuugeGame
{
    public class Obstacle : IEntity
    {
        public Vector2 Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Texture2D Texture { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Rectangle BoundingBox { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IComponent stage => throw new System.NotImplementedException();

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}