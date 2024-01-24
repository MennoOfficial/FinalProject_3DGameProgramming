using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    private static int counter = 0;
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
    public GameObject pointer1;
    public GameObject pointer2;
    public GameObject pointer3;
    public GameObject pointer4;
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

        pointer1.SetActive(false);
        pointer2.SetActive(false);
        pointer3.SetActive(false);
        pointer4.SetActive(false);
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
                objective.text = $"Extinguish all fires {target.GetScore}/10";
                break;
            case 1:
                objective.text = $"Gather materials and build watermill\n" + $"- Wood: {woodCount}/8";
                pointer1.SetActive(true);
                break;
            case 2:
                objective.text = $"Gather materials and build waterwell\n" + $"- Wood: {woodCount}/2 \n" + $"- Stone: {stoneCount}/4";
                forestLights.SetActive(true);
                pointer2.SetActive(true);
                break;
            case 3:
                objective.text = $"Gather materials and build windmill\n" + $"- Wood: {woodCount}/2\n" + $"- Metal: {metalCount}/8\n" + $"- Rubber: {rubberCount}/4";
                pointer3.SetActive(true);
                break;
            case 4:
                objective.text = $"Gather materials and build solar panel\n" + $"- Metal: {metalCount}/8 \n" + $"- Rubber: {rubberCount}4 \n" + $"- Stone: {stoneCount}/2";
                cityLights.SetActive(true);
                pointer4.SetActive(true);
                break;
            default:
                UIManager.Instance.HideObjectivesUI();
                break;
        }

    }
}
