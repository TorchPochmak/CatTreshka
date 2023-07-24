using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightMertsanie : MonoBehaviour
{
    [SerializeField] Light2D Light;
    [SerializeField] float StartDelay;
    [SerializeField] float LightOnDelay;
    [SerializeField] float LightOffDelay;

    private float intense;

    // Update is called once per frame
    void Start()
    {
        intense = Light.intensity;
        StartCoroutine(MertsanieCoroutine());
    }

    IEnumerator MertsanieCoroutine()
    {
        yield return new WaitForSecondsRealtime(StartDelay);

        while (true)
        {
            yield return new WaitForSecondsRealtime(LightOnDelay);
            Light.intensity = 0;
            yield return new WaitForSecondsRealtime(LightOffDelay);
            Light.intensity = intense;
        }
    }
}
