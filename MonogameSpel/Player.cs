using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameSpel
{
    public class Player
    {
        public int PosX;
        public int PosY;

        private int spriteHeight;
        private int spriteWidth;
        
        private Texture2D playerSprite;
        private Rectangle[] _sourceRectangles;
        public Player()
        {
            spriteHeight = 62;
            spriteWidth = 32;
        }

        public void LoadContent(ContentManager content)
        {
            playerSprite = content.Load<Texture2D>("Player");

            _sourceRectangles = new Rectangle[6];
            _sourceRectangles[0] = new Rectangle(0, 0, spriteWidth, spriteHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(playerSprite, new Rectangle(30, 30, spriteWidth*3, spriteHeight*3), _sourceRectangles[0], Color.White);
            spriteBatch.End();
        }
    }
}