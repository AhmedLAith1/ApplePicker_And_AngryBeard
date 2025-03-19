using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
	public Material greenMaterial;
	public Material redMaterial;


	public GameObject applePrefab;

	public float speed = 1f;

	public float leftAndRightEdge = 10f;

	public float chanceToChangeDirections = 0.1f;

	public float secondsBetweenAppleDrops = 1f;
	private bool lastAppleWasGreen = false; // تتبع آخر لون مستخدم


	void Start()
	{
		greenMaterial = Resources.Load<Material>("Mat_Apple_green");
		redMaterial = Resources.Load<Material>("Mat_Apple_red");
		Invoke("DropApple", 2f);
	}

	void DropApple()
	{
		GameObject apple = Instantiate<GameObject>(applePrefab);
		apple.transform.position = transform.position;
		Renderer appleRenderer = apple.GetComponent<Renderer>();
		if (appleRenderer != null)
		{
			if (lastAppleWasGreen)
			{

				appleRenderer.sharedMaterial = greenMaterial;
			}
			else
			{
				appleRenderer.sharedMaterial = redMaterial;
			}
			lastAppleWasGreen = !lastAppleWasGreen;
			// appleRenderer.sharedMaterial = (Random.value > 0.5f) ? greenMaterial : redMaterial;

		}
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
