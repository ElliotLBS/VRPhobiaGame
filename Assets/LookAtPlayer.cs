using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    public static bool gamestarted;
    // Start is called before the first frame update
    void Start()
    {
        gamestarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            gamestarted = true;
        }
        //transform.localPosition = Vector3.zero;
        if(gamestarted)
        {
            transform.LookAt(player.transform);
        }
    }

}
