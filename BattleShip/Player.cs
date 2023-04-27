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
            this.ships = new Ship[this.shipSizes.Length];
            for(int i = 0; i < 10; i++)
            {
                this.ships[i] = new Ship(this.field, shipSizes[i]);
                for(int j = 0; j < i; j++)
                {
                    while(!this.ships[j].Check(this.ships[i]))
                    {
                        this.ships[i].Regeneration();
                        j = 0;
                    }
                }
            }
        }

        private IPlayer iPlayer;
        private Field field;
        private Ship[] ships;
        /*private IPlayer firstPlayer;
        private Field firstPlayerField;*/
        private int[] shipSizes;

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
                if (eCellType == ECellType.wound)
                    ;
                switch (eCellType)
                {
                    case ECellType.empty:
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
            int shotX = 0;
            int shotY = 0;
            this.iPlayer.MakeShot(out shotX, out shotY);
            return enemyPlayer.MakeShot(shotX, shotY);
        }

        public bool IsDead()
        {
            int deadShipCount = 0;
            
            for (int i = 0; i < this.ships.Length; i++)
                if (this.ships[i].getIsDead())
                    deadShipCount += 1;
            
            return deadShipCount == this.ships.Length;
        }

        public void ShowSelf()
        {
            for (int i = 0; i < 10; i++)
                ships[i].ShowMe();
        }

        public Player(IPlayer iPlayer, Field field, int[] shipSizes)
        {
            this.iPlayer = iPlayer;
            this.field = field;
            this.shipSizes = shipSizes;
            this.Initialization();
        }
    }
}