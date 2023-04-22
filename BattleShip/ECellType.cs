using System;

namespace BattleShip
{
    /// <summary>
    /// Типы клеток
    /// </summary>
    public enum ECellType
    {
        /// <summary>
        /// Свободная клетка
        /// </summary>
        free,
        /// <summary>
        /// Живая палуба корабля
        /// </summary>
        alive,
        /// <summary>
        /// Мимо
        /// </summary>
        miss,
        /// <summary>
        /// Ранен
        /// </summary>
        wound,
        /// <summary>
        /// Убит
        /// </summary>
        dead
    }
}