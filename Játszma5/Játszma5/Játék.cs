using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Játszma5
{
    class Játék //6.a feladat
    {
        //6.b feladat
        public string ServerName { get; private set; }
        public string ReceiverName { get; private set; }
        public string Score { get; private set; } 

        //AFAAFAA
        public Játék(string serverName, string receiverName, string actualScore) //6.c feladat
        {
            ServerName = serverName;
            ReceiverName = receiverName;
            Score = actualScore;
        }

        public void Hozzáad(char rallyResult) //6.d feladat
        {
            Score += rallyResult;
        }

        //public string Hozzáad(char rallyResult) //Ezt lehet?
        //{
        //    return Score += rallyResult;
        //}

        public int NyertLabdamenetekSzáma(char player) //6.e feladat
        {
            return Score.Count(s => s == player);
        }

        public bool JátékVége() //6.f feladat
        {
            int winServer = 0;
            int winReceiver = 0;
            int diff = 0;

            winServer = NyertLabdamenetekSzáma('A');
            winReceiver = NyertLabdamenetekSzáma('F');
            diff = Math.Abs(winServer - winReceiver);

            if ((winServer >= 4 || winReceiver >= 4) && diff >= 2)
                return true;

            return false;
        }
    }
}
