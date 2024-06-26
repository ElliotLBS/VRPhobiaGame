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
    public AudioSource CROWD1;
    public bool CROWDREALIZE;
    public AudioSource FFFF;
    public bool startedgame;


    XRIDefaultInputActions inputs;

    private void OnEnable()
    {
        inputs = new XRIDefaultInputActions();
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    ContinuousMoveProviderBase moveProvider;
    void Start()
    {
        moveProvider = FindObjectOfType<ContinuousMoveProviderBase>();
        moveProvider.moveSpeed = 0;

    }

    public static IEnumerator FadeOut(AudioSource CROWD1_SOUND, float FadeTime = 0.2f)
    {
        float startVolume = CROWD1_SOUND.volume;

        while (CROWD1_SOUND.volume > 0)
        {
            CROWD1_SOUND.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        CROWD1_SOUND.Stop();
        CROWD1_SOUND.volume = startVolume;
    }


    // Update is called once per frame
    void Update()
    {
        if (inputs.XRIRightHandInteraction.Activate.WasPerformedThisFrame())
        {
            startgamenow();
        }

        if (CROWDREALIZE == true)
        {
            print("�nej");  
            StartCoroutine(FadeOut(CROWD1, 1f));
            FFFF.Play();

        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            startgamenow();
        }
        if (onStair1)
        {
            XRRIG.transform.position = Vector3.Lerp(startpoint.position, endPoint1.position, stairRatio1) ;
            stairRatio1 += 0.2f * Time.deltaTime;
            if (stairRatio1 > 1)
            {

                onStair1 = false;
                onStair2 = true;

            }
        }
        if(onStair2)
        {
            XRRIG.transform.position = Vector3.Lerp(endPoint1.position, endPoint2.position, stairRatio2);
            stairRatio2 += 0.2f * Time.deltaTime;
            if (stairRatio2 > 1)
            {
                CROWDREALIZE = true;
                moveProvider.moveSpeed = 5;
                onStair2 = false;
                startedgame = true;
            }
        }
    }

    public void startgamenow()
    {
        if(!startedgame)
        {
            XRRIG.transform.position = new Vector3(2, 0, 45);
            onStair1 = true;
            STARTGAMETEXT.enabled = false;
            moveProvider.moveSpeed = 0;

        }
    }
}

