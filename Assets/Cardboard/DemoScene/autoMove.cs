using UnityEngine;
using System.Collections;

public class autoMove : MonoBehaviour
{
	private Vector3 startingPosition;
	private int counter;

	private int xflag=0;
	private int yflag=0;
	private int zflag=0;

	private float ix;
	private float iy;
	private float iz;
	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{
		startingPosition = transform.localPosition;	
		counter = 0;
		if (Random.value * 10 >= 6)
			xflag = 1;
		if (Random.value * 10 >= 5)
			yflag = 1;
		if (Random.value * 10 >= 4)
			zflag = 1;
		ix = Random.value % 10;
		iy = Random.value % 10;
		iz = Random.value % 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Relocate if the cube is out of range
		if (transform.localPosition.x >= 30 || transform.localPosition.y >= 12 || transform.localPosition.z >= 30 || transform.localPosition.y <= 1 || transform.localPosition.x <= -30|| transform.localPosition.z <= -30) {
			Vector3 newdirection = Random.onUnitSphere;
			//newdirection.y = Mathf.Clamp (newdirection.y, 0.5f, 1f);
			float newdistance = 2 * Random.value + 1.5f;
			transform.localPosition = newdirection * newdistance;
			ix = Random.value % 10;
			iy = Random.value % 10;
			iz = Random.value % 10;
		}

		//Auto move the cube
		direction.x = (xflag == 1)?ix:(ix * (-1));
		direction.z = (zflag == 1)?iz:(iz * (-1));
		direction.y = (yflag == 1)?iy:(iy * (-1));
		float distance = 0.01f;
		transform.localPosition += direction * distance;

		//Counter
		counter++;
	}
}
