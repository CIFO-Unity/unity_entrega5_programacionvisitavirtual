using UnityEngine;

public class PuertaTrigger : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Animator de la puerta")]
    public Animator puertaAnimator;
    
    [Tooltip("Nombre del parámetro bool en el Animator (true=abierta, false=cerrada)")]
    public string nombreParametroAnimacion = "estadoPuertas";
    

    
    private bool puertaAbierta = false;

    // Este método se llama cuando el jugador hace clic estando cerca
    public void Interactuar()
    {
        if (puertaAnimator == null)
        {
            Debug.LogWarning("No hay Animator asignado a la puerta");
            return;
        }

        // Alternar el estado de la puerta
        puertaAbierta = !puertaAbierta;
        puertaAnimator.SetBool(nombreParametroAnimacion, puertaAbierta);
    }
}
