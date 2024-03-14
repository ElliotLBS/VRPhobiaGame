using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInside : MonoBehaviour
{
    [SerializeField] Traintopoint traintopoint;
    [SerializeField] DoorScript2 doorscript2;
    [SerializeField] public float playerwaiter = 0.0f;
    private float playerwait = 15.0f;

    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Train;

    private void Start()
    {
        traintopoint = FindObjectOfType<Traintopoint>();
        doorscript2 = FindObjectOfType<DoorScript2>();
    }

    private void Update()
    {
       if(inside)
        {
   
            Player.transform.SetParent( Train.transform,true);
           
            playerwaiter += Time.deltaTime;
            if (playerwaiter >= playerwait)
            {
                traintopoint.ready = true;
            }
        }
  
    }
    public bool inside = false;
    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Test")
        {
            Debug.Log("Inside ;)");
            inside = true;
        }

    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Test")
        {
            Debug.Log("Outside :I");
            inside = false;
        }

    }
}
