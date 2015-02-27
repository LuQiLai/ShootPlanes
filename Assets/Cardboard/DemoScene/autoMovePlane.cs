using UnityEngine;
using System.Collections;

public class autoMovePlane : MonoBehaviour
{
	private Vector3 startingPosition;
	private int counter;
	private bool ifrotate;

	private int xflag;
	private int yflag;
	private int zflag;

	private float ix;
	private float iy;
	private float iz;
	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{
		startingPosition = transform.localPosition;	
		counter = 0;
		ifrotate = false;
		xflag = yflag = zflag = 0;
		if (Random.value * 10 >= 6)
			xflag = 1;
		if (Random.value * 10 >= 5)
			yflag = 1;
		if (Random.value * 10 >= 4)
			zflag = 1;
		ix = Random.value % 10;
		iy = 0;
		iz = Random.value % 10;
		startingPosition.y = Random.value * 15;
		transform.localPosition = startingPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Relocate if the cube is out of range
		if (counter % 24000 == 0 ||transform.localPosition.x >= 30 || transform.localPosition.y >= 12 || transform.localPosition.z >= 30 || transform.localPosition.y <= 0 || transform.localPosition.x <= -30|| transform.localPosition.z <= -30) {
			Vector3 newdirection = Random.onUnitSphere;
			//newdirection.y = Mathf.Clamp (newdirection.y, 0.5f, 1f);
			float newdistance = 10 * Random.value + 1.5f;
			Vector3 newPlace = newdirection * newdistance;
			newPlace.y = 15 * Random.value;
			transform.localPosition = newPlace;
			ix = Random.value % 10;
			iy = 0;
			iz = Random.value % 10;
			if (Random.value * 10 >= 6)
				xflag = 1;
			else xflag = 0;
			if (Random.value * 10 >= 5)
				yflag = 1;
			else yflag = 0;
			if (Random.value * 10 >= 4)
				zflag = 1;
			else zflag = 0;
		}

		//Auto move the cube
		direction.x = (xflag == 1)?ix:(ix * (-1));
		direction.z = (zflag == 1)?iz:(iz * (-1));
		direction.y = (yflag == 1)?iy:(iy * (-1));
		if (!ifrotate) {
			Vector3 rotatedir;
			rotatedir.x = 0;
			rotatedir.y = - Mathf.Atan(direction.x/direction.z)*180/Mathf.PI;
			rotatedir.z = 0 ;
			transform.Rotate(rotatedir);
			ifrotate = true;
		}
		float distance = 0.05f;
		transform.localPosition += direction * distance;

		//Counter
		counter++;
	}
}
