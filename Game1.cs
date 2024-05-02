using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_5___Add_an_Intro_Screen
{
    enum Screen
    {
        Intro,
        TribbleYard,
        End
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Screen screen;
        MouseState mouseState;
        Texture2D greyTexture, creamTexture, orangeTexture, brownTexture, backgroundTexture, tribbleTexture, endTexture;
        Rectangle greyTribRect, creamTribRect, orangeTribRect, brownTribRect, bgRect;
        Vector2 greySpeed, creamSpeed, orangeSpeed, brownSpeed;
        SpriteFont textFont;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            screen = Screen.Intro;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            this.Window.Title = "Intro Screens";

            greyTribRect = new Rectangle(300, 10, 100, 100);
            greySpeed = new Vector2(2, 2);
            creamTribRect = new Rectangle(150, 25, 100, 100);
            creamSpeed = new Vector2(3, 0);
            orangeTribRect = new Rectangle(550, 250, 100, 100);
            orangeSpeed = new Vector2(0, 3);
            brownTribRect = new Rectangle(10, 300, 100, 100);
            brownSpeed = new Vector2(4, 5);
            bgRect = new Rectangle(0, 0, 800, 500);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            greyTexture = Content.Load<Texture2D>("tribbleGrey");
            creamTexture = Content.Load<Texture2D>("tribbleCream");
            orangeTexture = Content.Load<Texture2D>("tribbleOrange");
            brownTexture = Content.Load<Texture2D>("tribbleBrown");
            backgroundTexture = Content.Load<Texture2D>("background");
            tribbleTexture = Content.Load<Texture2D>("pompom");
            endTexture = Content.Load<Texture2D>("fiery landscape");
            textFont = Content.Load<SpriteFont>("help");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;

            }
            else if (screen == Screen.TribbleYard)
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                    screen = Screen.End;
                   
                greyTribRect.X += (int)greySpeed.X;
                greyTribRect.Y += (int)greySpeed.Y;

                if (greyTribRect.Right > _graphics.PreferredBackBufferWidth || greyTribRect.Left < 0)
                {
                    greySpeed.X *= -1;
                }
                if (greyTribRect.Bottom > _graphics.PreferredBackBufferHeight || greyTribRect.Top < 0)
                {
                    greySpeed.Y *= -1;
                }

                creamTribRect.X += (int)creamSpeed.X;
                creamTribRect.Y += (int)creamSpeed.Y;

                if (creamTribRect.Right > _graphics.PreferredBackBufferWidth || creamTribRect.Left < 0)
                {
                    creamSpeed.X *= -1;
                }

                orangeTribRect.X += (int)orangeSpeed.X;
                orangeTribRect.Y += (int)orangeSpeed.Y;

                if (orangeTribRect.Bottom > _graphics.PreferredBackBufferHeight || orangeTribRect.Top < 0)
                {
                    orangeSpeed.Y *= -1;
                }

                brownTribRect.X += (int)brownSpeed.X;
                brownTribRect.Y += (int)brownSpeed.Y;

                if (brownTribRect.Right > _graphics.PreferredBackBufferWidth || brownTribRect.Left < 0)
                {
                    brownSpeed.X *= -1;
                }
                if (brownTribRect.Bottom > _graphics.PreferredBackBufferHeight || brownTribRect.Top < 0)
                {
                    brownSpeed.Y *= -1;
                }
            }
            else if (screen == Screen.End) 
            {

                if (mouseState.LeftButton == ButtonState.Pressed)
                    Exit();

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(backgroundTexture, bgRect, Color.White);
                _spriteBatch.DrawString(textFont, "Left Click to Continue", new Vector2(250, 400), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribbleTexture, bgRect, Color.White);
                _spriteBatch.Draw(greyTexture, greyTribRect, Color.White);
                _spriteBatch.Draw(creamTexture, creamTribRect, Color.White);
                _spriteBatch.Draw(orangeTexture, orangeTribRect, Color.White);
                _spriteBatch.Draw(brownTexture, brownTribRect, Color.White);
                _spriteBatch.DrawString(textFont, "Right Click to Continue", new Vector2(10, 0), Color.White);
            }
            else if (screen == Screen.End)
            {
                _spriteBatch.Draw(endTexture, bgRect, Color.White);
                _spriteBatch.DrawString(textFont, "Left Click to End", new Vector2(550, 430), Color.White);

            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}