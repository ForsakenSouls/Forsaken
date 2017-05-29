using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// статический класс, в котором будет храниться персонаж во время игры
/// </summary>
public static class GameState {
	public static int ArtID = -1;
    public static WizardClass Player = new WizardClass("Саня", false, races.орк, 54, 100, 990, 1000, 32);
	public static bool Invaluable = false;
	public static int manaPerTime = 2;
	public static int manaPerFire = 200;
	public static bool paralyzed = false;
}
