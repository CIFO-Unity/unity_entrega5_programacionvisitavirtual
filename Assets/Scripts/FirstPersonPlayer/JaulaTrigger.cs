using UnityEngine;

public class JaulaTrigger : MonoBehaviour, IInteractuable
{
    [Header("Configuración")]
    [Tooltip("Animator de la jaula")]
    public Animator jaulaAnimator;
    
    [Tooltip("Nombre del parámetro bool en el Animator (true=abierta, false=cerrada)")]
    public string nombreParametroAnimacion = "Abierta";
    
    [Header("Sistema de llave (opcional)")]
    [Tooltip("¿Requiere llave para abrir?")]
    public bool requiereLlave = false;
    
    [Tooltip("Nombre de la llave requerida")]
    public string nombreLlave = "LlaveJaula";
    
    private bool jaulaAbierta = false;

    public void Interactuar()
    {
        if (jaulaAnimator == null)
        {
            Debug.LogWarning("No hay Animator asignado a la jaula");
            return;
        }

        // Si requiere llave, verificar que el jugador la tenga
        if (requiereLlave && !jaulaAbierta)
        {
            // Aquí verificarías si el jugador tiene la llave
            // Por ahora solo mostramos un mensaje
            Debug.Log($"Necesitas la {nombreLlave} para abrir esta jaula");
            return;
        }

        // Alternar el estado de la jaula
        jaulaAbierta = !jaulaAbierta;
        jaulaAnimator.SetBool(nombreParametroAnimacion, jaulaAbierta);
        
        Debug.Log(jaulaAbierta ? "Jaula abierta" : "Jaula cerrada");
    }
}
