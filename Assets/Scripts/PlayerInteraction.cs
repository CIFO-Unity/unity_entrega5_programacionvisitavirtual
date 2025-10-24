using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Configuración Raycast")]
    [Tooltip("Cámara del jugador (First Person Character)")]
    public Camera camaraJugador;
    
    [Tooltip("Distancia máxima de interacción")]
    public float distanciaMaxima = 5.0f;
    
    [Tooltip("Tecla para interactuar")]
    public KeyCode teclaInteraccion = KeyCode.Mouse0; // Clic izquierdo

    private void Start()
    {
        // Si no se asigna cámara, buscar la cámara principal
        if (camaraJugador == null)
        {
            camaraJugador = Camera.main;
        }
    }

    private void Update()
    {
        // Si presionas la tecla de interacción
        if (Input.GetKeyDown(teclaInteraccion))
        {
            IntentarInteractuar();
        }
    }

    private void IntentarInteractuar()
    {
        if (camaraJugador == null)
        {
            Debug.LogWarning("No hay cámara asignada en PlayerInteraction");
            return;
        }

        // Lanzar raycast desde el centro de la cámara
        Ray ray = new Ray(camaraJugador.transform.position, camaraJugador.transform.forward);
        RaycastHit hit;

        // Usar QueryTriggerInteraction.Collide para detectar también triggers
        if (Physics.Raycast(ray, out hit, distanciaMaxima, ~0, QueryTriggerInteraction.Collide))
        {
            // Buscar el componente PuertaTrigger en el objeto o en sus padres
            PuertaTrigger puerta = hit.collider.GetComponentInParent<PuertaTrigger>();
            
            if (puerta != null)
            {
                // Interactuar con la puerta
                puerta.Interactuar();
            }
        }
    }
}
