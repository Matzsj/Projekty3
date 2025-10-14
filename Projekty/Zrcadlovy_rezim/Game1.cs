using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zrcadlovy rezim
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _pixel;

        int x = 0;
        int y = 100;
        int x2 = 400;
        int y2 = 100;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Ovladani();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here


            int size = 50;
            Color color1 = Color.Black;
            Color color2 = Color.Gray;


            _spriteBatch.Begin();


            _spriteBatch.Draw(_pixel, new Rectangle(x, y, size, size), color1);

            _spriteBatch.Draw(_pixel, new Rectangle(x2, y2, size, size), color2);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public void Ovladani()
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.A))
            {
                x -= 5;
                x2 -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                x += 5;
                x2 += 5;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                y -= 5;
                y2 -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                y += 5;
                y2 += 5;
            }
        }
        
    }
}
