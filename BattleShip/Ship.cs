using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Ship
    {
        private void Initialization()
        {
            this.isDead = false;

            int z = new Random().Next(0, this.field.getWidth() * this.field.getHeight());
            this.x = z / this.field.getWidth();
            this.y = z % this.field.getWidth();

            this.direction = new Random().Next(0, 2) == 0;
        }

        private void MakeBorder()
        {
            int borderWidth = direction ? (this.x == 0 || this.x >= this.field.getWidth() - this.size ? this.size + 1 : this.size + 2)
                                        : (this.x == 0 || this.x == this.field.getWidth() - 1 ? 2 : 3);

            int borderHeight = !direction ? (this.y == 0 || this.y >= this.field.getHeight() - this.size ? this.size + 1 : this.size + 2)
                                         : (this.y == 0 || this.y == this.field.getHeight() - 1 ? 2 : 3);

            this.borderSize = borderWidth * borderHeight;
            this.border = new Cell[this.borderSize];

            int tempX = this.x - 1 < 0 ? this.x : this.x - 1;
            int tempY = this.y - 1 < 0 ? this.y : this.y - 1;

            for (int borderY = 0; borderY < borderHeight; borderY++)
                for (int borderX = 0; borderX < borderWidth; borderX++)
                    this.border[borderY * borderWidth + borderX] = new Cell(tempX + borderX, tempY + borderY, ECellType.miss);
        }

        private void MakeDecks()
        {
            this.decks = new Cell[this.size];

            for (int deckCount = 0; deckCount < this.size; deckCount++)
                this.decks[deckCount] = new Cell(
                        this.direction ? this.x + deckCount : this.x,
                        this.direction ? this.y : deckCount + this.y,
                        ECellType.alive);
        }

        private void Strike(int deckCount)
        {
            this.decks[deckCount].setECellType(ECellType.wound);

            int woundCount = 0;

            for (int decksCount = 0; decksCount < this.size; decksCount++)
                if (this.decks[decksCount].getECellType() == ECellType.wound)
                    woundCount++;

            this.isDead = woundCount == this.size;

            if (this.isDead)
            {
                for (int decksCount = 0; decksCount < this.size; decksCount++)
                    this.decks[decksCount].setECellType(ECellType.dead);
                this.ShowMe();
            }
        }

        private int x;
        private int y;
        private bool direction;
        private bool isDead;
        private int size;
        private int borderSize;

        private Field field;
        private Cell[] decks;

        public Cell[] Decks
        {
            get
            {
                return this.decks;
            }
        }

        private Cell[] border;

        public Cell[] Border
        {
            get
            {
                return this.border;
            }
        }

        public ECellType Attack(int x, int y)
        {
            for (int deckCount = 0; deckCount < this.size; deckCount++)
                if (this.decks[deckCount].getX() == x && this.decks[deckCount].getY() == y)
                {
                    switch (this.decks[deckCount].getECellType())
                    {
                        case ECellType.alive:
                            this.Strike(deckCount);
                            return ECellType.alive;
                    }
                }

            return ECellType.empty;
        }

        public bool CanUseCell(int x, int y)
        {
            for (int borderCellCount = 0; borderCellCount < this.borderSize; borderCellCount++)
                if (this.border[borderCellCount].getX() == x && this.border[borderCellCount].getY() == y)
                    return false;
            return true;
        }

        public bool Check(Ship ship)
        {
            for (int decksCellCount = 0; decksCellCount < this.size; decksCellCount++)
                if (!ship.CanUseCell(this.decks[decksCellCount].getX(), this.decks[decksCellCount].getY()))
                    return false;
            return true;
        }

        public void Regeneration()
        {
            int z = new Random().Next(0, this.field.getWidth() * this.field.getHeight());
            this.x = z / this.field.getWidth();
            this.y = z % this.field.getWidth();

            this.MakeDecks();
            this.MakeBorder();
        }

        public void ShowMe()
        {
            for (int borderCount = 0; borderCount < this.borderSize; borderCount++)
                this.field.SetCellType(this.border[borderCount].getX(), this.border[borderCount].getY(), this.border[borderCount].getECellType());

            for (int deckCount = 0; deckCount < this.size; deckCount++)
                this.field.SetCellType(this.decks[deckCount].getX(), this.decks[deckCount].getY(), this.decks[deckCount].getECellType());
        }

        public void KillSelf()
        {
            for (int deckCount = 0; deckCount < this.size; deckCount++)
                this.decks[deckCount].setECellType(ECellType.dead);

            this.isDead = true;
        }

        public Ship(Field field, int size)
        {
            this.field = field;
            this.size = size;
            this.Initialization();
            this.Regeneration();
        }

        public bool getIsDead()
        {
            return this.isDead;
        }

        public Ship(Cell firstCell, bool direction, int size, Field field)
        {
            this.x = firstCell.getX();
            this.y = firstCell.getY();
            this.direction = direction;
            this.size = size;
            this.field = field;
            this.MakeDecks();
            this.MakeBorder();
        }

    }
}