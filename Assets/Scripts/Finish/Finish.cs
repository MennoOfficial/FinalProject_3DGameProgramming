using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update

    private bool InRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) InRange = true;
        UIManager.Instance.ShowInfoButtonUI();
        Debug.Log("InRange");
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
