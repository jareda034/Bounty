using UnityEngine;

public class SecurityCameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject DeskTopUI;
    [SerializeField] GameObject CameraUI;
   [Header("Camera Settings")]
  [SerializeField] Camera[] securtiyCameras;
  [SerializeField] float switchTime = 0.5f;
  int currentCameraIndex = 0;

  public void OpenCamera()
    {
        DeskTopUI.SetActive(false);
        CameraUI.SetActive(true);
        securtiyCameras[currentCameraIndex].gameObject.SetActive(true);
    }

    public void SwitchCamera()
    {
         securtiyCameras[currentCameraIndex].gameObject.SetActive(false);
         currentCameraIndex++;
         if (currentCameraIndex >= securtiyCameras.Length)
        {
            currentCameraIndex = 0;
        }
         securtiyCameras[currentCameraIndex].gameObject.SetActive(true);
    }
}
