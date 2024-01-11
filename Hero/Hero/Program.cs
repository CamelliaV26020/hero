using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static int PlayerHP = 0;
        static int PlayerMP = 0;
        static int PlayerMoney = 1000;
        #region HP Recover
        static int recoverHP(int CurrentHP, int CurrentMoney)
        {
            while ((CurrentMoney > 100 || CurrentMoney == 100) && CurrentHP < 100)//金钱>100且血量未满100,循环
            {
                PlayerMoney -= 100;
                CurrentMoney = PlayerMoney;
                CurrentHP += 30;
                if (CurrentHP > 100)//判断最后一次回复生命是不是超过100,最大值为100
                {
                    CurrentHP = 100;
                }
            }
            return CurrentHP;//返回交易过的当前生命值
        }
        static int recoverSelfHP(int CurrentHP)
        {
            while (CurrentHP < 100)//血量未满100,循环
            {
                CurrentHP += 30;
                if (CurrentHP > 100)//判断最后一次回复生命是不是超过100,最大值为100
                {
                    CurrentHP = 100;
                }
            }
            return CurrentHP;//返回当前生命值
        }
        #endregion
        #region  MP Recover
        static int recoverMP(int CurrentMP, int CurrentMoney)
        {
            while ((CurrentMoney > 100 || CurrentMoney == 100) && CurrentMP < 100)//金钱>100且蓝量未满100,循环
            {
                PlayerMoney -= 100;
                CurrentMoney = PlayerMoney;
                CurrentMP += 15;
                if (CurrentMP > 100)//判断最后一次回复蓝量是不是超过100,最大值为100
                {
                    CurrentMP = 100;
                }
            }
            return CurrentMP;//返回交易过的当前蓝量
        }
        #endregion
        #region Buffs
        static int AtkBuff(int currentAtk)
        {
            currentAtk *= 2;
            return currentAtk;
        }
        static int ArmorDeBuff(int currentArmor)
        {
            currentArmor -= 2;
            return currentArmor;
        }
        #endregion
        public enum HeroClass//枚举职业对应的编号
        {
            Default = 0,
            Warrior = 1,
            Archer = 2,
            Mage = 3
        }
        public struct CharacterInfo
        {
            public string HeroType;//英雄职业类型
            public HeroClass ClasNum;
            public int PlayerHP;//英雄生命值
            public int PlayerMP;//英雄蓝量
            public float AtkRange;//英雄攻击距离
            public int PlayerMoney;//英雄金钱
            public bool HeroStatus;//英雄生存状态
        }
        #region 英雄Class
        public class Hero//英雄类
        {
            private string HeroName = "";
            private int HeroHP = 100;
            private int HeroMP = 100;
            private int HeroAtk = 10;
            private int HeroArmor = 5;
            private int HeroMoney = 0;
           
            public void SelfRecover()//自愈技能
            {
                HeroHP = recoverSelfHP(HeroHP);
                RecoverTalk();
                Console.WriteLine(HeroName + " HP is full!");
            }
            public void HeroTalk()//默认台词
            {
                Console.WriteLine("I am a hero!");
            }
            public void RecoverTalk()//治愈时台词
            {
                Console.WriteLine("Good! HP Up!");
                Console.WriteLine(HeroName + " current HP is " + HeroHP);
            }
            public int ActiveAtk(int SelfAtk, int TargetHP, int TargetArmor) //攻击
            {
                TargetHP = TargetHP - (SelfAtk - TargetArmor);//伤害等于攻击方攻击-被攻击方防御
                return TargetHP;
            }
            #region 获取和设置属性
            public string getName() //获取姓名
            {
                return HeroName;
            }
            public int getHP() //获取生命值
            {
                return HeroHP;
            }
            public int getArmor()//获取护甲值
            {
                return HeroArmor;
            }
            public int getAtk()//获取攻击力
            {
                return HeroAtk;
            }
            public void setName(string currentName) //设置姓名
            {
                HeroName = currentName;
            }
            public void setHP(int currentHP) //设置生命值
            {
                HeroHP = currentHP;
            }
            public void setArmor(int currentArmor)//设置护甲值
            {
                HeroArmor = currentArmor;
            }
            public void setAtk(int currentAtk)//设置攻击力
            {
                HeroAtk = currentAtk;
            }
            #endregion
            #region 实例化方法
            public Hero() { }
            public Hero(string setName, int setHP, int setMP, int setAtk, int setArmor, int setMoney)
            {
                HeroName = setName;
                HeroHP = setHP;
                HeroMP = setMP;
                HeroAtk = setAtk;
                HeroArmor = setArmor;
                HeroMoney = setMoney;
            }
            #endregion
        }

        #endregion
        static void Main(string[] args)
        {
            HeroClass ClassType = HeroClass.Default;

            Hero Kiriya = new Hero("Kiriya", 100, 100, 10, 5, 0);//实例化一个英雄Kiriya
            Hero David = new Hero("David", 100, 100, 10, 5, 0);//实例化一个英雄David

            //Kiriya.setName("Kiriya");
            //David.setName("David");//设置名字

            Kiriya.setAtk(AtkBuff(Kiriya.getAtk()));//攻击buff
            David.setArmor(ArmorDeBuff(David.getArmor()));//护甲debuff

            int DamageDealt = Kiriya.getAtk()- David.getArmor();

            int FinalHP = Kiriya.ActiveAtk(Kiriya.getAtk(), David.getHP(), David.getArmor());
            //Kiriya攻击David,计算David剩余生命
            Console.WriteLine(Kiriya.getName() + " attacked " + David.getName() + ", dealt " + DamageDealt + " Damage!");
            Console.WriteLine(David.getName() + " remains " + FinalHP + " HP!");

            David.SelfRecover();//David发动自愈技能

            CharacterInfo Warrior;//实例化Warrior结构体
            Warrior.HeroType = "warrior";
            Warrior.PlayerHP = 120;
            Warrior.PlayerMP = 50;
            Warrior.AtkRange = 1.5f;
            Warrior.HeroStatus = true;

            CharacterInfo Archer = new CharacterInfo();//实例化弓箭手结构体
            Archer.HeroType = "archer";
            Archer.PlayerHP = 100;
            Archer.PlayerMP = 80;
            Archer.AtkRange = 3.5f;
            Archer.HeroStatus = true;

            //PlayerHP = recoverHP(PlayerHP, PlayerMoney);
            //if (PlayerHP == 100)
            //{
            //    Console.WriteLine("You current HP is full!");
            //    Console.WriteLine("You money: " + PlayerMoney);
            //}
            //else
            //{
            //    Console.WriteLine("You HP: " + PlayerHP);
            //    Console.WriteLine("You money: " + PlayerMoney);
            //}
            //PlayerMP = recoverMP(PlayerMP, PlayerMoney);
            //if (PlayerMP == 100)
            //{
            //    Console.WriteLine("You current MP is full!");
            //    Console.WriteLine("You money: " + PlayerMoney);
            //}
            //else
            //{
            //    Console.WriteLine("You MP: " + PlayerMP);
            //    Console.WriteLine("You money: " + PlayerMoney);
            //}
            Console.ReadKey();
        }
    }
}
