using Microsoft.Xna.Framework;
using NinjaGame.controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters
{
    interface IGameCharacter
    {
        public void load();
        public void update(GameTime gameTime, Vector2 newspeed, List<Rectangle> layout);
        public void draw();

    }
}
