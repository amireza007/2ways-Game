using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject rightLane;
    public GameObject leftLane;
    bool isOnTheRightLane = true;
 
    public float initialspeed = 100;
    public float timer = 0;
    public float speedIncreaseRate = 20;
    public float jumpPower = 5000;
    // Start is called before the first frame update

    void Start()
    {
        //below code could be used for restarting from the start of the road
        Vector3 lo = GameObject.FindWithTag("rightLane").transform.position - (GameObject.FindWithTag("rightLane").transform.localScale / 2);
        Debug.Log(lo);
        //transform.position = lo + new Vector3(transform.localScale.x/1.2f,2f,0);
        transform.position = new Vector3(rightLane.transform.position.x, transform.position.y, transform.position.z);
        rb.AddForce(0, 0, initialspeed);
    }
    // Update is called once per frame
    void Update()
    {
        //RenderSettings.fogDensity = 100f;
        Physics.gravity = new Vector3(0, -20f, 0);      //important part, could be used for rocks as well!!!
        timer += Time.deltaTime;
        if (timer > speedIncreaseRate)
        {
            rb.velocity += new Vector3(0, 0, 1f);
            timer = 0;
        }
        //if (Input.GetKeyDown("right"))
        Debug.Log(transform.position.x);
        Debug.Log(rightLane.transform.position.x);
        if (Input.GetKeyDown("t"))
        {
            if (isOnTheRightLane)
            {
                transform.position = new Vector3(-.7f, transform.position.y, transform.position.z);
                isOnTheRightLane = false;
            }
            else if (!isOnTheRightLane) {
                transform.position = new Vector3(.7f, transform.position.y, transform.position.z);
                isOnTheRightLane = true;

            }
        }
        if (Input.GetKeyDown("space")) 
        {
            rb.AddForce (0, jumpPower, rb.velocity.z/10);
        }
    }
}
