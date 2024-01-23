using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialManager: MonoBehaviour
{
    public static MaterialManager Instance { get; private set; }
    public int metalCount;
    public TMP_Text metalText;

    public int rubberCount;
    public TMP_Text rubberText;

    public int woodCount;
    public TMP_Text woodText;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        metalText.text = metalCount.ToString();
        rubberText.text = rubberCount.ToString();
        woodText.text = woodCount.ToString();
    }
}
