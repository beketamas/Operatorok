using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorok
{
    internal class Kifejezesek
    {
        int elsoOperandus;
        string operatorok;
        int masodikOperandus;

        public Kifejezesek(string sor)
        {
            string[] tomb = sor.Split();
            this.elsoOperandus = int.Parse(tomb[0]);
            this.operatorok = tomb[1].ToString();
            this.masodikOperandus = int.Parse(tomb[2]);
        }

        public int ElsoOperandus { get => elsoOperandus;}
        public string Operatorok { get => operatorok;}
        public int MasodikOperandus { get => masodikOperandus;}
    }
}
