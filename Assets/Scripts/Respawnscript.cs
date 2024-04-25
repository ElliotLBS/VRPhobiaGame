using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnscript : MonoBehaviour
{
    [SerializeField]
    Transform destination;
    [SerializeField] public GameObject Train;
    [SerializeField] Traintopoint traintopoint;
     changeStation changestation;
    void Start()
    {
        traintopoint  = FindObjectOfType<Traintopoint>();
        changestation = FindAnyObjectByType<changeStation>();
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Hit1");
        if (collision.gameObject.tag == "SpawnCube")
        {
            Train.transform.position = destination.position;
            traintopoint.index++;
            changestation.stationInt += 1;
            print("Hit2");

        }
    }
}
