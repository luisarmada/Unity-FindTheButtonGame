using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerScript : MonoBehaviour
{

    public float minTime = 0.1f;
    public float maxTime = 0.4f;

    private Coroutine flick;

    private bool active = true;

    public bool flickeronStart = false;

    public GameObject lightObj;

    void Start()
    {
        if (flickeronStart) startLightFlicker();
    }

    public void startLightFlicker()
    {
        flick = StartCoroutine(flicker());
    }

    IEnumerator flicker()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        bool newEnabled = !gameObject.GetComponent<Light>().enabled;
        gameObject.GetComponent<Light>().enabled = newEnabled;
        if (lightObj != null)
        {
            Material lightMat = lightObj.GetComponent<Renderer>().material;
            if (newEnabled)
            {
                lightMat.SetColor("_EmissionColor", Color.white);
                lightMat.EnableKeyword("_EMISSION");
            }
            else
            {
                lightMat.SetColor("_EmissionColor", Color.black);
                lightMat.DisableKeyword("_EMISSION");
            }
        }
        if (active)
        {
            StartCoroutine(flicker());
        } else
        {
            gameObject.GetComponent<Light>().enabled = false;
        }
        
    }

    public void stopLight(bool newEnabled)
    {
        StopCoroutine(flick);
        gameObject.GetComponent<Light>().enabled = newEnabled;
        
        active = newEnabled;
    }

}
