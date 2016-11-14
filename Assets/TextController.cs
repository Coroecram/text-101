using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {intro, cell, mirror, getMirror, getSheets, bed, cellDoor, leaveCell, openCell, corridor, closet, openCloset, getBroom, getUniform, eatRoach, eatMouse, drinkBleach, guard, getKeyring, stairwell,	gate, openGate, bathroom, toilet, useToilet, clogged, unclogToilet, shower, useShower, cleanShower, exit};

	private States myState 		 = States.corridor;
	private bool gotSheets 		 = false;
	private bool gotMirror 		 = false;
	private bool leftCell 		 = false;
	private bool gotJanitorKey = false;
	private bool closetOpen		 = false;
	private bool usedToilet		 = false;
	private bool gotRag				 = false;
	private bool cloggedToilet = false;
	private bool cleanedShower = false;
	private bool gotBroom 		 = false;
	private bool gotKeyring 	 = false;
	private bool gotUniform 	 = false;
	private bool ateMouse 		 = false;

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
		if (myState == States.intro && Input.GetKeyDown(KeyCode.Space)) {myState = States.cell;}
		else if (myState == States.cell) 					{cell();}
		else if (myState == States.mirror) 				{mirror();}
		else if (myState == States.bed) 					{bed();}
		else if (myState == States.cellDoor) 			{cellDoor();}
		else if (myState == States.getMirror) 		{getMirror();}
		else if (myState == States.getSheets) 		{getSheets();}
		else if (myState == States.leaveCell) 		{leaveCell();}
		else if (myState == States.openCell) 			{openCell();}
		else if (myState == States.corridor) 			{corridor();}
		else if (myState == States.closet) 			  {closet();}
		else if (myState == States.openCloset) 		{openCloset();}
		else if (myState == States.getBroom) 			{getBroom();}
		else if (myState == States.getUniform) 		{getUniform();}
		else if (myState == States.eatRoach)			{eatRoach();}
		else if (myState == States.eatMouse)			{eatMouse();}
		else if (myState == States.drinkBleach)	  {drinkBleach();}
		else if (myState == States.guard) 				{guard();}
		else if (myState == States.getKeyring) 		{getKeyring();}
		else if (myState == States.stairwell) 		{stairwell();}
		else if (myState == States.gate) 					{gate();}
		else if (myState == States.openGate) 			{openGate();}
		else if (myState == States.bathroom) 			{bathroom();}
		else if (myState == States.toilet) 				{toilet();}
		else if (myState == States.useToilet) 		{useToilet();}
		else if (myState == States.clogged) 			{clogged();}
		else if (myState == States.unclogToilet) 	{unclogToilet();}
		else if (myState == States.shower)			  {shower();}
		else if (myState == States.useShower) 		{useShower();}
		else if (myState == States.cleanShower) 	{cleanShower();}
		else if (myState == States.exit)				 	{exit();}
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
		} else if (!leftCell && gotMirror && gotSheets) {
			cellNoSheetsNoMirror();
		}

		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bed;}
		if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror;}
		if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.cellDoor;}
	}

	void cellNoMirror () {
		text.text = "There are some dirty bed on the bed, " +
		 						"a space where the mirror was on the wall, " +
								"and a door that is locked from the outside.\n\n" +
								"Press B to view the Bed\n" +
								"Press M to view the Mirror space\n" +
								"Press D to view the Door";
	}

	void cellNoSheets() {
		text.text = "There is a mattress that appears to have a sheet fused to it, " +
								"a mirror on the wall, " +
								"and a door that is locked from the outside.\n\n" +
								"Press B to view the Bed\n" +
								"Press M to view the Mirror\n" +
								"Press D to view the Door";
	}

	void cellNoSheetsNoMirror () {
		text.text = "There is a mattress that appears to have a sheet fused to it, " +
								"a space where the mirror was on the wall, " +
								"and a door that is locked from the outside.\n\n" +
								"Press B to view the Bed\n" +
								"Press M to view the Mirror\n" +
								"Press D to view the Door";
	}

	void mirror () {
		if (!gotMirror && !gotSheets) {
			text.text = "You look into the mirror at a pathetic pale person soaked in a cold sweat.\n" +
									"How could you this have happened? You've never done wrong before. " +
									"You promised not to tell a soul about what you saw, but how could you not? " +
									"They're not going to let you out of here, you have to break out and flee.\n\n" +
									"Press C to go back to the middle of the Cell\n" +
									"Press R to Rip the mirror from the wall!";

									if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.getMirror;}
		} else if (!gotMirror && gotSheets){
			text.text = "You look into the mirror at a pathetic pale person wrapped in a tasteful toga soaked in a cold sweat.\n" +
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
										"\n\nPress C to go back to the middle of the Cell.";
		}

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void getMirror () {
		text.text = "You bash the mirror with your hands and it starts to budge. " +
								"After sliding your fingertips behind the frame, you pull hard " +
								"and the shoddy piece of shit rips right out of the wall!\n\n" +
								"Press SPACE";
		gotMirror = true;

		if (Input.GetKeyDown(KeyCode.Space)) {myState = States.cell;}
	}

	void bed () {
		if (!gotSheets) {
			text.text = "There's a sheet tucked around the mattress and another on top of that. " +
									"They're both an off-white, an oily yellow. They definitely should be changed.\n" +
									"There's neither window or rafter to make any use of them, unwashed togas maybe.\n" +
									"\n\nPress C to go back to the middle of the Cell\n" +
									"Press S to grab the Sheets.";
									if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.getSheets;}
		} else {
			text.text = "There's a sheet tucked around the mattress, you tried to take it off but it was really starchy, and stuck to the mattress like glue. " +
									"It definitely should be changed, but it doesn't look it it can be.\n" +
									"\n\nPress C to go back to the middle of the Cell\n";
		}

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void cellDoor () {
		if (!gotMirror) {
				text.text = "It's a big iron door with a slot they slide the food tray through for meals. " +
										"The food's not bad, but they don't use enough salt. Anyways, yup, the door's still locked.\n" +
										"\n\nPress C to go back to the middle of the Cell.";
		} else {
			text.text = "The mirror is a good size for putting out the food tray slot...\n" +
									"You can see the reflection down the hall, the guard is sleeping at his desk, he even brings in a neck pillow. " +
									"You look down at the door handle... the lock is just a latch, you could easily reach out and let yourself out. " +
									"It can't be that easy, can it?" +
									"\n\nPress C to go back to the middle of the Cell." +
									"\nPress Space to go out the door.";

			if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.leaveCell;}
		}

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void getSheets () {
		text.text = "You take the sheet off the bed and wrap them around yourself, tying it at the shoulder. " +
								"You look at yourself in the mirror and dream of a cell block toga party... Too bad " +
								"there's no time to dream, you have to get out of here!" +
								"\n\nPress C to go back to the middle of the Cell.";
		gotSheets = true;

		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
	}

	void leaveCell () {
		text.text = "You slide your hand out the slot in the door and lift up the latch. " +
								"You can already feel the door start opening before you even push it... " +
								"Can it really be this simple? Download the Prison Break DLC for $2.99 to find out!" +
								"\n\nPress Space to continue.";
		leftCell = true;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.openCell;}
	}

	void openCell () {
		text.text = "Ok, we'll give you a little more for free. (but not much you cheapskate!)\n" +
								"The door swings open with ease, too easily as it goes all the way around " +
								"and clangs against the wall. The noise is loud and echoes through the corridor. " +
								"The guard down the hall snorts and bit, but he doesn't wake up. He's out cold.\n\n" +
								"Press SPACE to continue into the corridor.";

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.corridor;}
	}

	void corridor () {
		if (!closetOpen) {
			text.text = "The corridor is tall and well-lit with large barred windows near the ceiling at each end. " +
									"Doors line the hall, perhaps other people in the same predicament, but you don't want to draw " +
									"any unnecessary attention, or release any real dangerous criminals, you just want to get out. " +
									"The guard is at one end of the corridor fast asleep in his chair, with one of those plane neck pillows. " +
									"There is a wall of bars between you and him. " +
									"At the other end of the corridor, there is the stairwell down the bathroom and showers, along with " +
									"the gate out. In the middle of the corridor there's a plain wooden door different from the other cells, " +
									"and, of course, your empty cell." +
									"\n\nPress G to approach the Guard.\nPress C to go back into your cell\nPress J to checkout the Janitor's closet." +
									"\nPress S to go down the Stairwell.";
			} else {
				text.text = "The corridor is tall and well-lit with large barred windows near the ceiling at each end. " +
										"Doors line the hall, perhaps other people in the same predicament, but you don't want to draw " +
										"any unnecessary attention, or release any real dangerous criminals, you just want to get out. " +
										"The guard is at one end of the corridor fast asleep in his chair, with one of those plane neck pillows. " +
										"There is a wall of bars between you and him. " +
										"At the other end of the corridor, there is the stairwell down the bathroom and showers, along with " +
										"the gate out. In the middle of the corridor there's an open wooden door to the janitor's closet, " +
										"and, of course, your empty cell.\n\nPress G to approach the Guard\nPress C to go back into your cell\n" +
										"Press J to checkout the Janitor's closet\nPress S to go down the Stairwell.";
			}

		if (Input.GetKeyDown(KeyCode.G)) 	{myState = States.guard;}
		if (Input.GetKeyDown(KeyCode.J)) 	{myState = States.closet;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairwell;}
	}

	void closet () {
		if (!openCloset && !gotJanitorKey) {
			text.text = "There's a plain beat-up wooden door with a tarnished brass doorknob and some gouge marks in it." +
									"You test it, but it's locked, it seems pretty sturdy and you don't want to alert " +
									"anybody by trying to open it.\n\nPress C to go back to the corridor";
		} else if (!openCloset && gotJanitorKey){
			text.text = "There's a plain beat up wooden door with a tarnished brass doorknob." +
									"The key you found hidden in the shower scum looks like it could fit the keyhole." +
									"\n\nPress C to go back to the corridor\nPress O to try and open the door";

			if (Input.GetKeyDown(KeyCode.O)) 	{myState = States.openCloset;}
		} else if (!gotBroom && !gotUniform) {
			text.text = "You go inside the closet and see that there's an old broom in a dry bucket in one corner, " +
									"a slop sink in another corner, a dead cockroach in another corner, a dead mouse in another corner, " +
									"a bottle of bleach in another corner, and a uniform hanging up on the wall. Remarkably, the slop sink " +
									"doesn't have any soap scum at all, but then you think that they just don't use soap.\n\nPress C to go back to the Corridor" +
									"\nPress R to eat the Roach\nPress M to eat the Mouse\nPress D to Drink the bleach\nPress B to grab the Broom\nPress U to put on the uniform.";

			if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.getBroom;}
			if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.getUniform;}
		} else if (!gotUniform && gotBroom) {
			text.text = "You go inside the closet and see that there's an old broom in a dry bucket in one corner, " +
									"a slop sink in another corner, a dead cockroach in another corner, a dead mouse in another corner, " +
									"a bottle of bleach in another corner, and a uniform hanging up on the wall. Remarkably, the slop sink " +
									"doesn't have any soap scum at all, but then you think that they just don't use soap.\n\nPress C to go back to the Corridor" +
									"\nPress R to eat the Roach\nPress M to eat the Mouse\nPress D to Drink the bleach\nPress U to put on the uniform";

			if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.getUniform;}
		} else if (!gotBroom && gotUniform) {

		} else {

		}

		if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.eatMouse;}
		if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.eatRoach;}
		if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.drinkBleach;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.corridor;}
	}

	void openCloset () {
		text.text = "You take out the key where you've been stashing it, wipe it off a bit, and put it in the keyhole. " +
								"It doesn't fit. It must be for something else.\nWait a second, you flip it over and it goes in. " +
								"You turn the key, hear the door unlock, and push it open.";
		closetOpen = true;

		if (Input.GetKeyDown(KeyCode.C)) 			{myState = States.corridor;}
		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.closet;}
	}

	void eatRoach () {
		text.text = "You walk to the corner of the room and look down at your next meal. " +
								"Wait, what are you doing? You just got here, you're not even hungry, nevermind starving, " +
								"and eating a roach is just disgusting, no one in their right mind would do something like that." +
								"\n\nPress Space to go look around the room.";

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.closet;}
	}

	void eatMouse () {
		if (!ateMouse) {
			text.text = "You walk to the corner of the room and look down at your next meal. " +
									"Wait, what are you doing? You just got here, you're not even hungry, nevermind starving." +
									"Still, you can't resist, you just can't control yourself." +
									"You pick up the dead mouse, put it in your mouth, and chomp. It's still crunchy, but could use some salt." +
									"\n\nPress Space to look around the closet.";

			ateMouse = true;
		} else {
			text.text = "You walk to the corner of the room and look down at your next meal. " +
									"Wait, what are you doing? You just got here, you're not even hungry, you already ate dead mouse." +
									"Another mouse died in the exact same corner now, so soon?" +
									"Still, you can't resist, you have always had these uncontrollable compulsions, and you know this mouse is fresh." +
									"You pick up the fresh dead mouse, put it in your mouth, and chomp. It's crunchy and juicy, but could use some salt." +
									"\n\nPress Space to look around the closet.";
		}

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.closet;}
	}

	void getBroom () {
		text.text = "You pick up the broom. You think you don't have enough space for it, but prison has made you resourceful." +
								"You check out the bucket, but it has a hole in the bottom of it. It wouldn't be very useful even if you had a mop." +
								"\n\nPress Space to look around the closet.";
		gotBroom = true;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.insideCloset;}
	}

	void getUniform () {
		text.text = "getUniform";
		gotUniform = true;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.insideCloset;}
	}

	void guard () {
		text.text = "guard";

		if (Input.GetKeyDown(KeyCode.K)) 	{myState = States.getKeyring;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.corridor;}
	}

	void getKeyring () {
		text.text = "getKeyring";
		gotKeyring = true;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.guard;}
	}

	void stairwell () {
		text.text = "stairwell";

		if (Input.GetKeyDown(KeyCode.G)) 	{myState = States.gate;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.corridor;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}

	void gate () {
		text.text = "gate";

		if (Input.GetKeyDown(KeyCode.O)) 	{myState = States.openGate;}
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairwell;}
	}

	void openGate () {
		text.text = "openGate";

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.exit;}
	}

	void bathroom () {
		text.text = "bathroom";

		if (Input.GetKeyDown(KeyCode.T)) 	{myState = States.toilet;}
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.shower;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.stairwell;}
	}

	void toilet () {
		text.text = "toilet";

		if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.useToilet;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}

	void useToilet () {
		text.text = "useToilet";
		usedToilet = true;
		cloggedToilet = true;

		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
		if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.unclogToilet;}
	}

	void clogged () {
		text.text = "clogged";

		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
		if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.unclogToilet;}
	}

	void unclogToilet () {
		text.text = "unclogToilet";
		gotRag = true;
		cloggedToilet = false;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.toilet;}
	}

	void shower () {
		text.text = "shower";

		if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.useShower;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cleanShower;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}

	void useShower () {
		text.text = "useShower";

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.shower;}
	}

	void cleanShower () {
		text.text = "cleanShower";
		gotJanitorKey = true;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.shower;}
	}

	void exit () {
		text.text = "exit";

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.stairwell;}
	}

}
