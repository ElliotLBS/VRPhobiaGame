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


    public float waitTime = 10.0f;
    [SerializeField]
    public  float waiter = 0.0f;
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
            
            if (distance <= 20)
            {
                speed -= 0.1f;
                if (speed <= 0)
                {
                    speed = 0;
                }
            }
            if (distance >= 0)
            {
                speed += 0.1f;
                if (speed >= 20)
                {
                    speed = 20;
                }
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
