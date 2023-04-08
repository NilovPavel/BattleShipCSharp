using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleField firstField = new BattleField(10, 10);
            BattleField secondField = new BattleField(10, 10);

            IViewUI viewUI = new ConsoleViewUI(firstField, secondField);
            Player player = new Player(new Human());
            viewUI.UpdateFields();

        }
    }
}
