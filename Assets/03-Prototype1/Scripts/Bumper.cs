using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	//Speed at which bumpers travel
    public float speed = 1f;
	public static float leftMostY = -36f;
	
    // Update is called once per frame
    void Update()
    {
        //Moves bumpers across the screen from righ to left
		Vector3 pos = transform.position;
		pos.x += -1 * speed * Time.deltaTime;
		transform.position = pos;
		
		if (transform.position.x < leftMostY) 
		{
			Destroy(this.gameObject);
		}
		
    }
}
