﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundItem : MonoBehaviour
{
	public Transform target;
	public float speed;
	
	void Update()
	{
		transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);	
	}
}
