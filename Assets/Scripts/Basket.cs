using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    private static int score = 0;
	// Use this for initialization
	void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
	}

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            score += 1;
            scoreGT.text = "Score: " + score.ToString();

            Destroy(collidedWith);
        }
        if(collidedWith.tag == "GoldApple")
        {
            score += 3;
            scoreGT.text = "Score: " + score.ToString();

            Destroy(collidedWith);
        }
        if(score > HighScore.hiScore)
        {
            HighScore.hiScore = score;
        }
    }
}
