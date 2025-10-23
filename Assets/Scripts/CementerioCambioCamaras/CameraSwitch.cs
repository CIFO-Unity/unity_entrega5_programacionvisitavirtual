using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [Header("Cámara a Activar")]
    [Tooltip("La cámara que se activará al hacer clic en el botón")]
    [SerializeField] private Camera targetCamera;

    public void ActivateThisCamera()
    {
        if (targetCamera == null)
        {
            Debug.LogError("No hay cámara asignada en " + gameObject.name);
            return;
        }

        // Desactivar todas las cámaras de la escena
        Camera[] allCameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
        foreach (Camera cam in allCameras)
        {
            cam.enabled = false;
        }
        
        // Activar solo la cámara objetivo
        targetCamera.enabled = true;
        
    }
}
