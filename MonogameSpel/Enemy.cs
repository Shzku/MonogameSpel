using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameSpel
{
    public class Enemy
    {
        private int _posX;
        private int _posY;

        private readonly int _spriteHeight;
        private readonly int _spriteWidth;

        public Rectangle Hitbox;
        
        private Texture2D _enemySprite;
        public Enemy(int posY)
        {
            _posX = 600;
            _posY = posY;
            
            _spriteHeight = 62;
            _spriteWidth = 39;
            
            Hitbox = new Rectangle(_posX, _posY, _spriteWidth, _spriteHeight*2);
        }
        
        public void LoadContent(ContentManager content)
        {
            _enemySprite = content.Load<Texture2D>("Player");
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            spriteBatch.Draw(_enemySprite, new Rectangle(_posX, _posY, _spriteWidth * 2, _spriteHeight * 2),
                new Rectangle(0, 0, _spriteWidth, _spriteHeight), Color.Red, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            spriteBatch.End();
        }
    }
}