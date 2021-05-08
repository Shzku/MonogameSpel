using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameSpel.GameStates
{
    public class MainMenu : GameState
    {
        private Texture2D flowerTexture;
        private Texture2D menuButtons;
        private SpriteFont font;
        
        private Rectangle[] sourceRectangles;
        
        private Color dGrey = new Color(20, 20, 20, 255);
        private Color dBlue = new Color(17, 20, 25, 255);
        
        private int buttonSelect = 0;
        
        public MainMenu(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            flowerTexture = content.Load<Texture2D>("Spider_Lily");
            font = content.Load<SpriteFont>("Font/HorrorImpactBold");
            menuButtons = content.Load<Texture2D>("Menu_Buttons");

            sourceRectangles = new Rectangle[4];
            sourceRectangles[0] = new Rectangle(0, 0, 102, 42);
            sourceRectangles[1] = new Rectangle(102, 0, 102, 42);
            sourceRectangles[2] = new Rectangle(102, 42, 102, 42);
            sourceRectangles[3] = new Rectangle(0, 42, 102, 42);
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            Keyboard.GetState();
            if (Keyboard.HasBeenPressed(Keys.Up))
            {
                Console.WriteLine("KeyUp");
                if(buttonSelect > 0) buttonSelect--;
                Console.WriteLine(buttonSelect);
            }
            
            if (Keyboard.HasBeenPressed(Keys.Down))
            {
                Console.WriteLine("KeyDown");
                if(buttonSelect < 1) buttonSelect++;
                Console.WriteLine(buttonSelect);
            }

            if (Keyboard.HasBeenPressed(Keys.Enter))
            {
                Console.WriteLine("KeyEnter");
                if (buttonSelect == 0)
                {
                    Console.WriteLine("StartGame");
                    GameStateManager.Instance.ChangeScreen(new MainGame(_graphicsDevice));
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(dBlue);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            
            spriteBatch.Draw(flowerTexture,  new Rectangle(352,32,448,448), Color.White);
            spriteBatch.DrawString(font, ", h N m l", new Vector2(70f,40f), Color.MintCream, 0, new Vector2(1f,1f), 2.5f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(menuButtons, new Rectangle(100,190, 255,105), sourceRectangles[buttonSelect],Color.White);
            spriteBatch.Draw(menuButtons, new Rectangle(100,320,255,105), sourceRectangles[buttonSelect + 2], Color.White);
            
            spriteBatch.End();
        }
    }
}