using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //Components Connected to the same gameObject as this one.
    Rigidbody myBod;
    AudioSource myAudio;

    //Components Connected to other gameObjects.
    Text gameOverTxt;
    PlayerController pc;
    
    public int numJumps;
    public AudioClip bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        //init my components
        myAudio = GetComponent<AudioSource>();
        myBod = GetComponent<Rigidbody>();

        //init other components
        gameOverTxt = GameObject.Find("GameOverMsg").GetComponent<Text>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        float x = Random.Range(-8f, 8f);
        myBod.velocity = new Vector3(x, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 1; //resume game motion
            SceneManager.LoadScene(0);
        }
        else if (numJumps > 0 && Input.GetButtonDown("Jump"))
        {
            Vector3 v = myBod.velocity;
            v.y = 10;
            myBod.velocity = v;
            numJumps--;
        }
    }

    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        //Do Stuff
        myAudio.PlayOneShot(bounceSound);
    }

    //Called when my gameObject overlaps (triggers) with another
    //Requires at least 1 of the gameObjects to have a Rigidbody or CharacterController.
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;
        //Do Stuff
        //if (otherGO.name == "BottomTrigger" && gameObject.name == "Ball")
        if (otherGO.name == "BottomTrigger")
        {
            pc.numBalls--;
            if (pc.numBalls <= 0)
            {
                Time.timeScale = 0; //pauses game
                gameOverTxt.enabled = true;
            }
        }
        else if (otherGO.name == "MagicSquare")
        {
            GameObject g = Instantiate(gameObject);
            g.transform.position = new Vector3(0, 6, 0);
            g.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            g.GetComponent<MeshRenderer>().material.color = Color.green;
            pc.numBalls += 1;
        }
    }



}
