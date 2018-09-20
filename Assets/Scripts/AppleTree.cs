using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]

    public GameObject redApplePrefab;
    public GameObject goldApplePrefab;
    public float speed = 1f;
    public float leftAndRight = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenDrops = 1f;
    private int randomDelay = 0;
    private int appleCounter = 0;

	// Use this for initialization
	void Start()
    {
        Invoke("DropApple", 2f);
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
            randomDelay = 10;
        }
        else
        {
            if(pos.x > leftAndRight)
            {
                speed = -Mathf.Abs(speed);
                randomDelay = 10;
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
    void DropApple()
    {
        if (appleCounter < 9)
        {
            GameObject redApple = Instantiate<GameObject>(redApplePrefab);
            redApple.transform.position = transform.position;
            appleCounter++;
        }
        else
        {
            GameObject goldApple = Instantiate<GameObject>(goldApplePrefab);
            goldApple.transform.position = transform.position;

            if (Mathf.Abs(speed) < 20)
            {
                //when speed reaches 20, only golden apples spawn
                appleCounter = 0;
                if (speed >= 0)
                {
                    speed++;
                }
                else
                {
                    speed--;
                }
            }
        }
        Invoke("DropApple", secondsBetweenDrops);
    }
}
