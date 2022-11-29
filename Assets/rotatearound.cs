using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatearound : MonoBehaviour
{
	public Transform rune;
	public float speed;
	
	void Update()
	{
		transform.RotateAround(rune.position, Vector3.up, speed * Time.deltaTime);	
	}
}
