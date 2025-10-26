using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Script genérico para objetos animables con clic del ratón.
/// Añade este componente al objeto que quieres animar (puerta, ataúd, jaula, etc.)
/// </summary>
public class ObjetoAnimableClick : MonoBehaviour
{
    [Header("Configuración de Animación")]
    [Tooltip("El Animator del objeto (puede ser este mismo objeto o un hijo)")]
    [SerializeField] private Animator animator;
    
    [Tooltip("Parámetro bool que activa animacion (ej: 'estadoAtaud', 'estadoPuertas')")]
    [SerializeField] private string nombreParametro = "";

    private void Start()
    {
        // Si no se asignó animator, intentar obtenerlo del mismo objeto
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnMouseDown()
    {
        if (animator != null)
        {
            // Obtener el estado actual del objeto y alternarlo (toggle) --> solo tenemos bools
            bool estadoActual = animator.GetBool(nombreParametro);
            animator.SetBool(nombreParametro, !estadoActual);
        }
    }

}
