using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class birdtalkscript : MonoBehaviour {

	public TextMeshPro say;
	public character character;

	private string[] saylist={"Something is out there, other side the pillers, i have heard!, believe me!","What if I tell you that you play very well! believe me.","I wanna taste the burgers of that burger shop in city","Nice score!, if you think you can do better ,just Try again!",
		"Can you take me out of here,other side of pipes, i am getting bored! tap me!","Tell me who built these pillers, i will find him and kill him!","F=ma, e=mc^2, v=u+at ,.. oh you don't need to read this, i am revising physics formulas.",
		"Boy played well.","I think we should become friends, don't you think the same?","So have you any excuse for that crash?...",
		"Do you know birds have largest eyes compared to body size...! ","I love the changing day and night scenes!!, how about you?","Well.. you played well, I like it..","You can change between portrait and landscape mode from menu, even in between game.",
		"Don't you think, I am the smartest and prettiest of all birds... , you should take screenshot of me. ;) ","Can you think why humans made these pillars..","Do you know that you can change the character and background in between the game also!","Having Fun? Invite your friends to have more fun!",
		"Well, I think you are becoming better, believe me..!","Let's fly again but try not to crash ..!","You did well, try again..!","I guess you can do more better.. !","If you like me, you should give a review! Already reviewed? then have a great game!","Bored? Change the background and the bird in main menu to enjoy new experience!",
		"If I crash with pillers , don't cry, I don't die with a normal crash! , Believe me!","I don't wanna say anything, just tap.","You should try again!","Do you want me to say some more new things? You can write that in review section!","havana oo na na ,half of my heart is in havana oo na na....","do you know that you can play both in portrait and landscape mode!","I was thinking .. how many planets are ther in our solar system..?",
		"Can you tell... What is the color of a mirror?..","guess... what is the Resolution of the Human Eye?..","i was thinking what will happen if earth suddenly stops rotating?.. you don't need to think , you play ","do you know the full form of OK .. search for it!"
		};
	private string[] lowscore={"Are you new here ! ","Don't get upset for low score, practice makes a man perfect!","My friend sam can score more than you easily and he is a bird -_-","Don't you think You should play better!","Well do you know my friend sam can score more than 100 easily, and you are here..!","Come on, try again, you can do better..","You should eat burger from that burger shop in city, then you may score better.","I think you need to rest -_-"};
	private string[] highscore={"Oh my God, Highscore!!! Congrates!!! , you should give me party !!","Very Congrates for the Highscore!! It's not that easy ,Believe me!, I will give a gift to you in next update!","We made a highscore!!!, Congrates to both of us!","That's my player , well done, Congrates for the Highscore! ",
		"Well done, you are becoming pro! , Congrates for the Highscore!!!","Oho!! Nice! , You made a Highscore!!! Congo!!!, don't you think you should take a screenshot !","Very well done!!, congrates for the highscore!!","Yeah , I knew you can do it!"};
	private int index;

	void Start()
	{
		character = FindObjectOfType<character> ();
	}
	public void sayit()
	{
		if (character.recentscore >= PlayerPrefs.GetInt ("highscore")  && character.recentscore>=10) 
		{
			
			int index = Random.Range (0, highscore.Length);
			say.text = highscore[index];
		} else if (character.recentscore <= 2) 
		{
			
			int index = Random.Range (0, lowscore.Length);
			say.text = lowscore[index];
		}
		else{
			int index = Random.Range (0, saylist.Length);
		
			say.text = saylist [index];
		}
	}
}
