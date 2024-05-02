﻿using System;
using System.Collections.Generic;
using System.Numerics;
using ConsoleGame.Managers;

namespace ConsoleGame
{
    public class Character
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }         // 경험치 추가
        public int MaxExp { get; set; }     // 최대 경험치
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }

        public int MaxHealth { get; private set; } = 100;  // 최대 체력 속성 추가

        public InventoryManager InventoryManager { get; set; }

        public LevelUp LevelUp { get; set; }

        public Character(string name, string job)
        {
            Name = name;
            Job = job;
            Level = 1;
            Exp = 0;
            AttackPower = 10;
            DefensePower = 5;
            Health = 100;
            Gold = 1500;


            // 최대 경험치를 초기화합니다. 예를 들어 레벨이 1일 때 최대 경험치를 설정할 수 있습니다.
            MaxExp = CalculateMaxExp(Level);
            // InventoryManager 및 EquipmentManager 초기화
            InventoryManager = new InventoryManager(this);

            LevelUp = new LevelUp(this);
        }

        private int CalculateMaxExp(int level)
        {
            return level * 100;
        }

        public bool HasRequiredDefense(int requiredDefense)
        {
            return DefensePower >= requiredDefense;
        }

        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"당신이 {enemy.Name}에게 {AttackPower}의 피해를 입혔습니다.");
            enemy.Health -= AttackPower;
        }
    }
}