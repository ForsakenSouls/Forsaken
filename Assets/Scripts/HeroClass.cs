﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroClass : IComparable
{
    protected static int main_ID { get; set; }
    protected int ID { get; set; }
    public string Name { get; set; }
    public bool gender { get; set; }
    public races race { get; set; }
    public states state { get; set; }
    public bool abil_to_speak { get; set; }
    public bool abil_to_move { get; set; }
    public int age { get; set; }
    public int health { get; set; }
    public int MAX_HEALTH { get; set; }
    public int EXP { get; set; }

    public HeroClass(string _name = "Fedor", bool _gender = false, races _race = races.человек, int m_health = 100)
    {
        ID = ++main_ID;
        Name = _name;
        gender = _gender;
        race = _race;
        MAX_HEALTH = m_health;
        health = MAX_HEALTH;
    }
    public HeroClass(string _name, bool gend, races _race, int _health, int mhealth, int _age) {
        ID = ++main_ID;
        Name = _name;
        gender = gend;
        race = _race;
        MAX_HEALTH = mhealth;
        health = _health;
        abil_to_move = true;
        abil_to_speak = true;
        age = _age;
    }
    /// <summary>
    /// Реализация интерфейса IComparable
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object obj)
    {
        if (!(obj is HeroClass))
            throw new ArgumentException("argument is not a Character");
        HeroClass newchar = (HeroClass)obj;
        if (this.EXP > newchar.EXP)
            return 1;
        if (this.EXP < newchar.EXP)
            return -1;
        return 0;
    }
    public override string ToString()
    {
        return string.Format("ID персонажа - {0},\nИмя персонажа - {1},\nпол - {2},\nраса - {3},\nтекущее состояние - {4},\nвозможность двигаться - {5},\nвозможность разговаривать - {6},\nвозраст - {7},\nопыт - {9},\nздоровье - {8}", ID, Name, (gender)?"Мужской":"Женский", race, state, (abil_to_move)?"да":"нет", (abil_to_speak)?"да":"нет", age, health, EXP);
    }
    void Refresh()
    {
        if (this.health < 10 && this.state == states.здоров)
            this.state = states.ослаблен;
        if (this.health == 0)
            this.state = states.мёртв;
    }
}
