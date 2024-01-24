using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public GameObject toBuild;
    public GameObject toRemove;

    public int woodAmount;
    public int metalAmount;
    public int rubberAmount;
    public int stoneAmount;

    private bool InRange = false;
    private bool HasBeenBuild = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange && CheckMaterials())
        {
            toBuild.SetActive(true);
            toRemove.SetActive(false);
            if (!HasBeenBuild) {
                ProgressManager.Instance.UpdateProgressBar();
            }
            HasBeenBuild = true;
            this.gameObject.SetActive(false);
            UIManager.Instance.HideBuildUI();
            removeMaterials();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) InRange = true;
        UIManager.Instance.ShowBuildUI();
        Debug.Log("InRange");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) InRange = false;
        UIManager.Instance.HideBuildUI();
        Debug.Log("OutOfRange");
    }
    private bool CheckMaterials()
    {
        if (MaterialManager.Instance.woodCount >= woodAmount && MaterialManager.Instance.metalCount >= metalAmount && MaterialManager.Instance.rubberCount >= rubberAmount && MaterialManager.Instance.stoneCount >= stoneAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void removeMaterials()
    {
        MaterialManager.Instance.woodCount -= woodAmount;
        MaterialManager.Instance.metalCount -= metalAmount;
        MaterialManager.Instance.rubberCount -= rubberAmount;
        MaterialManager.Instance.stoneCount -= stoneAmount;
    }
}
