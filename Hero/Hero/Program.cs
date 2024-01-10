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
        public enum HeroClass//枚举职业对应的编号
        {
            Default = 0,
            Warrior = 1,
            Archer = 2,
            Mage = 3
        }
        public struct HeroInfo
        {
            public string HeroType;//英雄职业类型
            public HeroClass ClasNum;
            public int PlayerHP;//英雄生命值
            public int PlayerMP;//英雄蓝量
            public float AtkRange;//英雄攻击距离
            public int PlayerMoney;//英雄金钱
            public bool HeroStatus;//英雄生存状态
        }
        static void Main(string[] args)
        {
            HeroClass ClassType = HeroClass.Default;

            HeroInfo Warrior;//实例化一个活的战士
            Warrior.HeroType = "warrior";
            Warrior.PlayerHP = 120;
            Warrior.PlayerMP = 50;
            Warrior.AtkRange = 1.5f;
            Warrior.HeroStatus = true;

            HeroInfo Archer = new HeroInfo();//实例化一个活的弓箭手
            Archer.HeroType = "archer";
            Archer.PlayerHP = 100;
            Archer.PlayerMP = 80;
            Archer.AtkRange = 3.5f;
            Archer.HeroStatus = true;

            PlayerHP = recoverHP(PlayerHP, PlayerMoney);
            if (PlayerHP == 100)
            {
                Console.WriteLine("You current HP is full!");
                Console.WriteLine("You money: " + PlayerMoney);
            }
            else
            {
                Console.WriteLine("You HP: " + PlayerHP);
                Console.WriteLine("You money: " + PlayerMoney);
            }
            PlayerMP = recoverMP(PlayerMP, PlayerMoney);
            if (PlayerMP == 100)
            {
                Console.WriteLine("You current MP is full!");
                Console.WriteLine("You money: " + PlayerMoney);
            }
            else
            {
                Console.WriteLine("You MP: " + PlayerMP);
                Console.WriteLine("You money: " + PlayerMoney);
            }
            Console.ReadKey();
        }
    }
}
