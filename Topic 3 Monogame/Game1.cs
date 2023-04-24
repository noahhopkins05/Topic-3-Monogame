using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Emit;

namespace Topic_3_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle brownTribbleRect, creamTribbleRect, grayTribbleRect, orangeTribbleRect;
        Vector2 tribbleBrownSpeed, tribbleCreamSpeed, tribbleGraySpeed, tribbleOrangeSpeed;
        Texture2D brownTribble, creamTribble, grayTribble, orangeTribble, backgroundTexture;
        Random r = new Random();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            brownTribbleRect = new Rectangle(r.Next(0, _graphics.PreferredBackBufferWidth - 50), r.Next(0, _graphics.PreferredBackBufferHeight - 50), 50, 50);
            creamTribbleRect = new Rectangle(r.Next(0, _graphics.PreferredBackBufferWidth - 50), r.Next(0, _graphics.PreferredBackBufferHeight - 50), 50, 50);
            grayTribbleRect = new Rectangle(r.Next(0, _graphics.PreferredBackBufferWidth - 50), r.Next(0, _graphics.PreferredBackBufferHeight - 50), 50, 50);
            orangeTribbleRect = new Rectangle(r.Next(0, _graphics.PreferredBackBufferWidth - 50), r.Next(0, _graphics.PreferredBackBufferHeight - 50), 50, 50);

            tribbleBrownSpeed = new Vector2(r.Next(-6, 6), r.Next(-6, 6));
            tribbleCreamSpeed = new Vector2(r.Next(-6, 6), r.Next(-6 , 6));
            tribbleGraySpeed = new Vector2(r.Next(-6, 6), r.Next(-6, 6));
            tribbleOrangeSpeed = new Vector2(r.Next(-6, 6), r.Next(-6, 6));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            brownTribble = Content.Load<Texture2D>("tribbleBrown");
            creamTribble = Content.Load<Texture2D>("tribbleCream");
            grayTribble = Content.Load<Texture2D>("tribbleGrey");
            orangeTribble = Content.Load<Texture2D>("tribbleOrange");
            backgroundTexture = Content.Load<Texture2D>("backgroundstartrek");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            brownTribbleRect.X += (int)tribbleBrownSpeed.X;
            brownTribbleRect.Y += (int)tribbleBrownSpeed.Y;

            creamTribbleRect.X += (int)tribbleCreamSpeed.X;
            creamTribbleRect.Y += (int)tribbleCreamSpeed.Y;

            grayTribbleRect.X += (int)tribbleGraySpeed.X;
            grayTribbleRect.Y += (int)tribbleGraySpeed.Y;

            orangeTribbleRect.X += (int)tribbleOrangeSpeed.X;
            orangeTribbleRect.Y += (int)tribbleOrangeSpeed.Y;

            if (brownTribbleRect.Right > _graphics.PreferredBackBufferWidth || brownTribbleRect.Left < 0)
                tribbleBrownSpeed.X = tribbleBrownSpeed.X * -1;
            if (brownTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || brownTribbleRect.Top < 0)
                tribbleBrownSpeed.Y = tribbleBrownSpeed.Y * -1;

            if (creamTribbleRect.Right > _graphics.PreferredBackBufferWidth + 50)
                creamTribbleRect.X = -50;
            if (creamTribbleRect.Bottom > _graphics.PreferredBackBufferHeight + 50)
                creamTribbleRect.Y = -50;
            else if (creamTribbleRect.Right < -50)
                creamTribbleRect.X = _graphics.PreferredBackBufferWidth;
            else if (creamTribbleRect.Bottom < -50)
                creamTribbleRect.Y = _graphics.PreferredBackBufferHeight;


            if (grayTribbleRect.Right > _graphics.PreferredBackBufferWidth || grayTribbleRect.Left < 0)
                tribbleGraySpeed.X = tribbleGraySpeed.X * -1;
            if (grayTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || grayTribbleRect.Top < 0)
                tribbleGraySpeed.Y = tribbleGraySpeed.Y * -1;

            if (orangeTribbleRect.Right > _graphics.PreferredBackBufferWidth || orangeTribbleRect.Left < 0)
            {
                orangeTribbleRect.X = r.Next(0, _graphics.PreferredBackBufferWidth);
                orangeTribbleRect.Y = r.Next(0, _graphics.PreferredBackBufferHeight);
                tribbleOrangeSpeed = new Vector2(r.Next(-7, 7), r.Next(-7, 7));
            }
            if (orangeTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || orangeTribbleRect.Top < 0)
            {
                orangeTribbleRect.X = r.Next(0, _graphics.PreferredBackBufferWidth);
                orangeTribbleRect.Y = r.Next(0, _graphics.PreferredBackBufferHeight);
                tribbleOrangeSpeed = new Vector2(r.Next(-7, 7), r.Next(-7, 7));
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
            _spriteBatch.Draw(brownTribble, brownTribbleRect, Color.White);
            _spriteBatch.Draw(creamTribble, creamTribbleRect, Color.White);
            _spriteBatch.Draw(grayTribble, grayTribbleRect, Color.White);
            _spriteBatch.Draw(orangeTribble, orangeTribbleRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}