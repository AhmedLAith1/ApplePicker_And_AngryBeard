using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
	public Material greenMaterial;
	public Material redMaterial;


	public GameObject applePrefab;
	public GameObject cubePrefab;


	public float speed = 1f;

	public float leftAndRightEdge = 10f;

	public float chanceToChangeDirections = 0.1f;

	public float secondsBetweenAppleDrops = 1f;
	public float secondsBetweenCubeDrops = 1f;
	public float chance = 0.02f;
	private bool lastAppleWasGreen = false;


	void Start()
	{
		greenMaterial = Resources.Load<Material>("Mat_Apple_green");
		redMaterial = Resources.Load<Material>("Mat_Apple_red");
		if (Random.value < chance)
			Invoke("DropApple", 2f);
		else Invoke("DropCube", 2f);

	}
	void DropCube()
	{
		GameObject cube = Instantiate<GameObject>(cubePrefab);
		cube.transform.position = transform.position + Random.Range(2, 6) * Vector3.up;
		if (Random.value < chance)
			Invoke("DropApple", secondsBetweenCubeDrops);
		else Invoke("DropCube", secondsBetweenAppleDrops);
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
		if (Random.value < chance)
			Invoke("DropApple", secondsBetweenCubeDrops);
		else Invoke("DropCube", secondsBetweenAppleDrops);


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
