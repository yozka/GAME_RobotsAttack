using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RobotsAttack_WINDOWS
{
    ///------------------------------------------------------------------------
    using World;
    using GameObject;
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

            mWorld = new AWorld(1024, 720);
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

            int wd = 1024;
            int hd = 720;


            mGraphics.PreferredBackBufferWidth = wd;
            mGraphics.PreferredBackBufferHeight = hd;
            mGraphics.ApplyChanges();

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

            loadTexture("robot_1");


            //создаем роботов
            var robot = new ARobot("robot_1");
            
            mWorld.append(robot);
            mWorld.append(new APlayer(robot));
        }
        ///------------------------------------------------------------------------




         ///-----------------------------------------------------------------------
        ///
        /// <summary>
        /// Загруза игровых ресурсов
        /// </summary>
        ///
        ///------------------------------------------------------------------------
        private void loadTexture(string name)
        {
            var sprite = Content.Load<Texture2D>(name);
            mWorld.sprites[name] = sprite;
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
            GraphicsDevice.Clear(Color.White);

            var time = gameTime.ElapsedGameTime;
            mWorld.draw(mSpriteBatch, time);
        }
        ///------------------------------------------------------------------------



    }
}
