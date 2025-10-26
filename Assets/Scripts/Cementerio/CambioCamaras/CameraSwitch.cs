using UnityEngine;
using UnityEngine.EventSystems;

public class CameraSwitch : MonoBehaviour
{
    [Header("Cámara a Activar")]
    [Tooltip("La cámara que se activará al hacer clic en el botón")]
    [SerializeField] private Camera targetCamera;

    [Header("Animación al Hacer Clic")]
    [Tooltip("El Animator que se activará con el clic del ratón")]
    [SerializeField] private Animator animatorObjetivo;
    
    [Tooltip("Nombre del parámetro del Animator (ej: 'Abrir', 'estadoPuertas')")]
    [SerializeField] private string nombreParametro = "estadoPuertas";

    private void Update()
    {
        // Verificar si MI cámara está activa Y si hay animador asignado
        // IMPORTANTE: No ejecutar si el clic es sobre UI
        if (targetCamera != null && targetCamera.enabled && 
            animatorObjetivo != null && Input.GetKeyDown(KeyCode.Mouse0) &&
            !EstoyClicandoEnUI())
        {
            EjecutarAnimacion();
        }
    }

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

    private void EjecutarAnimacion()
    {
        if (animatorObjetivo != null)
        {
            // Alternar el estado de la puerta

            animatorObjetivo.SetBool(nombreParametro, !animatorObjetivo.GetBool(nombreParametro));
        }

        

    }

    private bool EstoyClicandoEnUI()
    {
        // Verificar si el EventSystem existe
        if (EventSystem.current == null)
            return false;

        // Crear datos del evento del puntero
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // Hacer raycast para ver qué elementos UI están bajo el puntero
        var resultados = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, resultados);

        // Verificar si hay un Panel (o cualquier elemento con Image/RawImage que bloquee raycast)
        foreach (RaycastResult resultado in resultados)
        {
            // Si tiene un componente Image o RawImage con raycastTarget activado
            var image = resultado.gameObject.GetComponent<UnityEngine.UI.Image>();
            var rawImage = resultado.gameObject.GetComponent<UnityEngine.UI.RawImage>();
            
            if ((image != null && image.raycastTarget) || 
                (rawImage != null && rawImage.raycastTarget))
            {
                return true; // Estamos sobre un panel u otro elemento UI
            }
        }

        return false; // No hay elementos UI bajo el puntero
    }
}
