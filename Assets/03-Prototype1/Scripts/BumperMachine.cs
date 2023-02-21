using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BumperMachine : MonoBehaviour
{
	[Header("Inscribed")]
	//Prefab for instantiating bumpers
	public GameObject singleBumper;
	public GameObject doubleBumper;
	
	//reference to bumper counter class
	public BumperCounter bumperCounter;

	//reference to wintext class
	public WinText youWin;

	//int to count how many bumpers have been launched
	public int bumpersLaunched;
	
	//Seconds between bumper instantiations 
	public float bumperLaunchDelay;
	public float timeBetweenLevels;
	
	//reference to prefab to speed can be changed
	public Bumper myBumper;
	public DoubleBumper myDblBumper;
    
    void Start()
	{
        //set starting values 
		bumpersLaunched = 0;
		myBumper.speed = 10f;
		bumperLaunchDelay = 1f;
		timeBetweenLevels = 7f;

		//Find gameobject named bumpercounter 
		GameObject bumpersleftGO = GameObject.Find("BumperCounter");
		//get the script component of bumpersleftGO
		bumperCounter = bumpersleftGO.GetComponent<BumperCounter>();
		bumperCounter.bumpersLeft = 10;
		
		//start level one
		Invoke("LevelOne", 2f);
		
    }
	
	void LevelOne()
	{	
		//instantiate a singleBumper
		GameObject bumper = Instantiate<GameObject>(singleBumper);
		bumper.transform.position = transform.position;
		bumpersLaunched++;
		bumperCounter.bumpersLeft--;
		
		//if 10 bumpers have been launched
		if(bumpersLaunched == 10)
		{
			myBumper.speed = 12f;
			myDblBumper.speed = 12f;
			bumperLaunchDelay = .8f;
			bumperCounter.bumpersLeft = 20;
			//proceed to level two
			Invoke("LevelTwo", timeBetweenLevels);
		}
		else 
		{
			//instantiate another bumper
			Invoke("LevelOne", bumperLaunchDelay );
		}		
	}
	
	
	void LevelTwo()
	{
		//randomize whether single or double bumpers is instantiated
		if(Random.value > .4 )
		{
			GameObject bumper = Instantiate<GameObject>(singleBumper);
			bumper.transform.position = transform.position;
			bumpersLaunched++;
			bumperCounter.bumpersLeft--;
		}
		else 
		{
			GameObject dblBumper = Instantiate<GameObject>(doubleBumper);
			dblBumper.transform.position = transform.position;
			bumpersLaunched++;
			bumperCounter.bumpersLeft--;
		}

		if(bumpersLaunched == 30)
		{
			
			myBumper.speed = 14f;
			myDblBumper.speed = 14f;
			bumperCounter.bumpersLeft = 55;
			//proceed to level three
			Invoke("LevelThree", timeBetweenLevels);

		}
		else 
		{
			//instantiate another bumper
			Invoke("LevelTwo", bumperLaunchDelay );
		}	


	}
 
	
	void LevelThree()
	{
		if(Random.value >= .5 )
		{
			GameObject bumper = Instantiate<GameObject>(singleBumper);
			bumper.transform.position = transform.position;
			bumpersLaunched++;
			bumperCounter.bumpersLeft--;
		}
		else 
		{
			GameObject dblBumper = Instantiate<GameObject>(doubleBumper);
			dblBumper.transform.position = transform.position;
			bumpersLaunched++;
			bumperCounter.bumpersLeft--;
		}

		if(bumpersLaunched == 85)
		{
			//Congrats you won
			Invoke("gameComplete", 4f);

		}
		else 
		{
			//instantiate another bumper
			if(Random.value > .8)
			{
				bumperLaunchDelay = .4f;
				Invoke("LevelThree", bumperLaunchDelay);	
			}
			else if(Random.value < .6)
			{
				bumperLaunchDelay = .7f;
			 	Invoke("LevelThree", bumperLaunchDelay);
			}
			else 
			{
				bumperLaunchDelay = .6f;
				Invoke("LevelThree", bumperLaunchDelay);
			}
			
		}
	}

	void gameComplete()
	{
		youWin.winText.enabled = true;
		Invoke("returnToMenu", 3f);
	}
	
	void returnToMenu()
	{
		SceneManager.LoadScene("SceneMain");
	}
}
