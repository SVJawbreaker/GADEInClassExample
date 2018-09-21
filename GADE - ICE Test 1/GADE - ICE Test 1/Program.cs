using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE___ICE_Test_1
{
    //Added this project to source control with GitHub
    public class Hero
    {
        private int hp;
        private int atk;
        private int critChance;
        
        public int Roll(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        private void randomiseHP()
        {
            hp = Roll(1, 201);
        }

        private void randomiseDamage()
        {
            atk = Roll(1, 50);
        }

        private void randomiseCrit()
        {
            critChance = Roll(1, 101);
        }
        
        public Hero(string elvenName) //Hero Constructor
        {
            randomiseHP();
            randomiseDamage();
            randomiseCrit();

            MyString(elvenName);
        }
        public int Hp { get { return hp; } }
        public int Atk { get { return atk; } }
        public int CritChance { get { return critChance; } }

        private void MyString(string elvenName)
        {
            Console.WriteLine("Hero Name:   " + elvenName);
            Console.WriteLine("HP:          " + Hp);
            Console.WriteLine("Attack:      " + Atk);
            Console.WriteLine("Crit%:       " + CritChance);
        }

        private bool critCheck()
        {
            bool CritHit;
            int critChecker = Roll(1, 101);
            if (CritChance <= critChecker) {return CritHit = true;}
            else return CritHit = false;
        }
    }
    
    public class Enemy
    {
        private int hp;
        private int atk;
        private int critChance;
        private string unitType;


        public int Roll(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        private void randomiseHP()
        {
            hp = Roll(1, 151);
        }

        private void randomiseDamage()
        {
            atk = Roll(10, 50);
        }

        private void randomiseCrit()
        {
            critChance = Roll(20, 70);
        }
        
        private void rollEnemyType()
        {
            int enemyType = Roll(1, 4);
            switch (enemyType)
            {
                case 1:
                    unitType = "Goblin";
                    break;
                case 2:
                    unitType = "Dragon";
                    break;
                case 3:
                    unitType = "Ugandan Knuckles";
                    break;
            }
        }
        public int Hp { get { return hp; } }
        public int Atk { get { return atk; } }
        public int CritChance { get { return critChance; } }
        public string UnitType { get { return unitType; } }

        public Enemy() //Enemy Constructor
        {
            randomiseHP();
            randomiseDamage();
            randomiseCrit();

            rollEnemyType();
            MyString();
        }

        private void MyString()
        {
            Console.WriteLine("Enemy Name:  " + UnitType);
            Console.WriteLine("HP:          " + Hp);
            Console.WriteLine("Attack:      " + Atk);
            Console.WriteLine("Crit%:       " + CritChance);
        }

        private bool critCheck()
        {
            bool CritHit;
            int critChecker = Roll(1, 101);
            if (CritChance <= critChecker) { return CritHit = true; }            
            else { return CritHit = false; }
        }       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input your name");
            string playerName = Console.ReadLine();
            string elvenName = String.Concat(playerName.OrderBy(c => c));
            Console.Write("Your Elven name is ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(elvenName);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            Hero h = new Hero(elvenName);
            Console.WriteLine();
            Enemy e = new Enemy();
            Console.WriteLine();

            Attack(h.Hp , h.Atk, h.CritChance, e.Hp, e.Atk, e.CritChance, elvenName, e.UnitType);
                       
            Console.WriteLine();
        }

        public static void Attack(int HeroHP, int HeroAtk, int HeroCrit, int EnemyHP, int EnemyAtk, int EnemyCrit, string HeroName, string EnemyUnit )
        {
            Random r = new Random();
            int HeroCritLand;
            int EnemyCritLand;
            bool death  = false;

            while (death == false)
            {
                if (death == false)
                {
                    int HeroRoll = r.Next(1, 3);
                    switch (HeroRoll)
                    {
                        case 1: //Standard attack
                            EnemyHP -= HeroAtk;
                            Console.WriteLine(HeroName + " attacked " + EnemyUnit + " for " + HeroAtk + " DMG");
                            break;
                        case 2: //Critical Attack
                            HeroCritLand = r.Next(1, 101);
                            if (HeroCrit <= HeroCritLand) { EnemyHP -= HeroAtk * 2; }
                            Console.WriteLine(HeroName + " scores a critical hit!");
                            Console.WriteLine(HeroName + " attacked " + EnemyUnit + " for " + HeroAtk * 2 + " DMG");
                            break;
                    }
                }

                if (EnemyHP <= 0) { death = true; Console.WriteLine(HeroName + " is the winner!"); }

                if (death == false)
                {
                    int EnemyRoll = r.Next(1, 3);
                    switch (EnemyRoll)
                    {
                        case 1: //Standard attack
                            HeroHP -= EnemyAtk;
                            Console.WriteLine(EnemyUnit + " attacked " + HeroName + " for " + EnemyAtk + "DMG");
                            break;
                        case 2: //Critical attack
                            EnemyCritLand = r.Next(1, 101);
                            if (EnemyCrit <= EnemyCritLand) { HeroHP -= EnemyAtk * 2; }
                            Console.WriteLine(EnemyUnit + " scored a critical hit");
                            Console.WriteLine(EnemyUnit + " attacked " + HeroName + " for " + EnemyAtk * 2 + " DMG");
                            break;
                    }
                }

                if (HeroHP <= 0) { death = true; Console.WriteLine(EnemyUnit + " is the winner!"); }
            }
        }
    }
}
