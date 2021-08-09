using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame.animation;
using NinjaGame.characters.animation;
using NinjaGame.collision;
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

        private Vector2 lastpos;
        private Vector2 snelheid;
        private Vector2 richting;

        private int maxsnelheid = 10;
        private float snelheidstap = 1f;
        private bool jumpkey = false;
        private bool jump = false;
        private float gravity = 1f;
        private float jumpstep = 20;
        private int doublejump = 0;

        private ContentManager Content;
        private Texture2D _runningGirl;
        private Texture2D _idleGirl;
        private Texture2D _jumpGirl;
        private Texture2D _diegirl;


        private Animation runningAnimation;
        private Animation idleAnimation;
        private Animation jumpAnimation;
        private DieAnimation dieanimation;


        private Platformdetection platformdetection;
        private Objectdetection objectdetection;
        private IGameCharacter character;


        public Movement(ContentManager content, IGameCharacter Character)
        {
            runningAnimation = new Animation(GameParameters.girlSpriteWidth, GameParameters.girlSpriteHeight, GameParameters.girlWidth, 0.03);
            idleAnimation = new Animation(2180, 375, 218, 0.1);
            jumpAnimation = new Animation(300, 410, 300, 0.03);
            dieanimation = new DieAnimation(300, 410, 300, 0.03);
            

            platformdetection = new Platformdetection();
            objectdetection = new Objectdetection(Character);

            Content = content;
            character = Character;
            lastpos = Character.positie;

        }

     
        public void  move(Vector2 Richting, Dictionary<string, List<Rectangle>> layout)
        {
            richting = Richting;

            movehorizontal();

            movevertical();

            snelheid.Y += gravity;
            character.positie += snelheid;

            var platformresponse = platformdetection.collision(character.positie, lastpos,layout);
            if (platformresponse.Item1)
            {
                resetjump();
                character.positie = new Vector2( character.positie.X,platformresponse.Item2);
            }

            objectdetection.collision( layout);

            if (character.positie.Y > GameParameters.grond)
            {
                resetjump();
                character.positie = new Vector2(character.positie.X,GameParameters.grond);
            }

            lastpos = character.positie ;

        }


        private void resetjump()
        {
            jump = false;
            doublejump = 0;
            snelheid.Y = 0;
        }
        private void movehorizontal()
        {
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
            
        }

        private void movevertical()
        {

            if (richting.Y == 1 && jumpkey == false)
            {
                if (doublejump < 2)
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
            if (character.positie.Y < GameParameters.grond)
            {
                jump = true;
            }
            
        }


        public void updateAnimation(GameTime gameTime)
        {
            if(snelheid.X == 0 && richting.X == 0 && jump == false)
            {
                    idleAnimation.update(gameTime);

                animationframe = idleAnimation.Frame;
                animationtexture = _idleGirl;
            }
            if (snelheid.X != 0 && jump == false)
            {
                runningAnimation.update(gameTime);

                animationframe = runningAnimation.Frame;

                animationtexture = _runningGirl;

            }
            if (snelheid.Y != 0)
            {
                    jumpAnimation.update(gameTime);

                animationframe = jumpAnimation.Frame;

                animationtexture = _jumpGirl;

            }
            
        }

        public void loadAnimations()
        {
            _runningGirl = Content.Load<Texture2D>("girl-running");
            _idleGirl = Content.Load<Texture2D>("girl-idle");
            _jumpGirl = Content.Load<Texture2D>("girl-jump");
            _diegirl = Content.Load<Texture2D>("girl-die");



            animationtexture = _idleGirl;
            animationframe = idleAnimation.Frame;

        }

    }
}
