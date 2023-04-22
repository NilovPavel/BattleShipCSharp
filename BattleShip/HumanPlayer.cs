// File:    HumanPlayer.cs
// Author:  nilov_pg
// Created: 10 июля 2020 г. 10:36:30
// Purpose: Definition of Class HumanPlayer

using System;

namespace BattleShip
{
    public class HumanPlayer : IPlayer
    {
        public void MakeShot(int x, int y)
        {
            throw new NotImplementedException();
        }

        public HumanPlayer()
        {
            throw new NotImplementedException();
        }

        public IUserManipulator iUserManipulator;

    }
}