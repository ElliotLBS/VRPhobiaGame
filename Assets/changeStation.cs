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
    // Start is called before the first frame update
    void Start()
    {
        grafittiwall2.SetActive(false)    ;
        people2.SetActive(false);
        signs2.SetActive(false);
        grafittiwall1.SetActive(true);
        people1.SetActive(true);
        signs1.SetActive(true);
}

    public void changeStations()
    {
        grafittiwall1.SetActive(false);
        people1.SetActive(false);
        signs1.SetActive(false);
        grafittiwall2.SetActive(true);
        people2.SetActive(true);
        signs2.SetActive(true);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            changeStations();
        }
    }
}
