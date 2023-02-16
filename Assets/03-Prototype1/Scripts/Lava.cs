using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
	{
		//if lava collides with player
		if(other.gameObject.CompareTag("Player"))
		{
			//Restart the game
			SceneManager.LoadScene( "Main-Prototype 1");		
		}
			
	}
}
