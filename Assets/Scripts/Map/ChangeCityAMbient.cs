using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCityAMbient : MonoBehaviour
{
    public GameObject NormalLight;
    public GameObject AreaLight;

    public Material NormalLightBox;
    public Material AreaLightBox;

    public GameObject RainObj;

    public bool Fog;
    public bool Rain;
    public float AmbientIntensity;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NormalLight.SetActive(false);
            AreaLight.SetActive(true);
            RenderSettings.skybox = AreaLightBox;
            RenderSettings.ambientIntensity = AmbientIntensity;
            if (Fog)
            {
                RenderSettings.fog = true;
            }
            if (Rain)
            {
                RainObj.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NormalLight.SetActive(true);
            AreaLight.SetActive(false);
            RenderSettings.ambientIntensity = 1f;
            RenderSettings.skybox = NormalLightBox;
            if (Fog)
            {
                RenderSettings.fog = false;
            }
            if (Rain)
            {
                RainObj.SetActive(false);
            }
        }
    }
}
