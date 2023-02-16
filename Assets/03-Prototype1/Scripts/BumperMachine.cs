using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMachine : MonoBehaviour
{
	[Header("Inscribed")]
	//Prefab for instantiating bumpers
	public GameObject bumperPrefab;
	
	private int bumpersLaunched = 0;
	
	//Seconds between bumper instantiations 
	public float bumperLaunchDelay = 1f;
	
	public Bumper myBumper;
    
    void Start()
	{
        //Start launching bumpers
		Invoke("LaunchBumper", 2f);
		
    }
	
	void LaunchBumper()
	{
		GameObject bumper = Instantiate<GameObject>(bumperPrefab);
		bumper.transform.position = transform.position;
		bumpersLaunched++;

		if(bumpersLaunched == 9)
		{
			bumperLaunchDelay -= .5f;
			myBumper.speed *= 1.5f;
		}
		
		Invoke("LaunchBumper", bumperLaunchDelay);
	}


   
}
