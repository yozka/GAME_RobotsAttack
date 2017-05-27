using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RobotsAttack_WINDOWS
{
    ///------------------------------------------------------------------------
    using World;
    ///------------------------------------------------------------------------






     ///-----------------------------------------------------------------------
    ///
    /// <summary>
    /// Основная игра
    /// </summary>
    ///
    ///------------------------------------------------------------------------
    public class AProgram : Game
    {
        ///------------------------------------------------------------------------
        private readonly GraphicsDeviceManager  mGraphics       = null;
        private SpriteBatch                     mSpriteBatch    = null;

        private readonly AWorld                 mWorld          = null;
        ///------------------------------------------------------------------------
        



        
         ///-----------------------------------------------------------------------
        ///
        /// <summary>
        /// Constructor
        /// </summary>
        ///
        ///------------------------------------------------------------------------
        public AProgram()
        {
            mGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            mWorld = new AWorld(800, 600);
        }
        ///------------------------------------------------------------------------





         ///-----------------------------------------------------------------------
        ///
        /// <summary>
        /// Инциализация игры
        /// </summary>
        ///
        ///------------------------------------------------------------------------
        protected override void Initialize()
        {

            base.Initialize();
        }
        ///------------------------------------------------------------------------





         ///-----------------------------------------------------------------------
        ///
        /// <summary>
        /// Загруза игровых ресурсов
        /// </summary>
        ///
        ///------------------------------------------------------------------------
        protected override void LoadContent()
        {
            mSpriteBatch = new SpriteBatch(GraphicsDevice);

            

        }
        ///------------------------------------------------------------------------





         ///-----------------------------------------------------------------------
        ///
        /// <summary>
        /// Выгрузка игровых ресурсов
        /// </summary>
        ///
        ///------------------------------------------------------------------------
        protected override void UnloadContent()
        {
            
        }
        ///------------------------------------------------------------------------





         ///-----------------------------------------------------------------------
        ///
        /// <summary>
        /// Ировой цикл
        /// </summary>
        ///
        ///------------------------------------------------------------------------
        protected override void Update(GameTime gameTime)
        {
            /*
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                */

            var time = gameTime.ElapsedGameTime;
            mWorld.update(time);
        }
        ///------------------------------------------------------------------------





         ///-----------------------------------------------------------------------
        ///
        /// <summary>
        /// отрисовка игровых объектов
        /// </summary>
        ///
        ///------------------------------------------------------------------------
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var time = gameTime.ElapsedGameTime;
            mWorld.draw(mSpriteBatch, time);
        }
        ///------------------------------------------------------------------------



    }
}
