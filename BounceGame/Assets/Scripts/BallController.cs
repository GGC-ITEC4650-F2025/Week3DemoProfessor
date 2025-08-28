using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Components Connected to the same gameObject as this one.
    Rigidbody myBod;
    AudioSource myAudio;

    public int numJumps;
    public AudioClip bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        //init my components
        myAudio = GetComponent<AudioSource>();
        myBod = GetComponent<Rigidbody>();

        myBod.velocity = new Vector3(2, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (numJumps > 0 && Input.GetButtonDown("Jump"))
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
}
