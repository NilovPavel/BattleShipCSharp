using System;

public interface IPlayer
{
    bool MakeShot(out int x, out int y);
}