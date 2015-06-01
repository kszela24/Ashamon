using UnityEngine;
using System.Collections;

public class BattleScene : MonoBehaviour {

	public GUISkin BattleSkin;

	//Battle Scene Main Menu
	bool isMain;
	public int main_button_height;
	public int main_button_width;
	public int main_button_position_y;
	public int main_button_x_offset;

	//Battle Scene Move Selection Menu
	bool isMoveSelection;

	//HUD
	bool isHUD;

	//Text Box
	bool isText;

	// Use this for initialization
	void Start () {
		isMain = true;
		isMoveSelection = false;
		isHUD = true;
		isText = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	
	
	
	
	
	void OnGUI(){
		main_button_height = Screen.height / 7;
		main_button_width = (Screen.width / 5);
		main_button_position_y = Screen.height - main_button_height - 5;
		main_button_x_offset = ((Screen.width / 4) - main_button_width) / 2;
		GUI.skin = BattleSkin;
		GUIStyle windowborderleft = GUI.skin.GetStyle ("WindowBorderLeft");

		if (isText) {
			GUI.Box (new Rect (-((Screen.width / 25) / 2), Screen.height - main_button_height - (Screen.height / 20), Screen.width + (Screen.width / 25), (Screen.height / 3)), "");

			GUI.Box (new Rect (0, Screen.height - main_button_height - (Screen.height / 15), 75, 75), "", windowborderleft);
		}

		if (isMain) {
			if (GUI.Button (new Rect (main_button_x_offset, main_button_position_y, main_button_width, main_button_height), "Fight")) {
				isMain = false;
				isMoveSelection = true;
			}

			if (GUI.Button (new Rect ((Screen.width / 4) + main_button_x_offset, main_button_position_y, main_button_width, main_button_height), "Ashamon")) {
				
			}

			if (GUI.Button (new Rect ((Screen.width / 2) + main_button_x_offset, main_button_position_y, main_button_width, main_button_height), "Items")) {
				
			}

			if (GUI.Button (new Rect (((Screen.width / 4) * 3) + main_button_x_offset, main_button_position_y, main_button_width, main_button_height), "Run")) {
				
			}
		}

		if (isHUD) {
		}




		if (isMoveSelection) {
			if (GUI.Button (new Rect (main_button_x_offset, main_button_position_y, main_button_width, main_button_height), "Move1")) {
				isMain = false;
				isMoveSelection = true;
			}
		}
		
	}
}
