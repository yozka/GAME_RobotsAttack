using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GameObject
{
   ///------------------------------------------------------------------------





     ///-----------------------------------------------------------------------
    ///
    /// <summary>
    /// Робот
    /// </summary>
    ///
    ///------------------------------------------------------------------------
    public class ARobot
                    :
                        AGameObject
    {
        ///--------------------------------------------------------------------
        private readonly string mSpriteName = null;
        private Texture2D   mSprite     = null;
        private Vector2     mPosition   = Vector2.Zero;
        private Vector2     mOrigin     = Vector2.Zero;
        private Vector2     mSize       = Vector2.Zero;
        
        private float       mSpeed      = 100.0f; //скорость движения
        private Vector2     mMoveDirect = Vector2.Zero; //направление движения 
        private bool        mMoved      = false; //движение 
        ///--------------------------------------------------------------------






         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Constructor
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public ARobot(string spriteName)
        {
            mSpriteName = spriteName;
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
            if (mSprite == null)
            {
                mSprite = mWorld.sprites[mSpriteName];
                mSize = new Vector2(mSprite.Width, mSprite.Height);
                mOrigin = mSize / 2;
            }

            spriteBatch.Draw(mSprite, mPosition, null, Color.White, 0.0f, mOrigin, 1.0f, SpriteEffects.None, depth);
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
            if (mMoved)
            {
                var pt = mMoveDirect * (float)time.TotalMilliseconds;
                pt += mPosition;
                /*
                if (mWorld.isCollision(pt, this))
                {
                    //остановка движения
                    mMoved = false;
                    mMoveDirect = Vector2.Zero;
                }
                else*/
                {
                    //движемся
                    mPosition = pt;
                }
            }
        }
        ///--------------------------------------------------------------------





         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// позиция робота
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public Vector2 position
        {
            get
            {
                return mPosition;
            }
            set
            {
                mPosition = value;
            }

        }
        ///--------------------------------------------------------------------





         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// перемещение робота
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public void move(Vector2 direct)
        {
            if (direct == Vector2.Zero)
            {
                //остановка движения
                mMoved = false;
                return;
            }

            mMoved = true;

            direct.Normalize();
            mMoveDirect = direct * (mSpeed / 100.0f);
         }
        ///--------------------------------------------------------------------

    }
}
