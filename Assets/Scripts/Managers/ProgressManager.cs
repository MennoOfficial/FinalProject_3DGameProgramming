using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    private static int counter = 0;
    public static ProgressManager Instance { get; private set; }
    public Image progressBar;


    private void Awake()
    {
        Debug.Log("Awake called in ProgressManager");
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateProgressBar()
    {
        Debug.Log("Update progress");
        counter++;
        Debug.Log(counter); 
        if (counter < 5)
        {
            float progress = Mathf.Clamp01((float)counter / 5f);
            progressBar.transform.localScale = new Vector3(progress, 1, 1);
        }
        else
        {
            progressBar.transform.localScale = new Vector3(0, 1, 1);
        }
    }
}
