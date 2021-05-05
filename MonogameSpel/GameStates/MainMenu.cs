using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameSpel.GameStates
{
    public class MainMenu : GameState
    {
        private Texture2D flowerTexture;
        private SpriteFont font;
        
        private Color dGrey = new Color(20, 20, 20, 255);
        private Color dBlue = new Color(17, 20, 25, 255);
        
        public MainMenu(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            var startButton = new Button( );
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            flowerTexture = content.Load<Texture2D>("Spider_Lily");
            font = content.Load<SpriteFont>("Font/HorrorImpactBold");
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(dBlue);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            
            spriteBatch.Draw(flowerTexture,  new Rectangle(352,32,448,448), Color.White);
            spriteBatch.DrawString(font, ", h N m l", new Vector2(70f,40f), Color.MintCream, 0, new Vector2(1f,1f), 2.5f, SpriteEffects.None, 0.5f);
            
            spriteBatch.End();
        }
    }
}