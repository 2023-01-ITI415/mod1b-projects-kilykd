using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMachine : MonoBehaviour
{
	[Header("Inscribed")]
	//Prefab for instantiating bumpers
	public GameObject singleBumper;
	public GameObject doubleBumper;
	public GameObject tripleBumper;
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
		
		//start level one
		Invoke("LevelOne", 2f);
		
    }
	
	void LevelOne()
	{	
		//instantiate a singleBumper
		GameObject bumper = Instantiate<GameObject>(singleBumper);
		bumper.transform.position = transform.position;
		bumpersLaunched++;
		
		//if 10 bumpers have been launched
		if(bumpersLaunched == 10)
		{
			myBumper.speed = 12f;
			myDblBumper.speed = 12f;
			bumperLaunchDelay = .8f;
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
		}
		else 
		{
			GameObject dblBumper = Instantiate<GameObject>(doubleBumper);
			dblBumper.transform.position = transform.position;
			bumpersLaunched++;
		}

		if(bumpersLaunched == 30)
		{
			
			myBumper.speed = 12f;
			myDblBumper.speed = 12f;
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
		}
		else 
		{
			GameObject dblBumper = Instantiate<GameObject>(doubleBumper);
			dblBumper.transform.position = transform.position;
			bumpersLaunched++;
		}

		if(bumpersLaunched == 85)
		{
			//Congrats you won
			Debug.Log("You win!!");

		}
		else 
		{
			//instantiate another bumper
			if(Random.value > .85)
			{
				bumperLaunchDelay = .4f;
				Invoke("LevelThree", bumperLaunchDelay);	
			}
			else if(Random.value < .6)
			{
				bumperLaunchDelay = .8f;
			 	Invoke("LevelThree", bumperLaunchDelay);
			}
			else 
			{
				bumperLaunchDelay = .65f;
				Invoke("LevelThree", bumperLaunchDelay);
			}
			
		}
	}
	
}
