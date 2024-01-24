using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject CollectUI;
    public GameObject BuildUI;
    public GameObject InfoButtonUI;
    public GameObject InfoUI;
    public GameObject VictoryUI;
    public GameObject DeathUI;
    public TextMeshProUGUI Info;

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
        InfoButtonUI.SetActive(false);
        InfoUI.SetActive(false);
        DeathUI.SetActive(false);
        CollectUI.SetActive(false);
        BuildUI.SetActive(false);
        VictoryUI.SetActive(false);
    }
    public void ShowCollectUI()
    {
        CollectUI.SetActive(true);
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

    public void ShowInfoButtonUI()
    {
        InfoButtonUI.SetActive(true);
    }
    public void HideInfoButtonUI()
    {
        InfoButtonUI.SetActive(false);
    }

    public void ShowInfoUI()
    {
        InfoUI.SetActive(true);
    }
    public void HideInfoUI()
    {
        InfoUI.SetActive(false);
    }

    public void ShowVictoryUI()
    {
        VictoryUI.SetActive(true);
    }
    public void HideVictoryUI()
    {
        VictoryUI.SetActive(false);
    }

    public void ShowDeathdUI()
    {
        DeathUI.SetActive(true);
    }
    public void HideDeathUI()
    {
        DeathUI.SetActive(false);
    }


    public void UpdateText(string infoText)
    {
        Info.text = infoText;
    }
}