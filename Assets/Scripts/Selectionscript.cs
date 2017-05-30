using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
//using UnityEditor;

public class Selectionscript : MonoBehaviour
{
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

    public void onClick()
    {
        ActiveToggle();
        if (Name.text != "" & Age.text != "" & Age.text != "0")
        {
            if (Convert.ToInt32(Age.text) > 0 && Convert.ToInt32(Age.text) < 200000)
            {
                isName = Name.text;
                isAge = Age.text;
                GameState.Player = new WizardClass(isName, true, cur_race, 100, 100, 1000, 1000, Convert.ToInt32(isAge));
                SceneManager.LoadScene("changes");
            }
        }
        else
        {
            //EditorUtility.DisplayDialog("Ошибка!", "Незаполненные поля!", "Еще раз");
        }
    }

}
