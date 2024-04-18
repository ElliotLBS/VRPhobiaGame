using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInside : MonoBehaviour
{
    [SerializeField] Traintopoint traintopoint;
    [SerializeField] DoorScript2 doorscript2;
    [SerializeField] public float playerwaiter = 0.0f;
    private float playerwait = 20.0f;

    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Train;

    [SerializeField] Transform Player1;
    [SerializeField] Vector3 Train1;

    public bool inside = false;
    public bool outside = false;
    public bool follow = false;


    

    private void Start()
    {
        Train1 = transform.position;
        traintopoint = FindObjectOfType<Traintopoint>();
        doorscript2 = FindObjectOfType<DoorScript2>();
    }

    private void Update()
    {
       if(inside)
       {
            follow = true;
            if (Player.transform.parent == null)
            {
                //Player1.InverseTransformPoint(Train1.position);
                // Player.transform.SetParent(Train.transform, true);
            }

            playerwaiter += Time.deltaTime;
            if (playerwaiter >= playerwait)
            {
                traintopoint.ready = true;
                playerwaiter = 0.0f;
            }
       }
      if(outside)
      {
            follow = false;
            playerwaiter = 0.0f;
            traintopoint.waiter = 0.0f;

            //Player1.InverseTransformPoint(Train1.position);
            //   Player.transform.SetParent(null, true);
      }

        if (follow == true)
        {
            Vector3 Train2 = transform.position;

            Vector3 offset = Train2 - Train1;
            Player1.position = Player1.position + offset;
            Train1 = transform.position;

            // Vector3 objectALocalPosition = Train1.transform.InverseTransformPoint(Player1.transform.position);
            //Player1.transform.position =  Train1.position +  objectALocalPosition;
            // Player1.transform.position = Vector3.MoveTowards(transform.position, Train1.transform.position, (float).03);

            //Player1.transform.position = Train1.position + Train1.TransformDirection(new Vector3(0, 0, 0));

            //Vector3 offset = Train1.position - Player1.position;
            //Player1.position = Player1.position + offset;
        }
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Test")
        {
            Debug.Log("Inside ;)");
            outside = false;
            inside = true;
            
        }
   

    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Test")
        {
            Debug.Log("Outside :I");
            inside = false;
            outside = true;
        }


    }
}
