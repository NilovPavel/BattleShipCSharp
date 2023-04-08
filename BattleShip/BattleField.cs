using System;

public class BattleField
{
    private void Initialization()
    {
        this.cells = new Cell[this.height * this.width];
        for (int x = 0; x < this.width; x++)
            for (int y = 0; y < this.height; y++)
                this.cells[x + y * this.height] = new Cell(x, y, ECellState.free);
    }

    private void InstallShips()
    {
        int[] shipSizes = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
        this.ships = new Ship[shipSizes.Length];
        for (int shipCount = 0; shipCount < shipSizes.Length; shipCount++)
        {
            Ship ship = new Ship(this.width, this.height, shipSizes[shipCount]);
            while (!this.CanMakeKreiser(ship))
                ship.Regeneration();
            this.ships[shipCount] = ship;
        }
    }

    private bool CanMakeKreiser(Ship ship)
    {
        bool result = true;
        for (int kreiserCount = 0; kreiserCount < this.ships.Length; kreiserCount++)
        {
            Ship currentShip = this.ships[kreiserCount];

            if (currentShip == null)
                break;

            for (int deckShip = 0; deckShip < ship.Size; deckShip++)
                result = currentShip.CanUseCell(ship.Decks[deckShip].X, ship.Decks[deckShip].Y);

            if (!result)
                break;
        }
        return result;
    }

    private int height;
    private int width;

    private Ship[] ships;
    private Cell[] cells;

    public int Height
    {
        get
        {
            return height;
        }
    }

    public int Width
    {
        get
        {
            return width;
        }
    }

    public ECellState GetCellState(int x, int y)
    {
        return this.cells[x + y * this.height].ECellStatus;
    }

    public void ShowShips()
    {
        for (int shipCount = 0; shipCount < this.ships.Length; shipCount++)
            for (int cellCount = 0; cellCount < ships[shipCount].Decks.Length; cellCount++)
                this.cells[ships[shipCount].Decks[cellCount].X + ships[shipCount].Decks[cellCount].Y * this.height].ECellStatus = ECellState.alive;
    }

    public BattleField(int height, int width)
    {
        this.height = height;
        this.width = width;
        this.Initialization();
        this.InstallShips();
    }

}