// File:    MachinePlayer.cs
// Author:  nilov_pg
// Created: 10 июля 2020 г. 10:36:19
// Purpose: Definition of Class MachinePlayer

using System;

namespace BattleShip
{
    public class MachinePlayer : IPlayer
    {
        public void CanTakeCell(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void CalcNextCoordinats(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int GetWoundCells(Cell firstWoundCell, Cell lastWoundCell)
        {
            throw new NotImplementedException();
        }

        public int GetCellIndexZeroWound()
        {
            throw new NotImplementedException();
        }

        public int GetCellIndexOneWound(Cell firstWoundCell)
        {
            throw new NotImplementedException();
        }

        public int GetCellIndexMultyplyWound(Cell firstWoundCell, Cell lastWoundCell)
        {
            throw new NotImplementedException();
        }

        public void MakeShot(int x, int y)
        {
            throw new NotImplementedException();
        }

        public MachinePlayer()
        {
            throw new NotImplementedException();
        }

    }
}