using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public bool titila = false;
    public float minDelay = 0.5f;
    public float maxDelay = 2f;

    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        StartCoroutine(LuzQueTitila());
    }

    IEnumerator LuzQueTitila()
    {
        while (true)
        {
            titila = true;
            lightComponent.enabled = false;
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            lightComponent.enabled = true;
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            titila = false;
        }
    }
}
