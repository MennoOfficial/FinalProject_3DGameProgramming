using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialManager: MonoBehaviour
{
    public int metalCount;
    public TMP_Text metalText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        metalText.text = "Metal = " + metalCount.ToString();
    }
}
