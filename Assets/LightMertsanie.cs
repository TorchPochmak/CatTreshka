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

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(MertsanieCoroutine());
    }

    IEnumerator MertsanieCoroutine()
    {
        yield return new WaitForSeconds(StartDelay);

        while (true)
        {
            yield return new WaitForSeconds(LightOnDelay);
            Light.intensity = 0;
            yield return new WaitForSeconds(LightOffDelay);
            Light.intensity = 1;
        }
    }
}
