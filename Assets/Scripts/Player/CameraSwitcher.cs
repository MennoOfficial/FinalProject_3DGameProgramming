using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public PlayerMovement playerMovement;

    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        camera1.enabled = !camera1.enabled;
        camera2.enabled = !camera2.enabled;

        // Call SetActiveCamera method in PlayerMovement and pass the currently active camera
        if (playerMovement != null)
        {
            Camera activeCamera = camera1.enabled ? camera1 : camera2;
            playerMovement.SetActiveCamera(activeCamera);
        }
    }
}
