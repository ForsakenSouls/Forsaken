using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardClass : HeroClass {
    public uint mana { get; set; }
    public uint MAX_MANA { get; set; }
    public WizardClass(string _name, bool gend, races _race, uint _health, uint mhealth, uint _mana, uint _max_mana) {
        ID = ++main_ID;
        Name = _name;
        gender = gend;
        race = _race;
        MAX_HEALTH = mhealth;
        health = _health;
        MAX_MANA = _max_mana;
        mana = _mana;
    }
}
