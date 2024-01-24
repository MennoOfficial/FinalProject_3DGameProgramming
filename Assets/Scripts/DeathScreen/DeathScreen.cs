using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cityAmbient;
    ChangeCityAMbient cityAMbient;
    public Transform playerTransform;

    private void Start()
    {
        cityAMbient = cityAmbient.GetComponent<ChangeCityAMbient>();
    }
    public void Respawn()
    {
        PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
        


        if (playerTransform != null)
        {
            playerHealth.ResetHealth();
            MaterialManager.Instance.ResetMaterials();

            CharacterController characterController = playerTransform.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
                playerTransform.position = new Vector3(505f, 301f, 507f);
                characterController.enabled = true;
            }


            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cityAMbient.SetDefaultSettings();
            UIManager.Instance.HideDeathUI();
        }
    }

    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
 
}
