using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TIRDES01_0881948
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        Vector2 shipPosition;
        Texture2D shipAppearance;
        Vector2 astPosition;
        Texture2D astAppearance;
        Vector2 plasmaPosition;
        Texture2D plasmaAppearance;

        int shipSpeed = 4;
        bool astAlive = true;
        bool plasmaAlive = false;
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipPosition = new Vector2(300.0f, 400.0f);
            shipAppearance = Content.Load<Texture2D>("ship.png");

            astPosition = new Vector2(300.0f, 50.0f);
            
            astAppearance = Content.Load<Texture2D>("asteroid.png");

            plasmaAppearance = Content.Load<Texture2D>("plasmaSmall.png");

            base.Initialize();

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            Vector2 shipMovement = new Vector2(0.0f, 0.0f);
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                shipMovement += new Vector2(-1.0f, 0.0f) * shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                shipMovement += new Vector2(1.0f, 0.0f) * shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space)&&(plasmaAlive == false))
            {

                plasmaPosition = new Vector2((shipPosition.X+(shipAppearance.Width/2)-(plasmaAppearance.Width/2)), shipPosition.Y);
                plasmaAlive = true;
            }
            if (plasmaPosition.Y < (astPosition.Y + astAppearance.Height) && (plasmaPosition.X < astPosition.X + astAppearance.Width) && plasmaPosition.X + (plasmaAppearance.Width/2) > astPosition.X)
            {
                plasmaAlive = false;
                astAlive = false;
            }
            shipPosition += shipMovement;
            plasmaPosition += new Vector2(0.0f, -5.0f);
            if ((shipPosition.X < (astPosition.X + 20)) && (shipPosition.X > (astPosition.X - 50)))
            {
                if ((shipPosition.Y > (astPosition.Y - 20)) && (shipPosition.Y < (astPosition.Y + 50)))
                {
                    astAlive = false;
                }
            }
            if (plasmaPosition.Y <= 0)
            {
                plasmaAlive = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                astAlive = true;
            }
            if (!astAlive)
            {
                Random rnd = new Random();
                int posX = rnd.Next(1, Window.ClientBounds.Width);
                float pos = Convert.ToSingle(posX);
                astPosition = new Vector2(pos, 50.0f);
                astAlive = true;
            }

            if ((shipPosition.X + shipAppearance.Width < 0))
            {
                shipPosition.X = Convert.ToSingle(Window.ClientBounds.Width);
            }
            if (shipPosition.X > Convert.ToSingle(Window.ClientBounds.Width))
            {
                shipPosition.X = -shipAppearance.Width;
            }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (astAlive)
            {
                spriteBatch.Draw(astAppearance, astPosition, Color.Red);
            }
            spriteBatch.Draw(shipAppearance, shipPosition, Color.White);
            if (plasmaAlive)
            {
                spriteBatch.Draw(plasmaAppearance, plasmaPosition, Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
