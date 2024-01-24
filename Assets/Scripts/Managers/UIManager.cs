using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject CollectUI;
    public GameObject BuildUI;
    public GameObject DeathUI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DeathUI.SetActive(false);
        CollectUI.SetActive(false);
        BuildUI.SetActive(false);
        Debug.Log("Test UIMAnagerScriptStart");
    }

    // Update is called once per frame
    public void ShowCollectUI()
    {
        CollectUI.SetActive(true);
        Debug.Log("UI-SetActive");
    }
    public void HideCollectUI()
    {
        CollectUI.SetActive(false);
    }

    public void ShowBuildUI()
    {
        BuildUI.SetActive(true);
    }
    public void HideBuildUI()
    {
        BuildUI.SetActive(false);
    }

    public void ShowDeathdUI()
    {
        DeathUI.SetActive(true);
    }
    public void HideDeathUI()
    {
        DeathUI.SetActive(false);
    }

}