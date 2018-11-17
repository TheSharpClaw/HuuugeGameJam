using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Controls
{
   public class Button
    {
        #region fields
        public String nameBtn { get; set;}
        private SpriteFont _font;
        private Texture2D _texture;
        public bool _isSelected { get; set; }
        #endregion

        #region Properties
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); } }
        public string Text { get; set; }
        #endregion

        #region Methods
        public Button(Texture2D texture, SpriteFont font, String name)
        {
            this.nameBtn = name;
            _texture = texture;
            PenColour = Color.Black;
            _font = font;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            var colour = Color.White;
            if (!_isSelected)
                colour = Color.Gray;
            spriteBatch.Draw(_texture, Rectangle, colour);
            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }
        public void Update()
        {
            Draw(Globals.spriteBatch);
        }
        #endregion
    }
}
