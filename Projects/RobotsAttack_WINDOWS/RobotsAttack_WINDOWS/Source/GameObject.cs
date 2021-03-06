﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GameObject
{
    ///------------------------------------------------------------------------
    using World;
    ///------------------------------------------------------------------------





    ///-----------------------------------------------------------------------
    ///
    /// <summary>
    /// Основная игровой объект
    /// </summary>
    ///
    ///------------------------------------------------------------------------
    public class AGameObject
    {
        ///--------------------------------------------------------------------
        protected AWorld mWorld = null;
        ///--------------------------------------------------------------------





         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Constructor
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public AGameObject()
        {

        }
        ///--------------------------------------------------------------------





         ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Установка игрового мира
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public void setWorld(AWorld world)
        {
            if (mWorld != null)
            {
                mWorld.remove(this);
            }
            mWorld = world;
            mWorld.append(this);
        }
        ///--------------------------------------------------------------------






        ///--------------------------------------------------------------------
        ///
        /// <summary>
        /// Отрисовка
        /// </summary>
        ///
        ///--------------------------------------------------------------------
        public virtual void render(SpriteBatch spriteBatch, TimeSpan time, float depth)
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
        public virtual void update(TimeSpan time)
        {

        }
        ///--------------------------------------------------------------------



    }
}
