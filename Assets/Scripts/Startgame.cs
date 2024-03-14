using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Startgame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject XRRIG;
    bool onStair1 = false;
    bool onStair2 = false;
    public Transform startpoint;
    public Transform endPoint1;
    public Transform endPoint2;
    public float stairRatio1 = 0;
    public float stairRatio2 = 0;
    public TMP_Text STARTGAMETEXT;

    ContinuousMoveProviderBase moveProvider;
    void Start()
    {
        moveProvider = FindObjectOfType<ContinuousMoveProviderBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            startgamenow();
        }
        if (onStair1)
        {
            XRRIG.transform.position = Vector3.Lerp(startpoint.position, endPoint1.position, stairRatio1) ;
            stairRatio1 += 0.3f * Time.deltaTime;
            if (stairRatio1 > 1)
            {

                onStair1 = false;
                onStair2 = true;

            }
        }
        if(onStair2)
        {
            XRRIG.transform.position = Vector3.Lerp(endPoint1.position, endPoint2.position, stairRatio2);
            stairRatio2 += 0.3f * Time.deltaTime;
            if (stairRatio2 > 1)
            {
                onStair2 = false;
                moveProvider.moveSpeed = 10;
            }
        }
    }
    void startgamenow()
    {
        XRRIG.transform.position = new Vector3(2, 0, 45);
        onStair1 = true;
        STARTGAMETEXT.enabled = false;
        moveProvider.moveSpeed = 0;
    }
}

