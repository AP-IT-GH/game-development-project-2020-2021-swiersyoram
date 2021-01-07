using System;
using System.Collections.Generic;
using System.Text;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IronManGame.Game_interface
{
    class Startbtn : IBtn
    {
        private MouseState _mouseState;
        private SpriteFont _font;
        private bool _isHovering;
        private MouseState _previousMouseState;
        private Texture2D _texture;

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColor { get; set; }
        public Vector2 position { get; set; }
        public Rectangle rectangle { get
            {
                return new Rectangle((int) position.X , (int) position.Y, _texture.Width, _texture.Height);
            } }

        public string Text { get; set; }


        public Startbtn(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (_isHovering)
            {
                color = Color.Gray;
            }
            spriteBatch.Draw(_texture, rectangle, color);
            if (!string.IsNullOrEmpty(Text))
            {

            }
        }

        public void update(GameTime gameTime)
        {
        }
    }
}
