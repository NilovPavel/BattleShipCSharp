using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    class ConsoleViewUI : IUi
    {
        private Field firstField;
        private Field secondField;

        public ConsoleViewUI(Field firstField, Field secondField)
        {
            this.firstField = firstField;
            this.firstField.ShowShips();
            this.secondField = secondField;
            this.ShowField(firstField);
            this.ShowField(secondField);
        }
        
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

        public void UpdateFields()
        {
        }

        void IUi.Update()
        {
            throw new NotImplementedException();
        }
    }
}
