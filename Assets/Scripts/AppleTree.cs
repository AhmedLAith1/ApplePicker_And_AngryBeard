﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

	public GameObject applePrefab;

	public float speed = 1f;

	public float leftAndRightEdge = 10f;

	public float chanceToChangeDirections = 0.1f;

	public float secondsBetweenAppleDrops = 1f;

	void Start()
	{
		Invoke("DropApple", 2f);
	}

	void DropApple()
	{
		GameObject apple = Instantiate<GameObject>(applePrefab);
		apple.transform.position = transform.position;
		Invoke("DropApple", secondsBetweenAppleDrops);
	}

	void Update()
	{
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;


		if (pos.x < -leftAndRightEdge)
		{
			pos.y -= 2;
			transform.position = pos;


			if (pos.y <= 10)
			{
				pos.y = 10;
				transform.position = pos;
			}
			speed = Mathf.Abs(speed);
		}
		else if (pos.x > leftAndRightEdge)
		{
			pos.y += 2;
			transform.position = pos;
			if (pos.y >= 16)
			{
				pos.y = 14;
				transform.position = pos;
			}
			speed = -Mathf.Abs(speed);
		}


	}
	void FixedUpdate()
	{
		if (Random.value < chanceToChangeDirections)
		{
			speed *= -1;
		}
	}

}
