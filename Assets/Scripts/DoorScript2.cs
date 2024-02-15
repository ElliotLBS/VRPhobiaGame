using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript2 : MonoBehaviour
{
    public List<GameObject> doortopoint;
    public List<int> doorIndexs;
    public float speed;
    int index = 0;
    public bool isLoop = true;
    public bool ready;


    private float doorwaitTime = 10.0f;
    [SerializeField]
    private float doorwaiter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Left Controller" || collision.gameObject.name == "Right Controller" || collision.gameObject.name == "Test")
        {
            Debug.Log("HitDoor");
            ready = true;
        }

    }

    private void Update()
    {
        if (ready == true)
        {
            Vector3 destination = doortopoint[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, doortopoint[index].transform.position, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
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
                index++;
                if (index >= doortopoint.Count)
                {
                    index = 0;
                }
                ready = true;
                doorwaiter = 0;
            }
        }

    }

}
