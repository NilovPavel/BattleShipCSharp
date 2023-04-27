using BattleShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    class ConsoleViewUI : Ui
    {
        void ShowField(Field field)
        {
            Console.WriteLine("");
            for (int x = 0; x < field.getWidth(); x++)
            {
                for (int y = 0; y < field.getHeight(); y++)
                {
                    this.SetColorOfConsole(field.GetCellType(x, y));
                    Console.Write((int)field.GetCellType(x, y) + " ");
                }
                Console.WriteLine();
            }
        }

        private void SetColorOfConsole(ECellType eCellType)
        {
            Console.ResetColor();
            switch (eCellType)
            {
                case ECellType.empty:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case ECellType.miss:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case ECellType.alive:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ECellType.wound:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ECellType.dead:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }

        private void SetColorOfConsole()
        { }

        public override void Update()
        {
            Console.Clear();
            Console.WriteLine("\r\nNEXT STEP\r\n");
            this.ShowField(this.firstField);
            this.ShowField(this.secondField);
        }
    }
}