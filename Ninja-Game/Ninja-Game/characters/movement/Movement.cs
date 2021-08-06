using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame.animation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters.movement
{
    class Movement
    {
        
        private SpriteEffects direction;
        public SpriteEffects Direction
        {
            get { return direction; }
        }

        private Vector2 positie;    
        

        private Texture2D animationtexture;
        public Texture2D AnimationTexture
        {
            get { return animationtexture; }
        }

        private Rectangle animationframe;
        public Rectangle AnimationFrame
        {
            get { return animationframe; }
        }


        private Vector2 snelheid;
        private characterState state;
        private Vector2 richting;

        private int maxsnelheid = 10;
        private float snelheidstap = 1f;
        private int grond = GameParameters.grond;
        private bool jumpkey = false;
        private bool jump = false;
        private float gravity = 1f;
        private float jumpstep = 20;
        private int doublejump = 0;
        private bool overplatform = false;

        private ContentManager Content;
        private Texture2D _runningGirl;
        private Texture2D _idleGirl;
        private Texture2D _jumpGirl;

        private Animation runningAnimation;
        private Animation idleAnimation;
        private Animation jumpAnimation;

        public Movement(ContentManager content)
        {
            state = characterState.idle;
            runningAnimation = new Animation(GameParameters.girlSpriteWidth, GameParameters.girlSpriteHeight, GameParameters.girlWidth, 0.03);
            idleAnimation = new Animation(2180, 375, 218, 0.1);
            jumpAnimation = new Animation(300, 410, 300, 0.03);
            Content = content;
        }

     
        public Vector2 move(Vector2 Richting, List<Rectangle> layout)
        {
            richting = Richting;

            switch (richting.X)
            {
                case 1:
                    direction = SpriteEffects.None;
                    if (snelheid.X < maxsnelheid)
                    {
                        snelheid.X += snelheidstap;
                    }
                    break;
                case -1:
                    direction = SpriteEffects.FlipHorizontally;
                    if (snelheid.X > -maxsnelheid)
                    {
                        snelheid.X -= snelheidstap;
                    }
                    break;
                case 0:
                    snelheid.X = 0;
                    break;
                default:
                    break;
            }



            if (richting.Y == 1 && jumpkey == false )
            {
                if(doublejump < 2)
                {
                    jumpkey = true;
                    snelheid.Y = -jumpstep;
                    doublejump++;
                }
            }
            if (richting.Y == 0 && jumpkey == true)
            {
                jumpkey = false;
            }
            if(positie.Y < grond)
            {
                jump = true;
            }

            snelheid.Y += gravity;
            positie += snelheid;

            foreach (var crate in layout)
            {
                if(positie.X > crate.X && positie.X < crate.X + crate.Width)
                {
                    if (positie.Y < crate.Y)
                    {
                        overplatform = true;
                    }
                        if (positie.Y > crate.Y && overplatform == true)
                    {
                        jump = false;
                        doublejump = 0;
                        snelheid.Y = 0;
                        
                        positie.Y = crate.Y;
                    }


                }
                
                
            }

            
            if (positie.Y > grond)
            {
                jump = false;
                doublejump = 0;
                snelheid.Y = 0;
                positie.Y = grond;
                overplatform = false;
            }
            return positie;
        }


        private void checkanimation()
        {
            if (snelheid.X == 0 && richting.X == 0 && jump == false)
            {
                state = characterState.idle;
                animationframe = idleAnimation.Frame;
                animationtexture = _idleGirl;
            }
            if(snelheid.X != 0 && jump ==false)
            {
                state = characterState.running;
                animationframe = runningAnimation.Frame;

                animationtexture = _runningGirl;

            }
            if (snelheid.Y != 0)
            {
                state = characterState.jump;
                animationframe = jumpAnimation.Frame;

                animationtexture = _jumpGirl;

            }
        }

        public void updateAnimation(GameTime gameTime)
        {
            checkanimation();
            switch (state)
            {
                case characterState.idle:
                    idleAnimation.update(gameTime);
                    break;
                case characterState.running:
                    runningAnimation.update(gameTime);
                    break;
                case characterState.jump:
                    jumpAnimation.update(gameTime);
                    break;
                default:
                    break;
            }
        }

        public void loadAnimations()
        {
            _runningGirl = Content.Load<Texture2D>("girl-running");
            _idleGirl = Content.Load<Texture2D>("girl-idle");
            _jumpGirl = Content.Load<Texture2D>("girl-jump");

            animationtexture = _idleGirl;
            animationframe = idleAnimation.Frame;

        }

    }
}
