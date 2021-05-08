using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameSpel.GameStates;
using SharpDX.Direct2D1.Effects;

namespace MonogameSpel 
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        
        
        public MainGame ()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = @"Content\bin";
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameStateManager.Instance.SetContent(Content);
            GameStateManager.Instance.AddScreen(new MainMenu(GraphicsDevice));
        }
        
        protected override void UnloadContent()
        {
            GameStateManager.Instance.UnloadContent();
        }
        
        protected override void Update(GameTime gameTime)
        {
            GameStateManager.Instance.Update(gameTime);

            
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aqua);

            GameStateManager.Instance.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}