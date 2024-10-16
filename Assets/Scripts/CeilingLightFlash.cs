using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLightFlash : MonoBehaviour
{
    public bool isFlashing = false;

    public float minInterval = 0.2f;
    public float maxOnInterval = 2f;
    public float maxOffInterval = 2f;
    float nextFlashTime = 0;
    bool isOff = false;

    public Light lightSource;

    private void Start()
    {
        lightSource = GetComponent<Light>();
        lightSource.enabled = true;
        nextFlashTime = Random.Range(minInterval, maxOnInterval);
    }

    private void Update()
    {
        if (!isFlashing) { return; }
        if (Time.time >=nextFlashTime)
            Flash();
    }

    void Flash()
    {
        if (isOff)
        {
            lightSource.enabled = true;
            nextFlashTime = Time.time + Random.Range(minInterval, maxOnInterval);
            isOff = false;
        }
        else
        {
            lightSource.enabled = false;
            nextFlashTime = Time.time + Random.Range(minInterval, maxOffInterval);
            isOff = true;
        }
    }
}
