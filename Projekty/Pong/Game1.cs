using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _pixel;


        private int x1 = 20;
        private int y1 = 100;
        private int x2 = 760;
        private int y2 = 100;




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

            // TODO: use this.Content to load your game content here

            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ovladaniSipky();
            ovladaniWASD();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            int sizex = 10;
            int sizey = 100;
            Color color = Color.Black;

            _spriteBatch.Begin();

            _spriteBatch.Draw(_pixel, new Rectangle(x1, y1, sizex, sizey), color);
            _spriteBatch.Draw(_pixel, new Rectangle(x2, y2, sizex, sizey), color);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public void ovladaniSipky()  
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                y2 -= 5;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                y2 += 5;
            }


        }
        public void ovladaniWASD()
        {
            
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.W))
            {
                y1 -= 5;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                y1 += 5;
            }


        }

    }
    
}
