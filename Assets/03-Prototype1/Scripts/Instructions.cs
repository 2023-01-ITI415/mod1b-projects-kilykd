using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
	//Set how long the instruction text stays on the screen
	public float lifetime = 3.0f;
	
    public void Start() {
		//Remove the instruction text after lifetime
        Destroy(this.gameObject, lifetime);
    }
}
   
	