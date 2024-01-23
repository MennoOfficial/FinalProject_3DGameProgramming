using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{  
    public GameObject toBuild;
    public GameObject toRemove;

    private bool InRange = false;
    private bool HasBeenBuild = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            toBuild.SetActive(true);
            toRemove.SetActive(false);
            HasBeenBuild = true;
        }
        if (!HasBeenBuild && InRange) UIManager.Instance.ShowBuildUI();
        else UIManager.Instance.HideBuildUI();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) InRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) InRange = false;
    }
}
