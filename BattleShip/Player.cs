// File:    Player.cs
// Author:  nilov_pg
// Created: 16 июля 2020 г. 9:54:00
// Purpose: Definition of Class Player

using System;

namespace BattleShip
{
    public class Player
    {
        private void Initialization()
        {
            /*int shipSizes[10]{4,3,3,2,2,2,1,1,1,1};
            int arraySizesCount = sizeof (shipSizes)/sizeof (int);
            this.ships = new Ship *[arraySizesCount];

            for(int i = 0; i < 10; i++)
            {
                ships[i] = new Ship(this.field, shipSizes[i]);
                for(int j = 0; j < i; j++)
                {
                    while(!ships[j].Check(*ships[i]))
                    {
                        ships[i].Regeneration();
                        j = 0;
                    }
                }
            }*/
        }

        private IPlayer iPlayer;
        private Field field;
        private Ship[] ships;

        public Ship[] Ships
        {
            get
            {
                return ships;
            }
        }

        public ECellType MakeShot(int x, int y)
        {
            ECellType eCellType = ECellType.miss;
            for (int i = 0; i < 10; i++)
            {
                eCellType = ships[i].Attack(x, y);
                switch (eCellType)
                {
                    case ECellType.free:
                    case ECellType.dead:
                    case ECellType.wound:
                        continue;
                    case ECellType.alive:
                        return ECellType.alive;
                }
            }
            return eCellType;
        }

        public ECellType Attack(Player enemyPlayer)
        {
            return ECellType.dead;
            /*int *shotX = new int;
            int *shotY = new int;
            this.iPlayer.MakeShot(*shotX, *shotY);
            return enemyPlayer.MakeShot(*shotX, *shotY);*/
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }

        public void ShowSelf()
        {
            for (int i = 0; i < 10; i++)
                ships[i].ShowMe();
        }

        public Player(IPlayer iPlayer, Field field)
        {
            this.iPlayer = iPlayer;
            this.field = field;
            this.Initialization();
        }

    }
}