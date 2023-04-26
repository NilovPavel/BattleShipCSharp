using BattleShip;
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
            Session session = new Session();
            /*IPlayer *firstIPlayer = new HumanPlayer(*(new UserConsole()));
            session->SetFirstIPlayer(*firstIPlayer);*/
            Ui userInterFace = new ConsoleViewUI();
            session.SetGUI(userInterFace);
            session.RunGame();

        }
    }
}
