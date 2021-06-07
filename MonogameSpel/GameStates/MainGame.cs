using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace MonogameSpel.GameStates
{
    public class MainGame : GameState
    {
        private Color dBlue = new Color(17, 20, 25, 255);
        
        public Player player;
        public List<Enemy> Enemies;

        private Texture2D pixel;

        public GraphicsDevice graphics;

        private int pointCounter;

        private Random rnd;

        private SpriteFont font;
        public MainGame(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            graphics = graphicsDevice;
            
            player = new Player(this);
            Enemies = new List<Enemy>();
            
            pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });

            rnd = new Random();
        }

        public override void Initialize()
        {
            Enemies.Add(new Enemy(10, 600));
            Enemies.Add(new Enemy(175, 600));
            Enemies.Add(new Enemy(350, 600));
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font/azukiB");
            player.LoadContent(content);
            foreach (var enemy in Enemies)
            {
                enemy.LoadContent(content);
            }
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            foreach (var enemy in Enemies)
            {
                if (player._hitBox.Intersects(enemy.Hitbox))
                {
                    pointCounter++;
                    enemy._posX = rnd.Next(700);
                    enemy._posY = rnd.Next(450);
                }
                enemy.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(dBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, Convert.ToString(pointCounter), new Vector2(0f,0f), Color.MintCream, 0, new Vector2(1f,1f), 2.5f, SpriteEffects.None, 0.5f);
            //spriteBatch.Draw(pixel, player._hitBox, Color.Orange);
            spriteBatch.End();

            foreach (var enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
        }

        public void PlayerAttack()
        {
            foreach (var i in Enemies)
            {
                if (new Rectangle(player._hitBox.Right, player._hitBox.Center.Y,player._hitBox.Width,0).Intersects(i.Hitbox))
                {
                    Console.WriteLine("Hit Enemy");
                    Enemies.Remove(i);
                    break;
                }
                else
                {
                    Console.WriteLine("No Kill");
                }
            }
        }
    }
}