using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript2 : MonoBehaviour
{
    public List<GameObject> doortopoint;
    public List<int> doorIndexs;
    public float speed;
    [SerializeField] public int index = 0;
    public bool isLoop = true;
    public bool ready;

     public enum States { None, Open, Close }
    public States current = States.None;


    private float doorwaitTime = 8.0f;
    private float doorwaiter = 0.0f;
    [SerializeField]
    private float OpenDoor = 0.0f;
    private float Waitfordoor = 15.0f;
    [SerializeField]
    private float CloseDoor = 0.0f;
    private float closewaitdoor = 2.0f;

    [SerializeField] Traintopoint traintopoint;
    // Start is called before the first frame update
    void Start()
    {
        traintopoint = FindObjectOfType<Traintopoint>();

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
        {
            Debug.Log("HitDoor");
            current = States.Open;
        }

    }

    private void Update()
    {
        switch (current)
        {
            case States.None:
                ready = false;
                print("Doing nothing");
                break;

            case States.Open:
                //Open kod här
                OpenDoor += Time.deltaTime;
                if (OpenDoor > Waitfordoor)
                {
                    OpenDoor = 0;
                    current = States.Close;
                }
                ready = true;
             /*
                if (doorIndexs.Contains(index))
                {
                    doorwaiter += Time.deltaTime;
                    if (doorwaiter >= doorwaitTime)
                    {
                       
                    }
                }
             */
                break;

            case States.Close:
                ready = true;
                index++;
                CloseDoor += Time.deltaTime;
                if (CloseDoor >= closewaitdoor)
                {
                    CloseDoor = 0;
                    current = States.None;
                }
                OpenDoor = 0;
                doorwaiter = 0;
                index = 0;

                /*   if(index == 0)
                   {
                       current = States.None;
                   }'/

                   /* if (index >= doortopoint.Count)
                    {
                        index = 0;
                        current = States.None;

                    }*/
                //ready = false;
                break;
            default:
                break;
        }
        if (ready == true)
        {
            Vector3 destination = doortopoint[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, doortopoint[index].transform.position, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                if (index == 0)
                {
                    ready = false;
                }
                if (index < doortopoint.Count - 1)
                {
                    index++;
                }
            }

        }


    }




    /*
        if (traintopoint.ready == false && traintopoint.waiter < traintopoint.waitTime)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }
 */

    
      
       
    
 }


        
