using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingScript : MonoBehaviour
{
    public MaterialManager manager;
    public GameObject UI;
    public GameObject toCollect;

    private bool InRange = false;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange) UI.SetActive(true);
        else UI.SetActive(false);
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            gameObject.SetActive(false);
            toCollect.SetActive(false);
            UI.SetActive(false);
            manager.metalCount++;
        }

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
