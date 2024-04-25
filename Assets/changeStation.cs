using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeStation : MonoBehaviour
{
    public GameObject grafittiwall1;
    public GameObject grafittiwall2;
    public GameObject people1;
    public GameObject people2;
    public GameObject signs1;
    public GameObject signs2;
    public GameObject bebis;
    public int stationInt = 1;
    // Start is called before the first frame update
    void Start()
    {
        stationInt = 1;
        bebis.SetActive(false);
}

    public void changeStations()
    {
        stationInt += 1;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            changeStations();
        }
        if(stationInt == 1)
        {
            grafittiwall2.SetActive(false);
            people2.SetActive(false);
            signs2.SetActive(false);
            grafittiwall1.SetActive(true);
            people1.SetActive(true);
            signs1.SetActive(true);

        }
        else if(stationInt == 2)
        {
            bebis.SetActive(true);
            grafittiwall1.SetActive(false);
            people1.SetActive(false);
            signs1.SetActive(false);
            grafittiwall2.SetActive(true);
            people2.SetActive(true);
            signs2.SetActive(true);
        }
        else
        {
            stationInt = 1;
        }
    }

    
}
