// File:    IPlayer.cs
// Author:  nilov_pg
// Created: 10 июля 2020 г. 9:49:46
// Purpose: Definition of Interface IPlayer

using System;

namespace BattleShip
{
    public interface IPlayer
    {
        void MakeShot(out int x, out int y);
    }
}