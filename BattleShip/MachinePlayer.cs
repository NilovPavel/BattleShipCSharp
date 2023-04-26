// File:    MachinePlayer.cs
// Author:  nilov_pg
// Created: 10 июля 2020 г. 10:36:19
// Purpose: Definition of Class MachinePlayer

using System;

namespace BattleShip
{
    public class MachinePlayer : IPlayer
    {
        private int v1;
        private int v2;

        public MachinePlayer(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

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

        public void MakeShot(out int x, out int y)
        {
            throw new NotImplementedException();
        }
    }
}