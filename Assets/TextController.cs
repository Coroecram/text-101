using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {intro, cell, mirror, getMirror, getSheets, bed, cellDoor, leaveCell, openCell, corridor, closet, openCloset, getBroom, getUniform, eatRoach, eatMouse, drinkBleach, guard, getKeyring, stairwell,	gate, openGate, papa, bathroom, toilet, useToilet, clogged, unclogToilet, shower, useShower, cleanShower, exit};

	private States myState 		 = States.corridor;
	private bool gotSheets 		 = false;
	private bool gotMirror 		 = false;
	private bool leftCell 		 = false;
	private bool gotJanitorKey 	 = false;
	private bool closetOpen		 = false;
	private bool usedToilet		 = false;
	private bool gotRag			 = false;
	private bool cloggedToilet 	 = false;
	private bool cleanedShower 	 = false;
	private bool gotBroom 		 = false;
	private bool gotKeyring 	 = false;
	private bool gotUniform 	 = false;
	private bool ateMouse 		 = false;
	private bool dadSawYou		 = false;

	// Use this for initialization
	void Start () {
		text.text =             "Your family's soap scum cleaning business has been a hit, and " +
								"you now employ over 30 people in the community since you started bottling and selling your secret formula. " +
								"One day, you were invited to clean soap scum at the governor's mansion. " +
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
		else if (myState == States.cell) 			{cell();}
		else if (myState == States.mirror) 			{mirror();}
		else if (myState == States.bed) 			{bed();}
		else if (myState == States.cellDoor)		{cellDoor();}
		else if (myState == States.getMirror) 		{getMirror();}
		else if (myState == States.getSheets) 		{getSheets();}
		else if (myState == States.leaveCell) 		{leaveCell();}
		else if (myState == States.openCell) 		{openCell();}
		else if (myState == States.corridor) 		{corridor();}
		else if (myState == States.closet) 			{closet();}
		else if (myState == States.openCloset) 		{openCloset();}
		else if (myState == States.getBroom) 		{getBroom();}
		else if (myState == States.getUniform) 		{getUniform();}
		else if (myState == States.guard) 			{guard();}
		else if (myState == States.getKeyring) 		{getKeyring();}
		else if (myState == States.stairwell) 		{stairwell();}
		else if (myState == States.gate) 			{gate();}
		else if (myState == States.papa)			{seePapa();}
		else if (myState == States.openGate) 		{openGate();}
		else if (myState == States.bathroom) 		{bathroom();}
		else if (myState == States.toilet) 			{toilet();}
		else if (myState == States.useToilet) 		{useToilet();}
		else if (myState == States.clogged) 		{clogged();}
		else if (myState == States.unclogToilet) 	{unclogToilet();}
		else if (myState == States.shower)			{shower();}
		else if (myState == States.useShower) 		{useShower();}
		else if (myState == States.cleanShower) 	{cleanShower();}
		else if (myState == States.exit)			{exit();}
	}

	void cell () {
		if (!leftCell && !gotSheets && !gotMirror) {
				text.text = 			"There are some dirty sheets on the bed, a mirror on the wall, " +
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
									"\n\nPress G to approach the Guard\nPress C to go back into your Cell\nPress J to checkout the Janitor's closet" +
									"\nPress S to go down the Stairwell";
			} else {
				text.text = "The corridor is tall and well-lit with large barred windows near the ceiling at each end. " +
										"Doors line the hall, perhaps other people in the same predicament, but you don't want to draw " +
										"any unnecessary attention, or release any real dangerous criminals, you just want to get out. " +
										"The guard is at one end of the corridor fast asleep in his chair, with one of those plane neck pillows. " +
										"There is a wall of bars between you and him. " +
										"At the other end of the corridor, there is the stairwell down the bathroom and showers, along with " +
										"the gate out. In the middle of the corridor there's an open wooden door to the janitor's closet, " +
										"and, of course, your empty cell\n\nPress G to approach the Guard\nPress C to go back into your Cell\n" +
										"Press J to checkout the Janitor's closet\nPress S to go down the Stairwell";
			}

		if (Input.GetKeyDown(KeyCode.G)) 	{myState = States.guard;}
		if (Input.GetKeyDown(KeyCode.J)) 	{myState = States.closet;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell;}
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairwell;}
	}

	void closet () {
		if (!closetOpen && !gotJanitorKey) {
			text.text = "There's a plain beat-up wooden door with a tarnished brass doorknob and some gouge marks in it. " +
									"You test it, but it's locked, it seems pretty sturdy and you don't want to alert " +
									"anybody by trying to open it.\n\nPress C to go back to the corridor";
		} else if (!closetOpen && gotJanitorKey){
			text.text = "There's a plain beat up wooden door with a tarnished brass doorknob." +
									"The key you found hidden in the shower scum looks like it could fit the keyhole." +
									"\n\nPress O to try and Open the door\nPress C to go back to the corridor";

			if (Input.GetKeyDown(KeyCode.O)) 	{myState = States.openCloset;}
		} else if (!gotBroom && !gotUniform) {
			text.text = "You go inside the closet and see that there's an old broom in a dry bucket in one corner, " +
									"a slop sink in another corner, a dead cockroach in another corner, a dead mouse in another corner, " +
									"a bottle of bleach in another corner, and a uniform hanging up on the wall. Remarkably, the slop sink " +
									"doesn't have any soap scum at all, but then you think that they just don't use soap.\n\nPress C to go back to the Corridor" +
									"\nPress R to eat the Roach\nPress M to eat the Mouse\nPress D to Drink the bleach\nPress B to grab the Broom\nPress U to put on the uniform.";
			Debug.Log("here");
			if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.getBroom;}
			if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.getUniform;}
		} else if (!gotUniform && gotBroom) {
			text.text = "You go inside the closet and see that there's an empty a dry bucket in one corner with a hole in the bottom, " +
									"a slop sink in another corner, a dead cockroach in another corner, a dead mouse in another corner, " +
									"a bottle of bleach in another corner, and a uniform hanging up on the wall. Remarkably, the slop sink " +
									"doesn't have any soap scum at all, but they probably just don't use soap.\n\nPress C to go back to the Corridor" +
									"\nPress R to eat the Roach\nPress M to eat the Mouse\nPress D to Drink the bleach\nPress U to put on the uniform";
			if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.getUniform;}
		} else if (!gotBroom && gotUniform) {
			text.text = "You go inside the closet and see that there's an old broom in a dry bucket in one corner, " +
						"a slop sink in another corner, a dead cockroach in another corner, a dead mouse in another corner, " +
						"a bottle of bleach in another corner. Remarkably, the slop sink " +
						"doesn't have any soap scum at all, but they probably just don't use soap.\n\nPress C to go back to the Corridor" +
						"\nPress R to eat the Roach\nPress M to eat the Mouse\nPress D to Drink the bleach\nPress B to grab the Broom";
			if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.getBroom;}
		} else {
			text.text = "You go inside the closet and see that there's an empty dry bucket in one corner with a hole in the bottom, " +
						"a slop sink in another corner, a dead cockroach in another corner, a dead mouse in another corner, " +
						"a bottle of bleach in another corner. Remarkably, the slop sink " +
						"doesn't have any soap scum at all, but they probably just don't use soap.\n\nPress C to go back to the Corridor" +
						"\nPress R to eat the Roach\nPress M to eat the Mouse\nPress D to Drink the bleach";
		}
		
		if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.eatMouse;}
		if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.eatRoach;}
		if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.drinkBleach;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.corridor;}
	}

	void openCloset () {
		text.text = "You take out the key where you've been stashing it, wipe it off a bit, and put it in the keyhole. " +
								"It doesn't fit. It must be for something else.\nWait a second, you flip it over and it goes in. " +
								"You turn the key, hear the door unlock, and push it open.\n\n" +
								"Press Space to continue through the door\nPress C to go back to the Corridor";
		closetOpen = true;

		if (Input.GetKeyDown(KeyCode.C)) 		{myState = States.corridor;}
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
		text.text = "You pick up the broom. You didn't think you had enough space for it, but prison has made you resourceful." +
								"You check out the bucket, but it has a hole in the bottom of it. It wouldn't be very useful even if you had a mop." +
								"\n\nPress Space to look around the closet.";
		gotBroom = true;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.closet;}
	}

	void getUniform () {
		text.text = "You pull the uniform up and off the hook. You hold it up and it looks like it would fit you perfectly. " +
					"It'd be nice if it was ever washed, but it wasn't and it's covered in little splotches of every shade of brown. " +
					"Most of it is soft, greasy soft, but the front, especially near the crotch, and sleevecuffs are starchy stiff. " +
					"You step into each leg and the zipper crunches as you pull it all the way up in front. " + 
					"Your nametag says Proops, for the person who cleans poops.";
		gotUniform = true;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.closet;}
	}

	void guard () {
		if (!gotKeyring) {
			text.text = "You cautiously approach the guard until you are right near the bars by him. " +
						"He has his feet up on his desk and is leaning back in his chair, passed out and snoring. " +
						"His belly is sticking out of the bottom of his shirt, and you notice that there is no hair. This information might come in handy. " +
						"Around his belt there are a set of keys on a hook, the literal keys to your freedom!\n\n" +
						"Press K to grab the Keyring\nPress C to go back to the Corridor";
		}else {
			text.text = "You skip up the bars whistling a jaunty tune! The guard snorts violently, and then goes right back to snoring. " +
						"How do they choose the guards in these places?";
		}

		if (Input.GetKeyDown(KeyCode.K)) 	{myState = States.getKeyring;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.corridor;}
	}

	void getKeyring () {
		if(!gotBroom) {
			text.text = "Slowly, very slowly you lean closer to the bars and reach out towards the keyring. " +
						"You stretch and strain and, admittedly, even release some gas, but the keys are RIGHT out of reach. " +
						"If only it could be so easy!\n\n" +
						"Press Space to continue.";
		}else {
			text.text = "Slowly, very slowly you lean closer to the bars and reach out towards the keyring. " +
						"You stretch and strain and, admittedly, almost release some gas, but then you remeber the broom. " +
						"EUREKA! You pull out the broom and then use the handle to reach towards the keyring...\n" +
						"Nerves get the better of you and you shake, the end of the handle pokes the guard right in his exposed gut, " +
						"then right in his neck pillow. You even poke him right in the eye! He rubs his face and grumbles, but stays asleep. " +
						"FOCUS DAMN YOU! THIS IS YOUR LIFE AT STAKE HERE! Finally, you get the keyring onto the end of the broomstick and pull it back off the guard's belt.\n" +
						"Finally, you can get out of here!\n" +
						"Press space to continue.";
			gotKeyring = true;
		}
		
		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.guard;}
	}

	void stairwell () {
		text.text = "The stairway is old and dirty, it hasn't been mopped in a long long time. If someone had used soap on it, there'd be scum. " +
					"There are 3 ways to go by the stairs: to the bathroom, to the corridor, or to the gate with sunlight coming through it.\n\n" +
					"Press G to go to the Gate\nPress C to go to the Corridor\nPress B to go to the Bathroom";

		if (Input.GetKeyDown(KeyCode.G)) 	{myState = States.gate;}
		if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.corridor;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}

	void gate () {
		if(!dadSawYou) {
			myState = States.papa;
		}else {
			text.text = "You look out on a rotten old bus stop, if you could get out of here, you'd be free and easy.\n\n" +
						"Press O to Open the gate\nPress S to go back to the Stairwell";
		}
		
		if (Input.GetKeyDown(KeyCode.O)) 	{myState = States.openGate;}
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairwell;}
	}
	
	void seePapa () {
		text.text = "You walk down the stairs to the gate on the bottom floor. You look out and there's not even a wall outside, it's a street. " +
			"Across the street there's a rotten wooden bench with a covering over it with moss growing on the roof." +
				"Sitting on that rotten wooden bench, is a rotten wooden old man, and he's picking his nose. Where the hell are you?" +
				"Wait a second, you know exactly where you are, this is the town where you grew up, and that's your father picking his nose!" +
				"You wave and scream to get his attention, but he's as blind as a bat and deaf as a... wait, he's not deaf and he has perfect eyesight! " +
				"'Papa! Papa! Please save your boy!', you scream. He looks up towards you. Thank God! Fantasies of dynamite and tools flash through your mind!\n" +
				"He extends his arm, and then extends his middle finger. The bus crosses in front of him and stops. " +
				"He keeps flipping you off through the windows of the bus... he's still sore that you bottled and sold the secret family soap scum cleaning formula. Superstitious asshole.\n\n" +
				"Press O to Open the gate\nPress S to go back to the Stairwell";  
		dadSawYou=true;
		
		if (Input.GetKeyDown(KeyCode.O)) 	{myState = States.openGate;}
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairwell;}
	}

	void openGate () {
		if(!gotKeyring) {
			text.text = "You shake the gate but they actually locked this one. A passerby gives you a sideways glance and then spits on the ground in front of them with a gruff.\n\n" +
						"Press Space to go back to the Stairwell";
						
			if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.stairwell;}
		}else {
			text.text = "You reach through the bars and frantically try every key in the hole on the other side... none of them are fitting. " +
						"A passerby gives you a sideways glance, and then spits on the ground in front of them without taking much notice. " +
						"Finally, you got it! The lock turns and the gate swings open! Free at last, free at last!\n" +
						"Press Space to Escape!";
			if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.exit;}
		}

	}

	void bathroom () {
		text.text = "You head down the stairs into the bathroom, you look around but all you see is soap scum everywhere. " +
					"On the sinks against the wall, on the tiles on the floor, on the tiles on the walls, on the tiles on the ceiling. " +
					"Literally every tile has soap scum on it, this is hell. There's a doorway to the toilets and another to the showers.\n\n" +
					"Press T to go to the Toilets\nPress S to go to the Showers\nPress B to go Back to the stairwell";

		if (Input.GetKeyDown(KeyCode.T)) 	{myState = States.toilet;}
		if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.shower;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.stairwell;}
	}

	void toilet () {
		text.text = "There are a bunch of stinky toilets along the wall, they are shorter than is comfortable for your legs, but they do the trick for your bowels.\n\n" +
					"Press U to Use the toilet\nPress B to go back to the Bathroom entrance";

		if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.useToilet;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}

	void useToilet () {
		if(!usedToilet && !cloggedToilet) {
			myState = States.clogged;
			if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.unclogToilet;}
		}else if(usedToilet && cloggedToilet) {
			text.text = "Why are you back here? They say that a criminal always returns to the scene of the crime. " +
						"But you're not a criminal, you've been imprisoned unjustly. What law says a man must unclog their own toilet!? " +
						"Still, looking down into the bowl, you just can't shake the guilt.\n\n" +
						"Press U to Unclog the toilet\nPress B to go Back to the bathroom";
			if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.unclogToilet;}
		}else {
			text.text = "Going back up to the toilet where you found the rag, you imagine the Germans probably have a word for being proud and not proud of something at the same time. " +
						"They definitely should.\n\nPress B to go Back to the bathroom";
		}

		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}
	
	void clogged () {
		text.text = "You were happy to get out of your cell for freedom, but you were really happy to get out of your cell to ride one of these porcelian stallions " +
				"into the great unknown. You drop your drawers and squat down over the shiniest steed. BOOM, and it's over. " +
				"It feels like the first time you had sex, but there's no one left disappointed.\n" +
				"You get up and flush, o no. O NO! The toilet is very disappointed, in fact, it's still hungry and choking on a huge log of disappointment.\n\n" +
				"Press U to Unclog the toilet\nPress B to Back away and leave it for the next guy";
		
		usedToilet = true;
		cloggedToilet = true;
		
		if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.unclogToilet;}
		if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}

	void unclogToilet () {
		text.text = "You can't bear the guilt, you have a very low tolerance for it. So low, you plunge your fist through what is better left unsaid. " +
					"You punch your way through until you get your hand wrapped up in something that you didn't eat. Or did you? No, no, you definitely didn't eat a towel." +
					"You grab what your hand is on and pull it out. It's a rag, a dirty old rag. There's a picture of a cat licking it's paw on it, but now it's paw is covered in shit. " +
					"It's dirty, but it's still a rag, that's why they're called rags. You put it in your pocket.\n\nPress Space to continue";
		gotRag = true;
		cloggedToilet = false;

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.toilet;}
	}

	void shower () {
		if(!cleanedShower) {
			text.text = "The shower is even dirtier than the bathroom, except with more hair. You've never seen so much soap scum in your life. " +
						"If you added up all of the soap scum you ever saw, ever since your father took you to clean bathrooms as a baby, you'd only get " +
						"only about halfway through the layer of scum on the floor. It is horrible, but so horrible you can't look away.\n\n" +
						"Press U to Use the shower\nPress B to go Back to the bathroom\nPress C to Clean the scum";
			if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.cleanShower;}
		}else {
		text.text = "The shower is even dirtier than the bathroom, except for that one clean spot you made. That's your spot, it will always be your spot. " +
					"It is beautiful, yet so horrible you can't look away.\n\n" +
					"Press U to Use the shower\nPress B to go Back to the bathroom";
		}
			if (Input.GetKeyDown(KeyCode.U)) 	{myState = States.useShower;}
			if (Input.GetKeyDown(KeyCode.B)) 	{myState = States.bathroom;}
	}

	void useShower () {
		text.text = "You haven't showered since yesterday, a relaxing shower would be nice. You take a step but then you recoil reflexively from the layer of " +
					"soap scum... you can't bring yourself to step in it. Wait a minute, you're going to be executed! There's no time for a shower!\n\n" +
					"Press Space to continue";

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.shower;}
	}

	void cleanShower () {
		if(!gotRag) {
			text.text = "You can't help it! You have to clean the shower! It's in your blood! Your soul cries out for you to clean this scum!!! " +
						"You get down on your hands and knees, you beat, you bite, you claw, you pound against the scum, but it is too strong. " +
						"'PAPA!!!! MAMA!!!!!', you cry out, but there's not even a smudge in this scum. Tears and snot stream down your pathetic face. " +
						"You have never faced a foe so strong before. Soaked in sweat, you finally give up, laying there defeated in a pool of shame.\n\n" +
						"Press Space to get back up and be a man";
		}else {
			text.text = "You pull out the kitten rag, wipe it across your brow and get it wet with sweat. Your sweat is the secret ingredient to your family's " +
						"soap formula. A secret and livelihood passed down from generation to generation. There is an old legend that says that the one who bottles and sells " +
						"the family's sweat, instead of making their living off the sweat of their brow, will be cursed. There's no time to think of old wives' tales now " +
						"You are compelled by a force, a force too strong to describe, and you get down on your hands and knees and scrub the floor.\nYES, YES! The rag is working! " +
						"The scum stands no chance against you and your newfound rag! What? No, the rag is starting to wear down. NO! It got caught on something and ripped in twain. " +
						"What devilry is this!? You look and see a key that was lodged in the soap scum. It was loosened when the rag snagged it. You pick it up, it says Proops on it.\n\n" +
						"Press Space to get up, you may have lost the battle, but you will be back to win the war!";
			gotJanitorKey = true;
			cleanedShower = true;
		}

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.shower;}
	}

	void exit () {
		text.text = "The gate swings open easily and you have never seen the world as beautiful as it was at that moment. " +
					"You break down into tears, throw your hands in the air, and bask in the light of freedom! " +
					"You cry and laugh and pee yourself a little bit, you just have too many emotions as you spin around." +
					"Free! Free! I can see my wife and kids again! The joy is overwhelming. You drop to your knees and sob.\n" +
					"CRRRRRRRUNNNNNNNNCHHHHHHH! O god no! What has happened? You can't move, your body won't move." +
					"You look up in agony and realize that a bus has run you over. Looking up at it, the last sight you see is a figure, " +
					"who looks a lot like your blessed Mama giving you the middle finger out of the back window.\n\nThe curse is real. The curse is real."; 

		if (Input.GetKeyDown(KeyCode.Space)) 	{myState = States.stairwell;}
	}

}
