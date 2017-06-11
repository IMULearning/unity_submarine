using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCounter : MonoBehaviour {

	public static int number = 5;

	public static void DisplayProgress() {
		UIHelper_Example.ChangeText (number + (number == 1 ? " Mine" : " Mines") + " Left");
	}
}
