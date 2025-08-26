using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        Vector3 fStep = dir * speed * Time.deltaTime;
        Vector3 temp = transform.position + fStep;
        transform.position = temp;

    }

    void OnCollisionEnter(Collision collision)
    {
        score += 1;
    }
}
