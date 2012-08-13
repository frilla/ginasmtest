using UnityEngine;
using System.Collections;
using SmoothMoves;

public class GinaController : MonoBehaviour {
	
	public BoneAnimation gina;
	
	// Use this for initialization
	void Start () {
		gina = gameObject.GetComponent<BoneAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.RightArrow) )
		{
			Debug.Log("RIGHT ARROW DOWN");
			gina.CrossFade("Gina left punch");
		}
		if( Input.GetKeyUp(KeyCode.RightArrow) )
		{
			gina["Gina idle"].speed = Random.Range(0.2f, 1.8f);
			Debug.Log("RIGHT ARROW UP");
			gina.CrossFade("Gina idle");
		}
	}
}
