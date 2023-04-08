using System;

public class Cell
{
    private int x;
    private int y;
    private ECellState eCellStatus;

    public int X
    {
        get
        {
            return x;
        }
        set
        {
            this.x = value;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            this.y = value;
        }
    }

    public ECellState ECellStatus
    {
        get
        {
            return eCellStatus;
        }
        set
        {
            this.eCellStatus = value;
        }
    }

    public Cell(int x, int y, ECellState eCellStatus)
    {
        this.x = x;
        this.y = y;
        this.eCellStatus = eCellStatus;
    }

}