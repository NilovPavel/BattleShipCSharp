using System;
using System.Collections.Generic;

public class Ship
{
    private int startX;
    private int startY;
    private Cell[] borders;
    private Cell[] decks;
    private int size;
    private bool isDead;
    private bool direction;
    private int widthBorder;
    private int heightBorder;

    private bool GetRandomDirection()
    {
        Random rand = new Random();
        int randValue = rand.Next(0, 2);
        return randValue == 1;
        /*return DateTime.Now.Ticks%2 == 1;*/
    }

    private void GetRandomPlacement()
    {
        Random rand = new Random();
        this.startX = this.direction ? rand.Next(0, this.widthBorder - this.size) : rand.Next(0, this.widthBorder);
        this.startY = this.direction ? rand.Next(0, this.heightBorder) : rand.Next(0, this.heightBorder - this.size);
    }

    private void Initialization()
    {
        this.isDead = false;
        this.Regeneration();
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    public Cell[] Border
    {
        get
        {
            return borders;
        }
    }

    public Cell[] Decks
    {
        get
        {
            return decks;
        }
    }

    public int Size
    {
        get
        {
            return this.size;
        }
    }

    public void Regeneration()
    {
        this.direction = this.GetRandomDirection();
        this.GetRandomPlacement();
        this.MakeDecks();
        this.MakeBorder();
    }

    private void MakeBorder()
    {
        List<Cell> cells = new List<Cell>();

        if (this.direction)
            for (int borderHeight = -1; borderHeight < 2; borderHeight++)
                for (int decksCount = -1; decksCount < this.size + 1; decksCount++)
                    cells.Add(new Cell(this.startX + decksCount, this.startY + borderHeight, ECellState.alive));
        else
            for (int borderWidht = -1; borderWidht < 2; borderWidht++)
                for (int decksCount = -1; decksCount < this.size + 1; decksCount++)
                    cells.Add(new Cell(this.startX + borderWidht, this.startY + decksCount, ECellState.alive));

        cells.RemoveAll(cell => Array.Exists(this.decks, deck => deck.X == cell.X && deck.Y == cell.Y));
        cells.RemoveAll(cell => cell.X < 0 || cell.X > this.widthBorder || cell.Y < 0 || cell.Y > this.heightBorder);

        this.borders = cells.ToArray();
    }

    private void MakeDecks()
    {
        this.decks = new Cell[size];
        for (int cellCount = 0; cellCount < this.size; cellCount++)
            this.decks[cellCount] = new Cell(this.direction ? this.startX + cellCount : this.startX, this.direction ? this.startY : this.startY + cellCount, ECellState.alive);
    }

    public bool CanUseCell(int x, int y)
    {
        bool isDeck = Array.Exists(this.decks, deck => deck.X == x && deck.Y == y);
        bool isBorder = Array.Exists(this.borders, border => border.X == x && border.Y == y);
        return !(isDeck || isBorder);
    }

    public Ship(int widthBorder, int heightBorder, int size)
    {
        this.widthBorder = widthBorder;
        this.heightBorder = heightBorder;
        this.size = size;
        this.Initialization();
        this.Regeneration();
    }

}