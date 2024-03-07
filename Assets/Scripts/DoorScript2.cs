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


    private float doorwaitTime = 8.0f;
    [SerializeField]
    private float doorwaiter = 0.0f;
    private bool closeddoor;
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
            ready = true;
            index++;
        }

    }

    private void Update()
    {

        if (traintopoint.ready == false && traintopoint.waiter < traintopoint.waitTime)
       {
            ready = true;
        }
        else
        {
            ready = false;
         
        }
        if (index == 0 && closeddoor == true)
        {
            ready = false;
        }
       if(index == 0)
       {
            closeddoor = true;
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
        if (doorIndexs.Contains(index))
        {
            doorwaiter += Time.deltaTime;
            if (doorwaiter >= doorwaitTime)
            {
                ready = false;
                index++;
                if (index >= doortopoint.Count)
                {
                    index = 0;


                }
                //ready = false;
                doorwaiter = 0;
            }
        }
    
    }

}
