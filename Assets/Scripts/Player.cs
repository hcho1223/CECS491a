using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {





	float gravity;// = -20;
	float moveSpeed = 8;
	float jumpVelocity;// = 8;
	float velocityXSmoothing;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded =.1f;
	Vector3 velocity;

	CharacterControl controller;
	//Health 
	//Weapons

	void Start () {
		//add components
		controller = GetComponent<CharacterControl>();
		gravity =-20;
		jumpVelocity = 10;	
	}
	
	// Update is called once per frame
	void Update () {

		if(controller.collisions.above || controller.collisions.below){
			velocity.y =0;
		}

		if(Input.GetKeyDown(KeyCode.Space)&&controller.collisions.below){
			velocity.y = jumpVelocity;
		}

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		float targetVelocityX = input.x*moveSpeed;
		velocity.x= Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, 
			(controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity*Time.deltaTime);
	}
}
