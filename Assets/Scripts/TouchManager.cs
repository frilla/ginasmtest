using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
	
	public GameObject mc;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				Vector3 touchPos = touch.position;
				touchPos.z = -Camera.main.transform.localPosition.z;
				Vector3 worldPos = Camera.main.ScreenToWorldPoint (touchPos);
				
				Debug.Log(worldPos.ToString());
				
				float distance = Vector3.Distance (worldPos, mc.transform.position);
				Debug.Log(distance.ToString());
				if( distance < 200.0f )
				{
					Debug.Log("adfadfafds");
				}
			}
		}
	}
}
