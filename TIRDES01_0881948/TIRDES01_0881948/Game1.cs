using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        int shipSpeed = 5;
        bool astAlive = true;
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipPosition = new Vector2(300.0f, 400.0f);
            shipAppearance = Content.Load<Texture2D>("ship.png");

            astPosition = new Vector2(100.0f, 200.0f);
            astAppearance = Content.Load<Texture2D>("asteroid.png");


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
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                shipMovement += new Vector2(0.0f, -1.0f) * shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                shipMovement += new Vector2(1.0f, 0.0f) * shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                shipMovement += new Vector2(0.0f, 1.0f) * shipSpeed;
            }
            shipPosition += shipMovement;
            if ((shipPosition.X < (astPosition.X + 20)) && (shipPosition.X > (astPosition.X - 50)))
            {
                if ((shipPosition.Y > (astPosition.Y - 20)) && (shipPosition.Y < (astPosition.Y + 50)))
                {
                    astAlive = false;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
astAlive = true;            }
            /*
            if (shipPosition.X > (astPosition.X + 150) && (shipPosition.X < (astPosition.X)))
            {
                if (shipPosition.Y < (astPosition.Y + 150) && (shipPosition.Y > (astPosition.Y)))
                {
                    astAlive = false;
                }
            }*/


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
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
