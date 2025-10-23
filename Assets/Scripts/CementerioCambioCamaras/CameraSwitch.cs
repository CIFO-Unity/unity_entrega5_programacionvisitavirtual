using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    [Header("Cámara a Activar")]
    [Tooltip("La cámara que se activará al hacer clic en el botón")]
    [SerializeField] private Camera targetCamera;

    private Button boton;

    void Awake()
    {
        boton = GetComponent<Button>();
    }

    void Start()
    {
        if (targetCamera != null && targetCamera.enabled)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }

    public void ActivateThisCamera()
    {
        if (targetCamera == null)
        {
            Debug.LogError("No hay cámara asignada en " + gameObject.name);
            return;
        }

        // 🔸 Desactivar todas las cámaras
        Camera[] allCameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
        foreach (Camera cam in allCameras)
        {
            cam.enabled = false;
        }

        // 🔸 Activar solo la cámara objetivo
        targetCamera.enabled = true;

        // 🔸 Marcar este botón como seleccionado → se aplicará el “Selected Color”
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
