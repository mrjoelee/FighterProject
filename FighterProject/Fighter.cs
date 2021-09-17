using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterProject.Enum;
using FighterProject.Equipment;

namespace FighterProject
{
    class Fighter
    {
        //starting health for both characters
        private const int GOOD_GUY_STARTING_HEALTH = 20;
        private const int BAD_GUY_STARTING_HEALTH = 20;

        //creating rivalry by creating a enum
        private readonly Faction FACTION;

        //fields-defining a fighter
        private int health;
        private string name;
        private bool isAlive;

        //creating a prop, and a getter only for isAlive (only need a value)
        public bool IsAlive 
        {
            get
            {
                return isAlive;
            }
        }

        //missing custom datatype(create a new class)
        private Weapon weapon;
        private Armor armor;

        public Fighter(string name, Faction faction)
        {
            this.name = name;
            this.FACTION = faction;
            this.isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;

                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;

                    break;
                default:
                    break;
            }
        }
        
        public void Attack(Fighter enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;

            enemy.health -= damage;

            AttackResult(enemy, damage);
        }

        private void AttackResult(Fighter enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.ColorfulWriteLine($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.ColorfulWriteLine($"{name} is VICTORIOUS!", ConsoleColor.White);
            }
            else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage was inflicted to {enemy.name}, " +
                    $"remaining health of {enemy.name} is {enemy.health}");
            }
        }
    }
}
