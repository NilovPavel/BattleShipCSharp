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
                    Console.Write((int)field.GetCellType(x, y));
                }
                Console.WriteLine();
            }
        }

        public override void Update()
        {
            Console.WriteLine("NEXT STEP");
            this.ShowField(this.firstField);
            this.ShowField(this.secondField);
        }
    }
}