using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	//Speed at which bumpers travel
    public float speed = 1f;
	
    // Update is called once per frame
    void Update()
    {
        //Basic Movement
		Vector3 pos = transform.position;
		pos.x += -1 * speed * Time.deltaTime;
		transform.position = pos;
		
    }
}
