using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingScript : MonoBehaviour
{
    public GameObject UI;
    public GameObject toCollect;
    public List<MetalType> metalTypes;

    private bool InRange = false;

    public enum MetalType
    {
        Metal,
        Plastic,
        Rubber
    }
    void Start()
    {
        UI.SetActive(false);
    }

    void Update()
    {
        if (InRange) UI.SetActive(true);
        else UI.SetActive(false);
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            gameObject.SetActive(false);
            toCollect.SetActive(false);
            UI.SetActive(false);
            foreach (var metal in metalTypes)
            {
                UpdateMaterials(metal);
            }
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

    private void UpdateMaterials(MetalType metalType)
    {
        switch (metalType)
        {
            case MetalType.Metal:
                MaterialManager.Instance.metalCount++;
                break;
            case MetalType.Plastic:
                //MaterialManager.Instance.plasticCount++;
                break;
            case MetalType.Rubber:
                MaterialManager.Instance.rubberCount++;
                break;
            default:
                break;
        }
    }
}
