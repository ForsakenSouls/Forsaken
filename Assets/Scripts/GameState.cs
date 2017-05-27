using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// статический класс, в котором будет храниться персонаж во время игры
/// </summary>
public static class GameState {
    public static HeroClass Player0;
    public static WizardClass Player = new WizardClass("Саня", false, races.орк, 54, 100, 99, 100, 32);
}
