using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour {


	bool isPaused; 
	bool isMenu;
	bool grimIndex;
	bool ashaIndex;
	bool itemIndex;
	bool playerIndex;
	bool subIndex;


	// Use this for initialization
	void Start () {
		isPaused = false;
		isMenu = true;
		subIndex = false;
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}






	void OnGUI(){


		if (isMenu) {

			if (GUI.Button (new Rect (675, 10, 80, 45), "Menu")) {
				isPaused = !isPaused;
				isMenu = !isMenu;
			
				if (isPaused == true) {
					Debug.Log ("Pause On");
				}
			
				if (isPaused == false) {
					Debug.Log ("Pause Off");
				
				}
			
			}

		}


		if (isPaused) {


			if(GUI.Button(new Rect(675,10,80,45),"Grimoire")){

				


				if(GUI.Button(new Rect(675,10,80,45),"Grim Menu")){


		

				}


			}

			if(GUI.Button(new Rect(675,60,80,45),"Ashamon")){
				
			}

			if(GUI.Button(new Rect(675,110,80,45),"Items")){
				
			}

			if(GUI.Button(new Rect(675,160,80,45),"Player")){
				
			}

			if(GUI.Button(new Rect(675,210,80,45),"Options")){
				
			}

			if(GUI.Button(new Rect(675,260,80,45),"Exit")){

				isPaused = false;
				isMenu = true;
				
			}




		}


	}
}



