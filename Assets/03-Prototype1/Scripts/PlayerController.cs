using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : MonoBehaviour {
    public Vector3 jump;
	public Vector3 moveBack;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    private Rigidbody rb;
	
    void Start(){
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
// Checks to see if player is grounded
    void OnCollisionStay(){
        if(!isGrounded && rb.velocity.y == 0){
		isGrounded = true;
		}
    }

    void Update()
	{
		//If the player hits spacebar and is on the ground, jump and set isGrounded to false
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
	}
		
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Bumper"))
		{
			transform.position += moveBack;
			Debug.Log("Collision Detected");
		}
			
	}	
   
}

