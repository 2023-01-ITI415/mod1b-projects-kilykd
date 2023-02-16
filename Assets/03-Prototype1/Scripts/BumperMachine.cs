using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMachine : MonoBehaviour
{
	[Header("Inscribed")]
	//Prefab for instantiating bumpers
	public GameObject bumperPrefab;
	
	
	//Seconds between bumper instantiations 
	public float bumperLaunchDelay = 1f;
	
	
    
    void Start()
	{
        //Start launching bumpers
		Invoke("LaunchBumper", 2f);
    }
	
	void LaunchBumper()
	{
		GameObject bumper = Instantiate<GameObject>(bumperPrefab);
		bumper.transform.position = transform.position;
		Invoke("LaunchBumper", bumperLaunchDelay);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
