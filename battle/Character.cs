using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace battle
{
    public class Character
    {
        protected int strength;
        protected int dexterity;
        protected int luck;
        protected int constitution;
        protected int intellect;
        protected int lvl;
        protected int xp;
        protected int skillPoints;

        protected double healthPoint;
        protected double physicalAttake;
        protected double magicalAttake;
        protected double manaPool;

        public int Exp { get => strength; set => PhysAtt = value; }
        public int Points { get => Strenght; set => PhysAtt = value; }
        public int Lvl { get => Strenght; set => PhysAtt = value; }
        public double PhysAtt { get => physicalAttake; set => physicalAttake = value; }
        public double Hp { get => healthPoint; set => healthPoint = value; }
        public double MagAtt { get => magicalAttake; set => magicalAttake = value; }
        public double MP { get => manaPool; set => manaPool = value; }
        private Random Random = new Random();
        public int Strenght { get => strength; set { strength = value; physicalAttake = value; } }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Luck { get => luck; set => luck = value; }
        public int Constitution { get => constitution; set { Hp = value * 5; constitution = value; } }
        public int Intelegence { get => intellect; set { MagAtt = value * 2; MP = value * 7; intellect = value;  } }


        public string AttPart { get; set; }
        public string BlockPart { get; set; }
        public Character()
        {
            Points = 15;
            Strenght = 1;
            Dexterity = 1;
            Luck = 1;
            Constitution = 1;
            Intelegence = 1;
        }
        public double IsEvasion(int EnemyDex)
        {
            return (Convert.ToDouble(Dexterity) - Convert.ToDouble(EnemyDex)) * 0.1;
        }
        public double IsCrit(int EnemyLuck)
        {
            return (Convert.ToDouble(Luck) - (Convert.ToDouble(EnemyLuck) * 0.5) ) * 0.1;
        }
        public void Heal(int mp)
        {
            if(Intelegence > 5)
            {
                if (mp < MP)
                {
                    Hp =+ mp* 2;
                }
            }
        }
        public string PHit(Character Enemy)
        {
            if(Enemy.BlockPart == AttPart)
            {
                if((Convert.ToDouble(Strenght) - Convert.ToDouble(Enemy.Strenght)) * 0.05 * 100 >= Random.Next(1, 100))
                {
                    return ("Кент блокнул(") + '\n';
                }
                else
                {
                    if (Enemy.IsEvasion(Dexterity) * 100 >= Random.Next(1, 100))
                    {
                        return ("Кент уклонился(") + '\n';
                    }
                    else
                    {
                        if(this.IsCrit(Enemy.Luck) *100 >= Random.Next(1, 100))
                        {
                            Enemy.Hp -= PhysAtt * 2;
                            return "Критический урон!! -" + (PhysAtt * 2) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                        }
                        else
                        {
                            Enemy.Hp -= PhysAtt;
                            return "Удар!! -" + (PhysAtt) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                        }
                    }
                }
            }
            else
            {
                if (Enemy.IsEvasion(Dexterity) * 100 >= Random.Next(1, 100))
                {
                    return ("Кент уклонился(") + '\n';
                }
                else
                {
                    if (this.IsCrit(Enemy.Luck) * 100 >= Random.Next(1, 100))
                    {
                        Enemy.Hp -= PhysAtt * 2;
                        return "Критический урон!! -" + (PhysAtt * 2) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                    }
                    else
                    {
                        Enemy.Hp -= PhysAtt;
                        return "Удар!! -" + (PhysAtt) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                    }
                }
            }
            return "";
            
        }
        public string MHit(Character Enemy)
        {
            if(MP -5 > 0)
            {
                MP -= 5;
                if (Enemy.BlockPart == AttPart)
                {
                    if ((Convert.ToDouble(Strenght) - Convert.ToDouble(Enemy.Strenght)) * 0.05 * 100 >= Random.Next(1, 100))
                    {
                        return ("Кент блокнул(") + '\n';
                    }
                    else
                    {
                        if (Enemy.IsEvasion(Dexterity) * 100 >= Random.Next(1, 100))
                        {
                            return ("Кент уклонился(") + '\n';
                        }
                        else
                        {
                            if (this.IsCrit(Enemy.Luck) * 100 >= Random.Next(1, 100))
                            {
                                Enemy.Hp -= MagAtt * 2;
                                return "Критический урон!! -" + (MagAtt * 2) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                            }
                            else
                            {
                                Enemy.Hp -= MagAtt;
                                return "Удар!! -" + (MagAtt) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                            }
                        }
                    }
                }
                else
                {
                    if (Enemy.IsEvasion(Dexterity) * 100 >= Random.Next(1, 100))
                    {
                        return ("Кент уклонился(") + '\n';
                    }
                    else
                    {
                        if (this.IsCrit(Enemy.Luck) * 100 >= Random.Next(1, 100))
                        {
                            Enemy.Hp -= MagAtt * 2;
                            return "Критический урон!! -" + (MagAtt * 2) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                        }
                        else
                        {
                            Enemy.Hp -= MagAtt;
                            return "Удар!! -" + (MagAtt) + '\n' + "У врага осталось " + Enemy.Hp + '\n';
                        }
                    }
                }
            }
            else
            {
                return "Мало маны(" + '\n';
            }
            return "";
        }
        public void ExpUp(int exp)
        {
            switch (Lvl)
            {
                case (1):
                    if(100 < Exp + exp)
                    {
                        Lvl++;
                        Exp = Exp + exp - 100;
                        Points += 2;
                    }
                    else
                    {
                        Exp += exp;
                    }
                    break;
                case (2):
                    if (300 < Exp + exp)
                    {
                        Lvl++;
                        Exp = Exp + exp - 300;
                        Points += 2;
                    }
                    else
                    {
                        Exp += exp;
                    }
                    break;
                case (3):
                    if (800 < Exp + exp)
                    {
                        Lvl++;
                        Exp = Exp + exp - 800;
                        Points += 3;
                    }
                    else
                    {
                        Exp += exp;
                    }
                    break;
                case (4):
                    if (1800 < Exp + exp)
                    {
                        Lvl++;
                        Exp = Exp + exp - 1800;
                        Points += 2;
                    }
                    else
                    {
                        Exp += exp;
                    }
                    break;
                case (5):
                    if (3000 < Exp + exp)
                    {
                        Lvl++;
                        Exp = Exp + exp - 3000;
                        Points += 5;
                    }
                    else
                    {
                        Exp += exp;
                    }
                    break;
            }
        }
    }
}
