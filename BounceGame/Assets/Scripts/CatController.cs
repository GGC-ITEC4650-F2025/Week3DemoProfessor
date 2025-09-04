using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Animator myAnim;


    Transform ballTran;

    // Start is called before the first frame update
    void Start()
    {
        ballTran = GameObject.Find("Ball").GetComponent<Transform>();

        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = transform.position - ballTran.position;
        if (v.magnitude < 3)
        {
            myAnim.SetBool("JUMP", true);
        }
        else
        {
            myAnim.SetBool("JUMP", false);
        }
    }
}
