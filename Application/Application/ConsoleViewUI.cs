using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    class ConsoleViewUI : IViewUI
    {
        private BattleField firstField;
        private BattleField secondField;

        public ConsoleViewUI(BattleField firstField, BattleField secondField)
        {
            this.firstField = firstField;
            this.firstField.ShowShips();
            this.secondField = secondField;
            this.ShowField(firstField);
            this.ShowField(secondField);
        }
        
        void ShowField(BattleField field)
        {
            Console.WriteLine("");
            for (int x = 0; x < field.Width; x++)
            {
                for (int y = 0; y < field.Height; y++)
                {
                    Console.Write((int)field.GetCellState(x, y));
                }
                Console.WriteLine();
            }
        }

        public void UpdateFields()
        {
        }
    }
}
