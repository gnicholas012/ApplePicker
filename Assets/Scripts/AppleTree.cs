using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]

    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRight = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenDrops = 1f;
    public int randomDelay = 0;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftAndRight)
        {
            speed = Mathf.Abs(speed);
        }
        else
        {
            if(pos.x > leftAndRight)
            {
                speed = -Mathf.Abs(speed);
            }
        }
	}
    private void FixedUpdate()
    {
        randomDelay--;
        if (randomDelay <= 0)
        {
            if (Random.value < chanceToChangeDirections)
            {
                speed *= -1;
                randomDelay = 10;
            }
        }
    }
}
