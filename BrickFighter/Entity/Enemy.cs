﻿using BrickFighter.Controllers;
using BrickFighter.Services;
using System;

namespace BrickFighter.Entity
{
    public class Enemy : Entity
    {
        private static Random rnd = new Random();

        public Enemy(EntityGameController entityGameController) : base(entityGameController)
        {
            Health = rnd.Next(200, 1000);
            Power = rnd.Next(15, 30);
        }

        public enum State
        {
            None,
            Attack,
            Heal
        }

        public void Heal()
        {
            int healAmount = (int)(Health * 0.3);
            Health += healAmount;
            Console.WriteLine($"Enemy heals for {healAmount} health points!");
        }

        public override void OnDeath()
        {
            _entityGameController.PlayerWin();
        }
    }
}
