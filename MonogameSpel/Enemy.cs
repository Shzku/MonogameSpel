using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameSpel
{
    public class Enemy
    {
        public int _posX;
        public int _posY;

        private readonly int _spriteHeight;
        private readonly int _spriteWidth;

        public Rectangle Hitbox;
        
        private Texture2D _enemySprite;
        public Enemy(int posY, int posX)
        {
            _posX = posX;
            _posY = posY;
            
            _spriteHeight = 120;
            _spriteWidth = 120;
            
            Hitbox = new Rectangle(_posX, _posY, _spriteWidth, _spriteHeight*2);
        }
        
        public void LoadContent(ContentManager content)
        {
            _enemySprite = content.Load<Texture2D>("among_us_sprite_sheet");
        }

        public void Update(GameTime gameTime)
        {
            Hitbox.Location = new Point(_posX, _posY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_enemySprite, new Rectangle(_posX, _posY, _spriteWidth, _spriteHeight),
                new Rectangle(893, 764, _spriteWidth, _spriteHeight), Color.Red, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}