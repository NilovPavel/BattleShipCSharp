using System;

public class Player
{
    private IPlayer iPlayer;
    private BattleField battleField;

    public Player(IPlayer iPlayer)
    {
        this.iPlayer = iPlayer;
    }

    public bool MakeShot(int x, int y)
    {
        throw new NotImplementedException();
    }

}