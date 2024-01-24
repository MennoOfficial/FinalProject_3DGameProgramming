using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject CollectUI;
    public GameObject buildUI;
    public GameObject InfoButtonUI;
    public GameObject InfoUI;
    public GameObject VictoryUI;
    public GameObject DeathUI;
    public TextMeshPro Info;
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
        buildUI.SetActive(false);
        VictoryUI.SetActive(false);
        InfoButtonUI.SetActive(false);
        InfoUI.SetActive(false);
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
        buildUI.SetActive(true);
    }
    public void HideBuildUI()
    {
        buildUI.SetActive(false);
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