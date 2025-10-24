using UnityEngine;

public class AtaudTrigger : MonoBehaviour, IInteractuable
{
    [Header("Configuración")]
    [Tooltip("Animator del ataúd")]
    public Animator ataudAnimator;
    
    [Tooltip("Nombre del parámetro trigger en el Animator para abrir")]
    public string nombreTriggerAbrir = "estadoAtaud";
    
    private bool ataudAbierto = false;

    public void Interactuar()
    {
        if (ataudAnimator == null)
        {
            Debug.LogWarning("No hay Animator asignado al ataúd");
            return;
        }

        // Abrir el ataúd
        ataudAbierto = !ataudAbierto;
        ataudAnimator.SetBool(nombreTriggerAbrir, ataudAbierto);
    }
}
