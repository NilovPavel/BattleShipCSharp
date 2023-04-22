// File:    Cell.cs
// Author:  nilov_pg
// Created: 16 июля 2020 г. 9:51:06
// Purpose: Definition of Class Cell

using System;

namespace BattleShip
{
    public class Cell
    {
        private int x;
        private int y;
        private ECellType eCellType;

        public int getX()
        {
            throw new NotImplementedException();
        }

        public void setX(int newX)
        {
            throw new NotImplementedException();
        }

        public int getY()
        {
            throw new NotImplementedException();
        }

        public void setY(int newY)
        {
            throw new NotImplementedException();
        }

        public ECellType getECellType()
        {
            throw new NotImplementedException();
        }

        public void setECellType(ECellType newECellType)
        {
            throw new NotImplementedException();
        }

        public Cell(int x, int y, ECellType eCellType)
        {
            this.x = x;
            this.y = y;
            this.eCellType = eCellType;
        }

    }
}