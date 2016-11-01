using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {intro, cell, mirror, getMirror, getSheets, bed_0, door_0, bed_1, door_1, freedom, open_door};
	private States myState 		 = States.intro;
	private bool gotSheets 		 = false;
	private bool gotMirror 		 = false;
	private bool leftCell 		 = false;
	private bool gotJanitorKey = false;
	private bool gotRag 			 = false;
	private bool cleanedShower = false;
	private bool gotBroom 		 = false;
	private bool gotKeyring 	 = false;
	private bool gotUniform 	 = false;

	// Use this for initialization
	void Start () {
		text.text = "Your family's soap scum cleaning business has been a hit, and " +
								"you now employ over 30 people in the community. One day, " +
								"you were invited to clean soap scum at the governor's mansion. " +
								"Needless to say, it was a great honor for a once poor family " +
								"such as your own. Dreaming of riches, you headed off to the palace " +
								"barely able to keep your heart in your chest. You were told to enter " +
								"the servant's entrance, and to keep to yourself. No talking, don't even look " +
								"at the governor or his family. Still, you floated up the staircase to the bathroom " +
								"like a butterfly on the breeze, and got to work scrubbing the tub with joy. " +
								"As brutal fate would have it, the governor's bride was oblivious that a blue collar would " +
								"be buffing her bathroom. Bundled in a bathrobe, she barked when she beheld " +
								"a burly buttcrack bent over the brim of her beloved bathtub. " +
								"She dropped her garment as she shrieked, and, as you looked back startled, " +
								"you realized that birth marks are oddly common in the governor's family and shrieked quite involuntarily. " +
								"You have been charged with attempted assassination and treason, your family is a disgrace, " +
								"the trial and execution are tomorrow... YOU MUST FIND A WAY TO ESCAPE!\n" +
								"Press SPACE to look around.";
	}

	// Update is called once per frame
	void Update () {
		if (myState == States.intro && Input.GetKeyDown(KeyCode.Bpace)) {myState = States.cell;}
		else if (myState == States.cell) 			{cell();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.bed_0) 		{bed_0();}
		else if (myState == States.door_0) 		{door();}
		else if (myState == States.getMirror) {getMirror();}
		else if (myState == States.getSheets) {getSheets();}
		else if (myState == States.freedom) 	{freedom();}
		else if (myState == States.open_door) {open_door();}
	}

	void cell () {
		if (!leftCell && !gotSheets && !gotMirror) {
				text.text = "There are some dirty sheets on the bed, a mirror on the wall, " +
										"and a door that is locked from the outside.\n\n" +
										"Press B to view the Bed\n" +
										"Press M to view the Mirror\n" +
										"Press D to view the Door";
		} else if (!leftCell && !gotSheets && gotMirror) {
				cellNoMirror();
		} else if (!leftCell && !gotMirror && gotSheets) {
				cellNoSheets();
		} else if (!leftcell && gotMirror && gotSheets) {
			cellNoSheetsNoMirror();
		}

		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bed;}
		if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror;}
		if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.door_0;}
	}

	void cellNoMirror () {
		text.text = "There are some dirty bed on the bed, " +
		 						"a space where the mirror was on the wall, " +
								"and a door that is locked from the outside.\n\n" +
								"Press S to view the bed\n" +
								"Press M to view the Mirror space\n" +
								"Press D to view the Door";
	}

	void cellNoSheets() {
		text.text = "There is a mattress that appears to have a sheet fused to it, " +
								"a mirror on the wall, " +
								"and a door that is locked from the outside.\n\n" +
								"Press S to view the Mattress\n" +
								"Press M to view the Mirror\n" +
								"Press D to view the Door";
	}

	void cellNoSheetsNoMirror () {
		text.text = "There is a mattress that appears to have a sheet fused to it, " +
								"a space where the mirror was on the wall, " +
								"and a door that is locked from the outside.\n\n" +
								"Press S to view the Mattress\n" +
								"Press M to view the Mirror\n" +
								"Press D to view the Door";
	}

	void mirror () {
		if (!gotMirror) {
			text.text = "You look into the mirror at a pathetic pale person soaked in a cold sweat.\n" +
									"How could you this have happened? You've never done wrong before. " +
									"You promised not to tell a soul about what you saw, but how could you not? " +
									"They're not going to let you out of here, you have to break out and flee.\n\n" +
									"Press C to go back to the middle of the Cell\n" +
									"Press R to Rip the mirror from the wall!";

									if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.getMirror;}
		} else if (gotMirror){
				text.text = "There is a light rectangular mark with screw holes in it from where " +
										"the mirror used to be. Someone, (the installer?) has carved a doggerel behind it:\n\n" +
										"I once ate dinner at the master's house,\nAfter eating he was straight to bed\n" +
										"His wife stayed and dropped me her blouse.\nHoley moley I near dropped dead!\n" +
										"\n\nPress C to go back to the middle of the cell.";
		} else if (!gotMirror && gotSheets){

		}

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void getMirror () {
		text.text = "You bash the mirror with your hands and it starts to budge. " +
								"After sliding your fingertips behind the frame, you pull hard " +
								"and the shoddy piece of shit rips right out of the wall!\n\n" +
								"Press SPACE";
		gotMirror = true;

		if (Input.GetKeyDown(KeyCode.Bpace)) {myState = States.cell;}
	}

	void bed () {
		if (!gotSheets) {
			text.text = "There's a sheet tucked around the mattress and another on top of that. " +
									"They're both an off-white, an oily yellow. They definitely should be changed.\n" +
									"There's neither window or rafter to make any use of them, unwashed togas maybe.\n" +
									"\n\nPress C to go back to the middle of the cell.\n" +
									"Press S to grab the sheets."
									if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.getSheets;}
		} else {
			text.text = "There's a sheet tucked around the mattress, you tried to take it off but it was really starchy, and stuck to the mattress like glue. " +
									"It definitely should be changed, but it doesn't look it it can be.\n" +
									"\n\nPress C to go back to the middle of the cell.\n"
		}

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void door () {
		if (!gotMirror) {
				text.text = "It's a big iron door with a slot they slide the food tray through for meals. " +
										"The food's not bad, but they don't use enough salt. Anyways, yup, the door's still locked.\n" +
										"\n\nPress C to go back to the middle of the cell.";
		} else {
			text.text = "The mirror is a good size for putting out the food tray slot...\n" +
									"You can see the reflection down the hall, the guard is sleeping at his desk, he even brings in a neck pillow. " +
									"You look down at the door handle... the lock is just a latch, you could easily reach out and let yourself out. " +
									"It can't be that easy, can it?" +
									"\n\nPress C to go back to the middle of the cell." +
									"\nPress Space to go out the door.";

			if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.freedom;}
		}

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void getSheets () {
		text.text = "You take the sheet off the bed and wrap them around yourself, tying it at the shoulder. " +
								"You look at yourself in the mirror and dream of a cell block toga party... Too bad " +
								"there's no time to dream, you have to get out of here!" +
								"\n\nPress C to go back to the middle of the cell.";
		gotSheets = true;

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void freedom () {
		text.text = "You slide your hand out the slot in the door and lift up the latch. " +
					"You can already feel the door start opening before you even push it... " +
					"Can it really be this simple? Download the Prison Break DLC for $2.99 to find out!" +
					"\nPress Space to continue.";

		if (Input.GetKeyDown(KeyCode.Bpace)) 	{myState = States.open_door;}
	}

	void open_door () {
		text.text = "Ok, we'll give you a little more for free. (but not much you cheapskate!)\n" +
					"The door swings open with ease, too easily as it goes all the way around " +
					"and clangs against the wall. The noise is loud and echoes through the corridor. " +
					"The guard down the hall snorts and bit, but he doesn't wake up. He's out cold.\n\n" +
					"Press SPACE to continue into the corridor.";
	}
}
