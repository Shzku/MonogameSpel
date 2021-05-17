using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameSpel.GameStates
{
    public class MainGame : GameState
    {
        private Color dBlue = new Color(17, 20, 25, 255);
        
        private Player _player;
        public MainGame(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            _player = new Player();
        }

        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content)
        {
            _player.LoadContent(content);
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

            _player.Draw(spriteBatch);
        }
    }
}