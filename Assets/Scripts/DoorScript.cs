using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public Vector3 endPos;
    public float speed = 1.0f;

    private bool moving = false;
    private  bool opening = false;
    public Vector3 startPos;
    private float delay = 0.0f;

    private void Start()
    {
        startPos = transform.position;

    }
    void OnCollisionEnter(Collision collision)
    {
     
            if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
            {
            Debug.Log("HitDoor");
            moving = true;
            }
        
    }

    public void Update()
    {
       if(moving)
        {
            if(opening)
            {
                MoveDoor(endPos);
            }
            else
            {
                MoveDoor(startPos);
            }
        }
    }

     void MoveDoor(Vector3 goalPos)
    {
        Debug.Log("MovingDoor");
        float dist = Vector3.Distance(transform.position, goalPos);
        if(dist >.1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        else
        {
            if(opening)
            {
                delay += Time.deltaTime;
                if(delay > 1.5f)
                {
                    opening = false;
                }
            }
            else
            {
                moving = false;
                opening = true;
            }
        }
    }
    public bool Moving
    {

        get { return moving; }
        set { moving = value; }
    }

}
