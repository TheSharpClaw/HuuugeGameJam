using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HuuugeGame.Components
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }

        private Rectangle[] frames;

        private int currentFrame = 0;
        private int totalFrames;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;

            frames = new Rectangle[rows * columns];

            totalFrames = rows * columns;

            int frameWidth = Texture.Width / columns;
            int frameHeight = Texture.Height / rows;

            for(int i = 0; i < rows*columns; i++)
            {
                int row = currentFrame / columns;
                int column = currentFrame % columns;

                Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);

                frames[i] = sourceRectangle;
            }
        }

        public void Update()
        {
            if (++currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(Vector2 location, float angle, Color color)
        {
            var frame = frames[currentFrame];

            var vector = frame.Center.ToVector2();

            Globals.spriteBatch.Draw(Texture, (vector + location), frame, color, angle, vector, 1.0f, SpriteEffects.None, 1);
        }
    }
}
