// File:    Session.cs
// Author:  nilov_pg
// Created: 20 июля 2020 г. 12:25:22
// Purpose: Definition of Class Session

using System;


namespace BattleShip
{
    public class Session
    {
        private IPlayer firstPlayer;
        private IPlayer secondPlayer;
        private Field firstPlayerField;
        private Field secondPlayerField;
        private int[] shipSizes;
        private Ui userInterFace;

        public Session()
        {
            this.Initialization();
        }

        private void Initialization()
        {
            this.shipSizes = new int[]{ 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            this.firstPlayerField = new Field(10, 10);
            this.secondPlayerField = new Field(10, 10);

            this.firstPlayer = new MachinePlayer(secondPlayerField.getHeight(), secondPlayerField.getWidth());
            this.secondPlayer = new MachinePlayer(firstPlayerField.getHeight(), firstPlayerField.getWidth());
        }

        public void SetGUI(Ui userInterFace)
        {
            this.userInterFace = userInterFace;
            this.userInterFace.SetFirstField(this.firstPlayerField);
            this.userInterFace.SetSecondField(this.secondPlayerField);
        }

        public void RunGame()
        {
            Player currentAttacker = new Player(this.firstPlayer, this.firstPlayerField, this.shipSizes);
            Player currentSacrifice = new Player(this.secondPlayer, this.secondPlayerField, this.shipSizes);
            Player temp = default(Player);

            while (!currentAttacker.IsDead() && !currentSacrifice.IsDead())
            {
                this.userInterFace.Update();
                ECellType eCellType = currentAttacker.Attack(currentSacrifice);
                switch (eCellType)
                {
                    case ECellType.empty:
                    case ECellType.alive:
                        continue;
                    case ECellType.wound:
                    case ECellType.dead:
                        continue;
                    case ECellType.miss:
                        temp = currentAttacker;
                        currentAttacker = currentSacrifice;
                        currentSacrifice = temp;
                        continue;
                }
            }
            this.userInterFace.Update();
        }
    }
}