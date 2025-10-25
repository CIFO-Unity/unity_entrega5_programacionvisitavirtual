using UnityEngine;

public class PuertaTrigger : MonoBehaviour, IInteractuable
{
    [Header("Configuración")]
    [Tooltip("Animator de la puerta")]
    public Animator puertaAnimator;
    
    [Tooltip("Nombre del parámetro bool en el Animator (true=abierta, false=cerrada)")]
    public string nombreParametroAnimacion = "estadoPuertas";//variable bool activar animacion
    

    
    private bool puertaAbierta = false;

    // Este método lo llama el player cuando hace clic estando cerca
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
