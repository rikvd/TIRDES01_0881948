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
        int shipSpeed = 10;
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipPosition = new Vector2(300.0f, 400.0f);
            shipAppearance = Content.Load<Texture2D>("ship.png");

            base.Initialize();

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            Vector2 shipMovement = new Vector2(0.0f, 0.0f);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                shipMovement += new Vector2(-1.0f, 0.0f)*shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                shipMovement += new Vector2(0.0f, -1.0f) * shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                shipMovement += new Vector2(1.0f, 0.0f) * shipSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                shipMovement += new Vector2(0.0f, 1.0f) * shipSpeed;
            }
            shipPosition += shipMovement;


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(shipAppearance, shipPosition, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
