using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{  
    public GameObject toBuild;
    public GameObject toRemove;
    public GameObject UI;

    private bool InRange = false;
    private bool HasBeenBuild = false;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            toBuild.SetActive(true);
            toRemove.SetActive(false);
            HasBeenBuild = true;
        }
        if (!HasBeenBuild && InRange) UI.SetActive(true);
        else UI.SetActive(false);

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
