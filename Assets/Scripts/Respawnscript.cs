using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnscript : MonoBehaviour
{
    [SerializeField]
    Transform destination;
    [SerializeField] public GameObject Train;
    [SerializeField] Traintopoint traintopoint;
    void Start()
    {
        traintopoint  = FindObjectOfType<Traintopoint>();
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Hit1");
        if (collision.gameObject.tag == "SpawnCube")
        {
            Train.transform.position = destination.position;
            traintopoint.index++;

            print("Hit2");

        }
    }
}
