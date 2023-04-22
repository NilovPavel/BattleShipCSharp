// File:    IUserManipulator.cs
// Author:  nilov_pg
// Created: 10 июля 2020 г. 10:41:07
// Purpose: Definition of Interface IUserManipulator

using System;

namespace BattleShip
{
    public interface IUserManipulator
    {
        void MakeStep(out int[] x, out int[] y);
    }
}