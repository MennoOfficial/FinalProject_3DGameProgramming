using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    Target target;
    public GameObject targets;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Test Pause");
            UIManager.Instance.ShowPauseUI();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void Continue()
    {
        UIManager.Instance.HidePauseUI();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    private void Start()
    {
        target = targets.GetComponent<Target>();
    }



    public void Return()
    {
        target.Score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
