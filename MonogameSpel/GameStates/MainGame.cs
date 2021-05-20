using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameSpel.GameStates
{
    public class MainGame : GameState
    {
        private Color dBlue = new Color(17, 20, 25, 255);
        
        private Player _player;
        public Enemy[] _enemies;
        public MainGame(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            _player = new Player();
            _enemies = new Enemy[3];
        }

        public override void Initialize()
        {
            _enemies[0] = new Enemy(10);
            _enemies[1] = new Enemy(175);
            _enemies[2] = new Enemy(350);
        }

        public override void LoadContent(ContentManager content)
        {
            _player.LoadContent(content);
            _enemies[0].LoadContent(content);
            _enemies[1].LoadContent(content);
            _enemies[2].LoadContent(content);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            _enemies[0].Update(gameTime);
            _enemies[1].Update(gameTime);
            _enemies[2].Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(dBlue);
            
            _enemies[0].Draw(spriteBatch);
            _enemies[1].Draw(spriteBatch);
            _enemies[2].Draw(spriteBatch);
            _player.Draw(spriteBatch);
        }
    }
}