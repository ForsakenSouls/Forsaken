using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardClass : HeroClass {
    public int mana { get; set; }
    public int MAX_MANA { get; set; }
    public WizardClass(string _name, bool gend, races _race, int _health, int mhealth, int _mana, int _maxmana, int _age)
    {
        ID = ++main_ID;
        Name = _name;
        gender = gend;
        race = _race;
        MAX_HEALTH = mhealth;
        health = _health;
        mana = _mana;
        MAX_MANA = _maxmana;
        abil_to_speak = true;
        abil_to_move = true;
        age = _age;
    }
}
