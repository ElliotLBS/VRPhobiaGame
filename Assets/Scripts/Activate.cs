using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField] Traintopoint  traintopoint;
    // Start is called before the first frame update
    void Start()
    {
        traintopoint = FindObjectOfType<Traintopoint>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Test"))
        {
            traintopoint.ready = true;
        }
    }
}
