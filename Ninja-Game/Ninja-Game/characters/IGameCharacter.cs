using Microsoft.Xna.Framework;
using NinjaGame.animation;
using NinjaGame.controller;
using NinjaGame.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters
{
    interface IGameCharacter
    {

        public bool Dood { get; set; }
        public Vector2 positie { get; set; }
        public Animation Activeanimation { get; set; }
        public void load();
        public void update(GameTime gameTime, Vector2 newspeed);
        public void draw();

    }
}
