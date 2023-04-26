// File:    Field.cs
// Author:  nilov_pg
// Created: 16 июля 2020 г. 9:53:46
// Purpose: Definition of Class Field

using System;

namespace BattleShip
{
    public class Field
    {
        private void Initialization()
        {
            this.cells = new Cell[this.width * this.height];
            for (int y = 0; y < this.height; y++)
                for (int x = 0; x < this.width; x++)
                    this.cells[y * this.width + x] = new Cell(x, y, ECellType.empty);
        }

        public void ShowShips()
        {

        }

        private int height;
        private int width;

        private Cell[] cells;

        public Cell[] Cells
        {
            get
            {
                return this.cells;
            }
        }

        public ECellType GetCellType(int x, int y)
        {
            return this.cells[y * this.width + x].getECellType();
        }

        public void SetCellType(int x, int y, ECellType eCellType)
        {
            if (y * this.width + x >= 100) 
                return;
            this.cells[y * this.width + x].setECellType(eCellType);
        }

        public Field(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.Initialization();
        }

        public int getHeight()
        {
            return this.height;
        }

        public int getWidth()
        {
            return this.width;
        }

    }
}