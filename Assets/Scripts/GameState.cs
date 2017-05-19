using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// статический класс, в котором будет храниться персонаж во время игры
/// </summary>
public static class GameState {

    public static HeroClass Player = new HeroClass("Саня", false, races.орк, 99, 100);
    
}
