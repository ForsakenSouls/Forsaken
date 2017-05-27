using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;


public class Selectionscript : MonoBehaviour
{
    public static bool isWizzard;
    public static bool isGender;
    public static string isName;
    public static string isAge;
    public races cur_race;
    public InputField Name;
    public InputField Age;

    public Toggle isHuman;
    public Toggle isDwarf;
    public Toggle isElf;
    public Toggle isOrc;
    public Toggle isGoblin;

    public Toggle isMage;
    public Toggle isSimple;

    public Toggle isMale;
    public Toggle isFemale;

    public void ActiveToggle()
    {
        if (isHuman.isOn)
        {
            cur_race = races.человек;
        }
        else if (isDwarf.isOn)
        {
            cur_race = races.гном;
        }
        else if (isElf.isOn)
        {
            cur_race = races.эльф;
        }
        else if (isOrc.isOn)
        {
            cur_race = races.орк;
        }
        else if (isGoblin.isOn)
        {
            cur_race = races.гоблин;
        }
    }

    public void ActiveMage()
    {
        if (isMage.isOn)
        {
            isWizzard = true;
        }
        else if (isSimple.isOn)
        {
            isWizzard = false;
        }
    }

    public void ActiveGender()
    {
        if (isMale.isOn)
        {
            isGender = true;
        }
        else if (isFemale.isOn)
        {
            isGender = false;
        }
    }


    public void onClick()
    {
        ActiveToggle();
        ActiveMage();
        ActiveGender();
        if (Name.text != "" & Age.text != "" & Age.text != "0")
        {
            if (Convert.ToInt32(Age.text) > 10)
            {
                isName = Name.text;
                isAge = Age.text;
                if (isWizzard)
                {
                    GameState.Player = new WizardClass(isName, isGender, cur_race, 100, 100, 100, 100, Convert.ToInt32(isAge));
                }
                else {
                    GameState.Player0 = new HeroClass(isName, isGender, cur_race, 100, 100, Convert.ToInt32(isAge));
                }
                SceneManager.LoadScene("changes");
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Ошибка!", "Незаполненные поля!", "Еще раз");
        }
    }

}
