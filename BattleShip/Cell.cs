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
            return this.x;
        }

        public void setX(int newX)
        {
            this.x = newX;
        }

        public int getY()
        {
           return this.y;
        }

        public void setY(int newY)
        {
            this.y = newY;
        }

        public ECellType getECellType()
        {
            return this.eCellType;
        }

        public void setECellType(ECellType newECellType)
        {
            this.eCellType = newECellType;
        }

        public Cell(int x, int y, ECellType eCellType)
        {
            this.x = x;
            this.y = y;
            this.eCellType = eCellType;
        }

    }
}