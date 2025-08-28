using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Components Connected to other gameObjects.
    Text scoreTxt;



    public float speed;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        //init other components
        scoreTxt = GameObject.Find("ScoreLabel").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        Vector3 fStep = dir * speed * Time.deltaTime;
        Vector3 temp = transform.position + fStep;
        if (temp.x >= -7 && temp.x <= 7)
        {
            transform.position = temp;
        }
        

    }

    void OnCollisionEnter(Collision collision)
    {
        score += 1;
        scoreTxt.text = "Score: " + score;
    }
}
