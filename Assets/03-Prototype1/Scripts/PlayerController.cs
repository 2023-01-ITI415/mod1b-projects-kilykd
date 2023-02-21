using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : MonoBehaviour {
    public Vector3 jump;
	public Vector3 moveBack;
    public float jumpForce = 2.0f;
	public float fallMultiplier = 2.5f;


	Collider bumperCollider;

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
		//If the player hits spacebar and is on the ground 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			//jump and set isGrounded to false
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
		
		//If the player releases space and is not grounded
		if(!isGrounded && transform.position.y > 7)
		{
			//Increase the gravity by fallMultiplier so make the player fall faster
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1);
		}
	}
		
	void OnTriggerEnter(Collider other)
	{
		//if player collides with a bumper
		if(other.gameObject.CompareTag("Bumper"))
		{
			//move the player closer to the edgge
			transform.position += moveBack;
			//get a reference to the bumper that hit the player, set its collider to false
			bumperCollider = other.gameObject.GetComponent<Collider>();
			bumperCollider.enabled = !bumperCollider.enabled;	
			 
		}
			
	}
	
	
}

