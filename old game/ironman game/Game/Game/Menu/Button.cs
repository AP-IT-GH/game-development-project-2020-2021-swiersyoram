using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IronManGame.Game_interface
{
    class Button
    {
        private SpriteBatch _spritebatch;
        private Texture2D _buttonSprite;
        private Rectangle _rectangle;
        private Rectangle _hoverRectangle;
        private MouseState _mouse;
        private string _gameState;

        public Button(Texture2D buttonSprite, Rectangle rectangle, String gamestate)
        {
            _buttonSprite = buttonSprite;
            _rectangle = rectangle;
            _hoverRectangle = rectangle;
            _gameState = gamestate;
        }
       
        public  void Update(GameTime gameTime)
        {
            _mouse = Mouse.GetState();

            if (_mouse.Position.X >= _rectangle.X
                            && _mouse.Position.X <= _rectangle.X+300
                            && _mouse.Position.Y >= _rectangle.Y
                            && _mouse.Position.Y <= _rectangle.Y+120)
            {
                _rectangle.Width = _hoverRectangle.Width + 20;
                _rectangle.Height = _hoverRectangle.Height + 10;
                if (_mouse.LeftButton == ButtonState.Pressed)
                {
                    Debug.WriteLine(_mouse.Position);
                    game._gameState = _gameState;
                }
            }
            else
            {
                _rectangle = _hoverRectangle;
            }
        }
        public  void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_buttonSprite, _rectangle, Color.White);
        }
    }
    

}
