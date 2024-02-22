using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tidtabell : MonoBehaviour
{
    public GameObject skansholm1min;
    public GameObject skansholmnu;
    public float tidtabelltimer;
    LookAtPlayer Lookat;

    // Start is called before the first frame update
    void Start()
    {

        skansholm1min.SetActive(true);
        skansholmnu.SetActive(false);
        tidtabelltimer = 30;
        Lookat = FindObjectOfType<LookAtPlayer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LookAtPlayer.gamestarted == true)
        {
            tidtabelltimer -= 1 * Time.deltaTime;
        }

        if(tidtabelltimer <= 0)
        {
            skansholm1min.SetActive(false);
            skansholmnu.SetActive(true);
        }
    }
}
