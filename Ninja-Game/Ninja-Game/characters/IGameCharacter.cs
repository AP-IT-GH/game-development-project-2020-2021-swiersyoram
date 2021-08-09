using Microsoft.Xna.Framework;
using NinjaGame.controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters
{
    interface IGameCharacter
    {

        public bool Dood { get; set; }
        public Vector2 positie { get; set; }
        public void load();
        public void update(GameTime gameTime, Vector2 newspeed, Dictionary<string, List<Rectangle>> layout);
        public void draw();

    }
}
