using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traintopoint : MonoBehaviour
{

    public List<GameObject> traintopoint;
    public List<int> stationIndexs;
    public float speed;
    int index = 0;
    public bool isLoop = true;
    public bool ready;


    private float waitTime = 5.0f;
    [SerializeField]
    private float waiter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (ready == true)
        {
            Vector3 destination = traintopoint[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, traintopoint[index].transform.position, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                if (index < traintopoint.Count - 1)
                {
                    index++;
                }
                else
                {
                    if (isLoop)
                    {
                        index = 0;
                    }

                }

            }
            if (distance <= 5)
            {
                speed -= 0.2f;
            }


        }
        if (stationIndexs.Contains(index))
        {
            ready = false;
            speed = 0;
            waiter += Time.deltaTime;
            if( waiter >= waitTime)
            {
                speed = 20;
                index++;
                if (index >= traintopoint.Count)
                {
                    index = 0;
                }
                ready = true;
                waiter = 0;
            }

        }
    



    }
}
