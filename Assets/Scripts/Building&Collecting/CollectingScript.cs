using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingScript : MonoBehaviour
{
    public GameObject toCollect;
    public List<MetalType> metalTypes;

    private bool InRange = false;

    public enum MetalType
    {
        Metal,
        Plastic,
        Rubber
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            gameObject.SetActive(false);
            toCollect.SetActive(false);
            UIManager.Instance.HideCollectUI();
            foreach (var metal in metalTypes)
            {
                UpdateMaterials(metal);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) UIManager.Instance.ShowCollectUI();
        InRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) UIManager.Instance.HideCollectUI();
        InRange = false;
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
