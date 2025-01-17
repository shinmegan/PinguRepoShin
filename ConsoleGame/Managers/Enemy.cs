﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleGame.Managers
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public bool isDead { get; set; }

        public Enemy(string name, int level, bool isDead = false)
        {
            Level = level;
            Name = name;
            Health = CalculateHealth(level); //레벨반영
            Attack = CalculateAttack(level);
            this.isDead = isDead;
        }

        //플레이어 레벨 반영하여 몬스터 체력 조정
        private int CalculateHealth(int level)
        {
            switch (Name)
            {
                case "도둑갈매기":
                    return 30 + level * 4;
                case "야생들개":
                    return 40 + level * 4;
                case "여우":
                    return 45 + level * 4;
                case "바다표범":
                    return 80 + level * 5;
                case "늑대":
                    return 60 + level * 5;
                case "북극곰":
                    return 100 + level * 6;
                case "범고래":
                    return 150 + level * 6;
                default:
                    return 0;
            }
        }

        //플레이어 레벨 반영하여 몬스터 공격력 조정
        private int CalculateAttack(int level)
        {
            switch (Name)
            {
                case "도둑갈매기":
                    return 4 + level;
                case "야생들개":
                    return 6 + level;
                case "여우":
                    return 6 + level;
                case "바다표범":
                    return 10 + level * 2;
                case "늑대":
                    return 14 + level * 2;
                case "북극곰":
                    return 20 + level * 3;
                case "범고래":
                    return 17 + level * 3;

                default:
                    return 0;
            }
        }
        public void EnemyAttack(Character player)
        {

            if (player.Health < Attack)
            {
                player.Health = 0;
            }
            else
                player.Health -= Attack;
            Console.WriteLine("===================");
            Console.WriteLine($"{Name} 의 공격!");
            int playerPreHP = player.Health;

            // 회피할 확률을 확인합니다.
            Random random = new Random();
            bool isDodged = random.Next(1, 101) <= 10; // 10% 확률로 회피 발생
            // 회피가 발생한 경우
            if (isDodged && Name != "스킬") // 스킬은 회피할 수 없음
            {
                Console.WriteLine($"{player.Name}이(가) 몬스터의 공격을 회피했습니다.");
            }
            else
            {
                Console.WriteLine($"Lv.{player.Level} {player.Name} 에게 {Attack} 데미지를 가했습니다.\n");
            }
            Console.WriteLine($"Lv.{player.Level} {player.Name}");
            if (player.Health <= 0)
            {
                player.Health = 0;
                Console.WriteLine($"HP {playerPreHP} -> Dead\n");
            }
            else
                Console.WriteLine($"HP {playerPreHP} -> {player.Health}\n");
            Console.WriteLine($"0. 다음");
            Console.WriteLine($"1. 아이템사용\n");
            Console.Write(">>");
        }
    }
}