using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 60;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            SceneManager.LoadScene("SampleScene");

        }

    }
}
