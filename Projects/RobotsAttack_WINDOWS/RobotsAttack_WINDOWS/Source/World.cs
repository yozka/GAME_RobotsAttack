using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace World
{
    ///------------------------------------------------------------------------
    using GameObject;
    ///------------------------------------------------------------------------






    ///-----------------------------------------------------------------------
    ///
    /// <summary>
    /// Игровой мир
    /// </summary>
    ///
    ///------------------------------------------------------------------------
    public class AWorld
    {
        ///--------------------------------------------------------------------
        private readonly List<AGameObject> mObjects = new List<AGameObject>();
        private readonly List<AGameObject> mAppends = new List<AGameObject>();
        private readonly List<AGameObject> mRemoves = new List<AGameObject>();
        private bool mLook = false; //флаг того что данные заблокированы
        ///--------------------------------------------------------------------



        ///--------------------------------------------------------------------
        private readonly int mWidth     = 0; //размерность карты
        private readonly int mHeight    = 0;
        ///--------------------------------------------------------------------


        ///--------------------------------------------------------------------
        public readonly Dictionary<string, Texture2D> sprites = new Dictionary<string, Texture2D>();
        ///--------------------------------------------------------------------





        ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Constructor
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public AWorld(int width, int height)
        {
            mWidth  = width;
            mHeight = height;
        }
        ///--------------------------------------------------------------------






         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Отрисовка
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public void draw(SpriteBatch spriteBatch, TimeSpan time)
        {
            mLook = true;
            spriteBatch.Begin();
            float depth = 0.01f;
            foreach (var obj in mObjects)
            {
                obj.render(spriteBatch, time, depth);
                depth += 0.005f;
            }
            spriteBatch.End();
            mLook = false;
        }
        ///--------------------------------------------------------------------






         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Игровая логика
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public void update(TimeSpan time)
        {
            if (mAppends.Count > 0)
            {
                mObjects.AddRange(mAppends);
                mAppends.Clear();
            }

            if (mRemoves.Count > 0)
            {
                foreach(var obj in mRemoves)
                {
                    mObjects.Remove(obj);
                }
                mRemoves.Clear();
            }

            mLook = true;
            foreach (var obj in mObjects)
            {
                obj.update(time);
            }
            mLook = false;
        }
        ///--------------------------------------------------------------------






         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// проверка, есть ли в мире данный игровой объект
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public bool isContains(AGameObject obj)
        {
            if (mRemoves.Contains(obj))
            {
                return false;
            }
            
            if (mObjects.Contains(obj))
            {
                return true;
            }

            if (mAppends.Contains(obj))
            {
                return true;
            }
            return false;
        }
        ///--------------------------------------------------------------------





         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Добавление игрового объекта в поицию мира
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public void append(AGameObject obj)
        {
            if (isContains(obj))
            {
                return; //игровой объект уже есть
            }

            if (mLook)
            {
                mAppends.Add(obj);
            }
            else
            {
                mObjects.Add(obj);
            }
            obj.setWorld(this);
        }
        ///--------------------------------------------------------------------




         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Удаление игрового объекта из мира
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public void remove(AGameObject obj)
        {
            if (!isContains(obj))
            {
                //игрового объекта уже нет
                return;
            }

            if (mLook)
            {
                mRemoves.Add(obj);
            }
            else
            {
                mObjects.Remove(obj);
            }
            obj.setWorld(null);
        }
        ///--------------------------------------------------------------------

    }
}
