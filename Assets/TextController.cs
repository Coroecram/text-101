using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {intro, cell_0, mirror_0, get_mirror, sheets_0, door_0, cell_1, mirror_1, sheets_1, door_1, freedom, ending};
	private States myState = States.intro;
	private bool gotMirror = false;

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
				"As cruel fate would have it, the governor's daughter was unaware that anyone would " +
				"be cleaning her bathtub that day. Wrapped in a towel, she screamed as she saw " +
				"a burly buttcrack bent over the rim of her treasured bathtub. " +
				"She dropped her towel as she shrieked, and, as you looked back, startled, " +
				"you realized that birth marks are oddly common in the governor's family. " +
				"You have been charged with attempted assassination, your family is a disgrace, " +
				"the trial and execution are tomorrow... YOU MUST FIND A WAY TO ESCAPE!\n" +
				"Press SPACE to look around.";
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.intro && Input.GetKeyDown(KeyCode.Space)) {myState = States.cell_0;} 
		else if (myState == States.cell_0) 		{state_cell_0();} 
		else if (myState == States.mirror_0) 	{state_mirror_0();} 
		else if (myState == States.sheets_0) 	{state_sheets_0();}
		else if (myState == States.door_0) 		{state_door_0();} 
		else if (myState == States.get_mirror) 	{state_getMirror();}
		else if (myState == States.cell_1) 		{state_cell_1();}
		else if (myState == States.mirror_1) 	{state_mirror_1();}
		else if (myState == States.sheets_1) 	{state_sheets_1();}
		else if (myState == States.door_1) 		{state_door_1();}
		else if (myState == States.freedom) 	{state_freedom();}
		else if (myState == States.ending) 	{state_ending();}
	}
	
	void state_cell_0 () {
		text.text = "There are some dirty sheets on the bed, a mirror on the wall, " +
					"and a door that is locked from the outside.\n\n" +
					"Press S to view the Sheets\n" +
					"Press M to view the Mirror\n" +
					"Press D to view the Door";
					
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;}
		if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror_0;}
		if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.door_0;}
	}
	
	void state_mirror_0 () {
		text.text = "You look into the mirror at a pathetic pale person soaked in a cold sweat.\n" +
					"How could you this have happened? You've never done wrong before. " +
					"You promised not to tell a soul about what you saw, but how could you not? " +
					"They're not going to let you out of here, you have to break out and flee.\n\n" +
					"Press C to go back to the middle of the Cell\n" +
					"Press R to Rip the mirror from the wall!";
					
		if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.get_mirror;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell_0;}
	}
	
	void state_getMirror () {
		text.text = "You bash the mirror with your hands and it starts to budge. " +
					"After sliding your fingertips behind the frame, you pull hard " +
					"and the shoddy piece of shit rips right out of the wall!\n\n" +
					"Press SPACE";
					
		if (Input.GetKeyDown(KeyCode.Space)) {myState = States.cell_1;}
	}
	
	void state_sheets_0 () {
		text.text = "There's a sheet tucked around the mattress and another on top of that. " +
					"They're both an off-white, an oily yellow. They definitely should be changed.\n" +
					"There's neither window or rafter to make any use of them, unwashed togas maybe.\n" +
					"\n\nPress C to go back to the middle of the cell.";
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell_0;}
	}
	
	void state_door_0 () {
		text.text = "It's a big iron door with a slot they slide the food tray through for meals. " +
					"The food's not bad, but they don't use enough salt. Anyways, yup, the door's still locked.\n" +
					"\n\nPress C to go back to the middle of the cell.";
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell_0;}		
	}
	
	void state_cell_1 () {
		text.text = "There are some dirty sheets on the bed, a space where the mirror was on the wall, " +
					"and a door that is locked from the outside.\n\n" +
					"Press S to view the Sheets\n" +
					"Press M to view the Mirror space\n" +
					"Press D to view the Door";
		
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_1;}
		if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror_1;}
		if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.door_1;}
	}
	
	void state_mirror_1 () {
		text.text = "There is a light rectangular mark with screw holes in it from where " +
					"the mirror used to be. Someone, (the installer?) has carved a doggerel behind it:\n\n" +
					"I once ate dinner at the master's house,\nAfter eating he was straight to bed\n" +
					"His wife stayed and dropped me her blouse.\nHoley moley I near dropped dead!\n" +
					"\n\nPress C to go back to the middle of the cell.";
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell_1;}
	}
	
	void state_sheets_1 () {
		text.text = "You take the sheet off the bed and wrap them around your self, tying it at the shoulder. " +
					"You look at yourself in the mirror and dream of a cell block toga party... Too bad " +
					"there's no time to dream, you have to get out of here!\nYou put the sheet back down on the bed." +
					"\n\nPress C to go back to the middle of the cell.";
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell_1;}
	}
	
	void state_door_1 () {
		text.text = "The mirror is a good size for putting out the food tray slot...\n " +
					"You can see the reflection down the hall, the guard is sleeping at his desk, he even brings in a neck pillow. " +
					"You look down at the door handle... the lock is just a latch, you could easily reach out and let yourself out. " +
					"It can't be that easy, can it?" +
					"\n\nPress C to go back to the middle of the cell." +
					"\nPress Space to go out the door.";
					
		if (Input.GetKeyDown(KeyCode.C)) 		{myState = States.cell_1;}
		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.freedom;}
	}
	
	void state_freedom () {
		text.text = "You slide your hand out the slot in the door and lift up the latch. " +
					"You can already feel the door start opening before you even push it... " +
					"Can it really be this simple? Download the Prison Break DLC for $2.99 to find out!" +
					"\nPress Space to continue.";
		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.ending;}
	}

	void state_ending () {
		text.text = "\n\n\n\t\t\t\t\tTHE END?";
	}
}
