using UnityEngine;
using System.Collections;
using SmoothMoves;

public class GinaController : MonoBehaviour {
	
	public BoneAnimation gina;
	public float velocity;
	
	// Use this for initialization
	void Start () {
		gina = gameObject.GetComponent<BoneAnimation>();
		gina.RegisterUserTriggerDelegate(testUserTrigger);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.RightArrow) )
		{
			Debug.Log("RIGHT ARROW DOWN");
			gina.CrossFade("Gina left punch");
			transform.forward = new Vector3(0f, 0f, 1f);
//			transform.localScale = new Vector3(1f, 1f, 1f);
//			Debug.Log(transform.rotation.ToString());
			rigidbody.velocity = new Vector3(velocity, 0f, 0f);
		}
		if( Input.GetKeyUp(KeyCode.RightArrow) )
		{
			gina["Gina idle"].speed = Random.Range(0.2f, 1.8f);
			Debug.Log("RIGHT ARROW UP");
			gina.CrossFade("Gina idle");
			rigidbody.velocity = new Vector3(0f, 0f, 0f);
		}
		
		if( Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			Debug.Log("LEFT ARROW DOWN");
			gina.CrossFade("Gina left punch");
			transform.forward = new Vector3(0f, 0f, -1f);
//			transform.localScale = new Vector3(-1f, 1f, 1f);
//			Debug.Log(transform.rotation.ToString());
			rigidbody.velocity = new Vector3(-velocity, 0f, 0f);
		}
		if( Input.GetKeyUp(KeyCode.LeftArrow) )
		{
			gina["Gina idle"].speed = Random.Range(0.2f, 1.8f);
			Debug.Log("LEFT ARROW UP");
			gina.CrossFade("Gina idle");
			rigidbody.velocity = new Vector3(0f, 0f, 0f);
		}
		
		
		
	}
	
		void FixedUpdate ()
	{
		//if (touchingPlatform) 
		{
			//rigidbody.AddForce (velocity, 0f, 0f, ForceMode.VelocityChange);
		}
	}
	
	public void testUserTrigger(UserTriggerEvent triggerEvent)
	{
		if( triggerEvent.boneName == "Bras a g")
		{
//			Debug.Log("UserTrigger Triggered");
		}
	}
}
