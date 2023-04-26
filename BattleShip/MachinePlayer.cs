// File:    MachinePlayer.cs
// Author:  nilov_pg
// Created: 10 июля 2020 г. 10:36:19
// Purpose: Definition of Class MachinePlayer

using System;

namespace BattleShip
{
    public class MachinePlayer : IPlayer
    {
        private Field enemyField;
        private Ship[] enemyShips;
        private int[] shipSizes;
        private int width;
        private int height;

        public MachinePlayer(int[] shipSizes, int width, int height)
        {
            this.shipSizes = shipSizes;
            this.width = width;
            this.height = height;
            this.Initialization();
        }

        private void Initialization()
        {
            this.enemyField = new Field(this.height, this.width);
            this.enemyShips = new Ship[this.shipSizes.Length];
        }

        public bool CanTakeCell(int x, int y)
        {
            if (x > this.enemyField.getWidth() || x < 0 || y > this.enemyField.getHeight() || y < 0)
                return false;

            return this.enemyField.GetCellType(x, y) == ECellType.empty;
        }

        public void CalcNextCoordinats(out int x, out int y)
        {
            Cell firstWoundCell = new Cell(0, 0, ECellType.wound);
            Cell lastWoundCell = new Cell(0, 0, ECellType.wound);

            int woundCellCount = this.GetWoundCells(firstWoundCell, lastWoundCell);

            int cellIndex = 0;
            switch (woundCellCount)
            {
                case 0:
                    cellIndex = this.GetCellIndexZeroWound();
                    break;
                case 1:
                    cellIndex = this.GetCellIndexOneWound(firstWoundCell);
                    break;
                default:
                    cellIndex = this.GetCellIndexMultyplyWound(firstWoundCell, lastWoundCell);
                    break;
            }

            x = cellIndex % this.enemyField.getWidth();
            y = cellIndex / this.enemyField.getWidth();
        }

        public int GetWoundCells(Cell firstWoundCell, Cell lastWoundCell)
        {
            int woundCellCount = 0;

            for (int cellCountY = 0; cellCountY < this.enemyField.getHeight(); cellCountY++)
                for (int cellCountX = 0; cellCountX < this.enemyField.getWidth(); cellCountX++)
                    if (this.enemyField.GetCellType(cellCountX, cellCountY) == ECellType.wound)
                    {
                        Cell currentCell = new Cell(cellCountX, cellCountY, ECellType.wound);
                        if (woundCellCount == 0)
                            firstWoundCell = currentCell;
                        lastWoundCell = new Cell(cellCountX, cellCountY, ECellType.wound);
                        woundCellCount++;
                    }
            return woundCellCount;
        }

        public int GetCellIndexZeroWound()
        {
            int x = 0;
            int y = 0;
            do
            {
                int z = new Random().Next(0, this.enemyField.getWidth() * this.enemyField.getHeight());
                x = z / this.enemyField.getWidth();
                y = z % this.enemyField.getWidth();
            }
            while (!this.CanTakeCell(x, y));
            return y * this.enemyField.getWidth() + x;
        }

        public int GetCellIndexOneWound(Cell firstWoundCell)
        {
            int x = firstWoundCell.getX() - 1;
            int y = firstWoundCell.getY();

            if (this.CanTakeCell(x, y))
                return y * this.enemyField.getWidth() + x;

            x = firstWoundCell.getX() + 1;
            y = firstWoundCell.getY();

            if (this.CanTakeCell(x, y))
                return y * this.enemyField.getWidth() + x;

            x = firstWoundCell.getX();
            y = firstWoundCell.getY() - 1;

            if (this.CanTakeCell(x, y))
                return y * this.enemyField.getWidth() + x;

            x = firstWoundCell.getX();
            y = firstWoundCell.getY() + 1;

            if (this.CanTakeCell(x, y))
                return y * this.enemyField.getWidth() + x;

            return y * this.enemyField.getWidth() + x;
        }

        public int GetCellIndexMultyplyWound(Cell firstWoundCell, Cell lastWoundCell)
        {
            bool direction = lastWoundCell.getY() - firstWoundCell.getY() == 0;
            int x = direction ? firstWoundCell.getX() - 1 : firstWoundCell.getX();
            int y = direction ? firstWoundCell.getY() : firstWoundCell.getY() - 1;

            if (this.CanTakeCell(x, y))
                return y * this.enemyField.getWidth() + x;

            x = direction ? lastWoundCell.getX() + 1 : lastWoundCell.getX();
            y = direction ? lastWoundCell.getY() : lastWoundCell.getY() + 1;

            return y * this.enemyField.getWidth() + x;
        }

        public void MakeShot(out int x, out int y)
        {
            this.CalcNextCoordinats(out x, out y);
        }
    }
}