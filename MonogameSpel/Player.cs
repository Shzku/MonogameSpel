using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameSpel
{
    public class Player
    {
        public int PosX;
        public int PosY;

        private readonly int spriteHeight;
        private readonly int spriteWidth;
        
        private Texture2D playerSprite;
        private Rectangle[] _sourceRectangles;
        
        public Rectangle _hitBox;

        private int _currentSpriteFrame;
        private float animationSpeed;
        private float timer;

        private bool keyPressed;
        private bool _canWalk;

        private GameStates.MainGame _mainGame;
        public Player(GameStates.MainGame mainGame)
        {
            _mainGame = mainGame;
            
            spriteHeight = 62;
            spriteWidth = 39;

            _hitBox = new Rectangle(PosX, PosY, spriteHeight, spriteHeight*2);
            
            _currentSpriteFrame = 0;
            animationSpeed = 0.5f;
            timer = 0;

            _canWalk = true;
        }
        
        public void LoadContent(ContentManager content)
        {
            playerSprite = content.Load<Texture2D>("Player");

            _sourceRectangles = new Rectangle[6];
            _sourceRectangles[0] = new Rectangle(0, 0, spriteWidth, spriteHeight);
            _sourceRectangles[1] = new Rectangle(0, spriteHeight, spriteWidth, spriteHeight);
            _sourceRectangles[2] = new Rectangle(spriteWidth,spriteHeight, spriteWidth, spriteHeight);
            _sourceRectangles[3] = new Rectangle(spriteWidth*2,spriteHeight, spriteWidth, spriteHeight);
            _sourceRectangles[4] = new Rectangle(spriteWidth*3,spriteHeight, spriteWidth, spriteHeight); 
            _sourceRectangles[5] = new Rectangle(spriteWidth, 0, spriteWidth, spriteHeight);
        }

        public void Update(GameTime gameTime)
        {
            keyPressed = false;
            Keyboard.GetState();
            if (Keyboard.IsPressed(Keys.W) || Keyboard.IsPressed(Keys.Up) && PosY > 0)
            {
                keyPressed = true;
                PosY-=2;
            }
            
            if (Keyboard.IsPressed(Keys.S) || Keyboard.IsPressed(Keys.Down) && PosY < (480-spriteHeight*2))
            {
                keyPressed = true;
                PosY+=2;
            }
            
            if (Keyboard.IsPressed(Keys.D) || Keyboard.IsPressed(Keys.Right) && PosX < (800-spriteWidth*2))
            {
                keyPressed = true;
                PosX+=2;
            }
            
            if (Keyboard.IsPressed(Keys.A) || Keyboard.IsPressed(Keys.Left) && PosX > 0)
            {
                keyPressed = true;
                PosX-=2;
            }

            if (Keyboard.HasBeenPressed(Keys.Space))
            {
                //_currentSpriteFrame = 5;
                _canWalk = false;
                Attack(gameTime);
            } else if (keyPressed && _canWalk)
            {
                WalkAnimation(gameTime);
            }else 
            {
                _currentSpriteFrame = 0;
            }

            _hitBox.Location = new Point(PosX, PosY);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            spriteBatch.Draw(playerSprite, new Rectangle(PosX, PosY, spriteWidth*2, spriteHeight*2), _sourceRectangles[_currentSpriteFrame], Color.White);
            spriteBatch.End();
        }

        public void WalkAnimation(GameTime gameTime)
        {
            timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > animationSpeed)
            {
                timer = 0;
                _currentSpriteFrame++;

                if (_currentSpriteFrame == 5)
                {
                    _currentSpriteFrame = 1;
                }
            }
        }

        public void Attack(GameTime gameTime)
        {
            
            _mainGame.PlayerAttack();
        }
    }
}