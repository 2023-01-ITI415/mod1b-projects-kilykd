using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMachine : MonoBehaviour
{
	[Header("Inscribed")]
	//Prefab for instantiating bumpers
	public GameObject bumperPrefab;
	//int to count how many bumpers have been launched
	//private int bumpersLaunched = 0;
	
	//Seconds between bumper instantiations 
	public float bumperLaunchDelay;
	
	//reference to prefab to speed can be changed
	public Bumper myBumper;
    
    void Start()
	{
        //Start launching bumpers
		myBumper.speed = 10f;
		bumperLaunchDelay = 1f;
		Invoke("LaunchBumper", 2f);
		
    }
	
	void LaunchBumper()
	{
		GameObject bumper = Instantiate<GameObject>(bumperPrefab);
		bumper.transform.position = transform.position;
		
	/*	bumpersLaunched++;

		if(bumpersLaunched == 9)
		{
			bumperLaunchDelay -= .5f;
			myBumper.speed += 3f;
		}
	*/	
		Invoke("LaunchBumper", bumperLaunchDelay);
	}
	
}
