using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameObject
{
    ///------------------------------------------------------------------------





    ///-----------------------------------------------------------------------
    ///
    /// <summary>
    /// Игрок который управляет роботом
    /// </summary>
    ///
    ///------------------------------------------------------------------------
    public class APlayer
                    :
                        AGameObject
    {
        ///--------------------------------------------------------------------
        private ARobot mRobot = null;
        ///--------------------------------------------------------------------






        ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Constructor
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public APlayer(ARobot robot)
        {
            mRobot = robot;
            mRobot.position = new Vector2(100, 100);
        }
        ///--------------------------------------------------------------------







        ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Отрисовка
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public override void render(SpriteBatch spriteBatch, TimeSpan time, float depth)
        {

        }
        ///--------------------------------------------------------------------






         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Игровая логика
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public override void update(TimeSpan time)
        {
            Vector2 direct = Vector2.Zero;
            if (isControlsDown())   { direct += new Vector2(0, +1); }
            if (isControlsUp())     { direct += new Vector2(0, -1); }
            if (isControlsLeft())   { direct += new Vector2(-1, 0); }
            if (isControlsRight())  { direct += new Vector2(+1, 0); }
            mRobot.move(direct);
        }
        ///--------------------------------------------------------------------




         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// проверка нажатия кнопок управления
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        private bool isControlsLeft()
        {
            return (
                GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed
                ||
                Keyboard.GetState().IsKeyDown(Keys.Left));
      
        }
        ///--------------------------------------------------------------------




         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// проверка нажатия кнопок управления
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        private bool isControlsRight()
        {
            return (
                GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed
                ||
                Keyboard.GetState().IsKeyDown(Keys.Right));

        }
        ///--------------------------------------------------------------------



         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// проверка нажатия кнопок управления
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        private bool isControlsUp()
        {
            return (
                GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed
                ||
                Keyboard.GetState().IsKeyDown(Keys.Up));

        }
        ///--------------------------------------------------------------------




         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// проверка нажатия кнопок управления
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        private bool isControlsDown()
        {
            return (
                GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed
                ||
                Keyboard.GetState().IsKeyDown(Keys.Down));

        }
        ///--------------------------------------------------------------------



         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// проверка нажатия кнопок управления
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        private bool isControlsAttack()
        {
            return (
                GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed
                ||
                Keyboard.GetState().IsKeyDown(Keys.Space));

        }
        ///--------------------------------------------------------------------

    }
}
