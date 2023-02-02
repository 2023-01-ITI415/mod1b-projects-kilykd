using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
      [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection;

    // Rate at which Apples will be dropped
    public float secondsBetweenAppleDrop;

    void Start () {
        // Dropping apples every second
    }

    void Update () {
		
        // Basic Movement
		Vector3 pos = transform.position;      
        pos.x += speed * Time.deltaTime;       
        transform.position = pos; 
		
        // Changing Direction
		if ( pos.x < -leftAndRightEdge ) {      
           speed = Mathf.Abs(speed); // Move right
       } else if ( pos.x > leftAndRightEdge ) {
           speed = -Mathf.Abs(speed); // Move left
       }
    }
	
	void FixedUpdate(){
		
		//Changing Direction Randomly is now average 1 time per second (with chanceToChangeDirection = .02)
		if ( Random.value < chanceToChangeDirection){
            speed *= -1; // Change direction
	   }	
	}
}
