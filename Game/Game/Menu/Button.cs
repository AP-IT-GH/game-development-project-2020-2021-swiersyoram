using System;
using System.Collections.Generic;
using System.Text;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IronManGame.Game_interface
{
    class Button : Component
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


        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            PenColor = Color.Black;

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (_isHovering)
            {
                color = Color.Gray;
            }
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, rectangle, color);
            if (!string.IsNullOrEmpty(Text))
            {
                var x = (rectangle.X + (rectangle.Width / 2) - (_font.MeasureString(Text).X / 2));
                var y = (rectangle.Y + (rectangle.Height / 2) - (_font.MeasureString(Text).Y / 2));
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor);
            }
        }

        public void Update(GameTime gameTime)
        {
            _previousMouseState = _mouseState;
            _mouseState = Mouse.GetState();
            var mouseRectangle = new Rectangle(_mouseState.X, _mouseState.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(rectangle))
            {
                _isHovering = true;
            }
            if(_mouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(this, new EventArgs());
            }

        }

    }
}
