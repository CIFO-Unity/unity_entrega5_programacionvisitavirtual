using UnityEngine;

public class JaulaTrigger : MonoBehaviour, IInteractuable
{
    [Header("Configuración")]
    [Tooltip("Animator de la jaula")]
    public Animator jaulaAnimator;
    
    [Tooltip("Nombre del parámetro bool en el Animator (true=abierta, false=cerrada)")]
    public string nombreParametroAnimacion = "Abierta";
    
    private bool jaulaAbierta = false;

    public void Interactuar()
    {
        if (jaulaAnimator == null)
        {
            Debug.LogWarning("No hay Animator asignado a la jaula");
            return;
        }


        // Alternar el estado de la jaula
        jaulaAbierta = !jaulaAbierta;
        jaulaAnimator.SetBool(nombreParametroAnimacion, jaulaAbierta);
        
        Debug.Log(jaulaAbierta ? "Jaula abierta" : "Jaula cerrada");
    }
}
