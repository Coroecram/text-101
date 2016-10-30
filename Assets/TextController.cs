using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {intro, cell_0, mirror_0, get_mirror, sheets_0, door_0, cell_1, mirror_1, sheets_1, door_1, freedom};
	private States myState = States.intro;
	private bool gotMirror = false;

	// Use this for initialization
	void Start () {
		text.text = "Your family has been very fortunate lately. " +
			"Their soap scum cleaning business has been a hit, and " +
				"you employ over 30 people in the community. One evening, " +
				"your family was invited to dinner at the governor's mansion. " +
				"Needless to say, it was a great honor for a once poor family " +
				"such as your own. Dreaming of a grand banquet, you decided to eat light " +
				"and cheap with a food cart falafel for lunch. You did not know it " +
				"then, but each munch of fried chickpeas and white sauce " + 
				"was bringing you 1 PSI closer to your current predicament. " +
				"At the governor's dinner, somebody accidentally dropped their fork. " +
				"It fell right onto your shoe, and, bending over to pick it up, you " +
				"inadvertently let out the loudest and most nausating flatulent that " +
				"anyone in the room had ever experienced. Vomit-soaked horror, " + 
				"chaos, and, ultimately, rage ensued.\nYou farted on the governor's daughter. " +
				"You have been charged with attempted assassination, " +
				"the trial and execution are tomorrow... YOU MUST FIND A WAY TO ESCAPE!\n" +
				"Press SPACE to look around.";
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.intro && Input.GetKeyDown(KeyCode.Space)) {
			myState = States.cell_0;
		} else if (myState == States.cell_0) {
			state_cell_0();
		} else if (myState == States.mirror_0) {
			state_mirror_0();
		} else if (myState == States.sheets_0) {
			state_sheets_0();
		} else if (myState == States.door_0) {
			state_door_0();
		} else if (myState == States.get_mirror) {
			state_getMirror();
		} else if (myState == States.cell_1) {
			state_cell_1();
		} else if (myState == States.mirror_1) {
			state_mirror_1();
		} else if (myState == States.sheets_1) {
			state_sheets_1();
		} else if (myState == States.door_1) {
			state_door_1();
		} else if (myState == States.freedom) {
			state_freedom();
		}
	}
	
	void state_cell_0 () {
		text.text = "There are some dirty sheets on the bed, a mirror on the wall, " +
					"and a door that is locked from the outside.\n\n" +
					"Press S to view the Sheets\n" +
					"Press M to view the Mirror\n" +
					"Press D to view the Door";
					
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown(KeyCode.M)) {		
			myState = States.mirror_0;
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.door_0;
		}
	}
	
	void state_mirror_0 () {
		text.text = "You look into the mirror at a pathetic pale person soaked in a cold sweat.\n" +
					"How could you this have happened? You never farted in public before. " +
					"You never even fart in front of your own family. " +
					"There is nothing but shame and hatred looking back at you.\n\n" +
					"Press C to go back to the middle of the Cell\n" +
					"Press R to Rip the mirror from the wall!";
					
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.get_mirror;
		}
		if (Input.GetKeyDown(KeyCode.C)) {		
			myState = States.cell_0;
		}
	}
	
	void state_getMirror () {
		text.text = "You bash the mirror with your hands and it starts to budge. " +
					"After sliding your fingertips behind the frame, you pull hard " +
					"and the shoddy piece of shit rips right out of the wall!\n\n" +
					"Press SPACE";
					
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.cell_1;
		}
					
	}
	
	void state_sheets_0 () {
		
	}
	
	void state_door_0 () {
		
	}
	
	void state_cell_1 () {
		text.text = "There are some dirty sheets on the bed, a space where the mirror was on the wall, " +
					"and a door that is locked from the outside.\n\n" +
					"Press S to view the Sheets\n" +
					"Press M to view the Mirror space\n" +
					"Press D to view the Door";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown(KeyCode.M)) {		
			myState = States.mirror_1;
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.door_0;
		}
	}
	
	void state_mirror_1 () {
		text.text = "There is a light rectangular mark with screw holes in it from where " +
					"the mirror used to be. Someone, (the installer?) has graffitied an obscene " +
					"drawing in the middle of the rectangle:\n\n\t\t" +
					" O\n\t\t  |\\\t\t  _._\n\t\t  |==D~  > )j\n\t\t /\\\t\t\t  o|\n\t\t/_\\_\t\t\t3__," +
					"\n\nPress C to go back to the middle of the cell you perv!";
		if (Input.GetKeyDown(KeyCode.C)) {		
			myState = States.cell_1;
		}
	}
	
	void state_sheets_1 () {
		
	}
	
	void state_door_1 () {
		
	}
	
	void state_freedom () {
	
	}
}
