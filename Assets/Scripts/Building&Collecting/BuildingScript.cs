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
            if (!HasBeenBuild) {
                ProgressManager.Instance.UpdateProgressBar();
            }
            HasBeenBuild = true;
            this.gameObject.SetActive(false);
            UIManager.Instance.HideBuildUI();
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

}
