using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    private int counter = 0;
    public static ProgressManager Instance { get; private set; }
    public Image progressBar;

    Target target;
    private int woodCount = 0;
    private int metalCount = 0;
    private int rubberCount = 0;
    private int stoneCount = 0;

    public GameObject forestLights;
    public GameObject cityLights;
    public GameObject targets;

    public GameObject pointerForest;
    public GameObject pointerIsland;
    public GameObject pointerCity;
    public GameObject pointerDesert;
    public GameObject pointerFinish;



    public TextMeshProUGUI objective;


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


    private void Start()
    {
        target = targets.GetComponent<Target>();

        pointerForest.SetActive(false);
        pointerIsland.SetActive(false);
        pointerCity.SetActive(false);
        pointerDesert.SetActive(false);
        pointerFinish.SetActive(false);

        forestLights.SetActive(false);
        cityLights.SetActive(false);

    }
    void Update()
    {
        UpdateObjectives();
    }

    public void UpdateProgressBar()
    {
        Debug.Log("Update progress");
        counter++;
        Debug.Log(counter); 
        if (counter <= 5)
        {
            float progress = Mathf.Clamp01((float)counter / 5f);
            progressBar.transform.localScale = new Vector3(progress, 1, 1);
        }
    }



    private void UpdateObjectives()
    {
        woodCount = MaterialManager.Instance.woodCount;
        metalCount = MaterialManager.Instance.metalCount;
        rubberCount = MaterialManager.Instance.rubberCount;
        stoneCount = MaterialManager.Instance.stoneCount;
        switch (counter) {
            case 0:
                objective.text = $"Extinguish all fires {target.Score}/10";
                break;
            case 1:
                objective.text = $"Gather materials and build watermill\n" + $"- Wood: {woodCount}/8";
                pointerForest.SetActive(true);
                break;
            case 2:
                objective.text = $"Gather materials and build waterwell\n" + $"- Wood: {woodCount}/4 \n" + $"- Stone: {stoneCount}/8";
                forestLights.SetActive(true);
                pointerIsland.SetActive(true);
                break;
            case 3:
                objective.text = $"Gather materials and build windmill\n" + $"- Wood: {woodCount}/4\n" + $"- Metal: {metalCount}/16\n" + $"- Rubber: {rubberCount}/8";
                pointerCity.SetActive(true);
                break;
            case 4:
                objective.text = $"Gather materials and build solar panel\n" + $"- Metal: {metalCount}/16 \n" + $"- Rubber: {rubberCount}/8 \n" + $"- Stone: {stoneCount}/4";
                cityLights.SetActive(true);
                pointerDesert.SetActive(true);
                break;
            case 5:
                objective.text = "Go to the island to finish the game!";
                pointerFinish.SetActive(true);
                break;
            default:
                counter = 0;
                UIManager.Instance.HideObjectivesUI();
                break;
        }

    }
}
