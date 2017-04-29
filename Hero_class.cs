using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    enum states { здоров, ослаблен, болен, отравлен, парализован, мёртв}//normal, weakened, sick, poisoned, paralyzed, dead}
    enum races { человек, гном, эльф, орк, гоблин}//human, dwarf, elf, orc, goblin}
    class Hero : IComparable {
        static int main_ID { get; set; }
        int ID { get; }
        string name { get; }
        bool gender { get; }
        races race { get; }
        states state { get; set; }
        bool abil_to_speak { get; set; }
        bool abil_to_move { get; set; }
        uint age { get; set; }
        uint health { get; set; }
        uint MAX_HEALTH { get; set; }
        uint EXP { get; set; }

        public Hero(string _name = "Fedor", bool _gender = false, races _race = races.человек) {
            ID = ++main_ID;
            name = _name;
            gender = _gender;
            race = _race;
        }
        /// <summary>
        /// Реализация интерфейса IComparable
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj) {
            if (!(obj is Hero))
                throw new ArgumentException("argument is not a Character");
            Hero newchar = (Hero)obj;
            if (this.EXP > newchar.EXP)
                return 1;
            if (this.EXP < newchar.EXP)
                return -1;
            return 0;
        }
        public override string ToString() {
            return string.Format("ID персонажа - {0},\nИмя персонажа - {1},\nпол - {2},\nраса - {3},\nтекущее состояние - {4},\nвозможность двигаться - {5},\nвозможность разговаривать - {6},\nвозраст - {7},\nздоровье - {8},\nопыт - {9}", ID, name, gender, race, state, abil_to_move, abil_to_speak, age, health, EXP);
        }
        void Refresh() {
            if (this.health < 10 && this.state == states.здоров)
                this.state = states.ослаблен;
            if (this.health == 0)
                this.state = states.мёртв;
        }
    }
    class Magicean : Hero {
        uint mana { get; set; }
        uint MAX_MANA { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hero her = new Hero();
            Hero her2 = new Hero("Саша Валай", true, races.орк);
            Console.WriteLine(her.ToString());
            Console.WriteLine(her2.ToString());
            Console.WriteLine(her2.CompareTo(her));
            Console.ReadKey();
        }
    }
}
