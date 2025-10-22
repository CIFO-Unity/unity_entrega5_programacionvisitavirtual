using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject luna;

    [SerializeField]
    private GameObject sliderIntensidadLuna;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Light luzLuna = luna.GetComponent<Light>();

        if (luzLuna != null && sliderIntensidadLuna != null)
        {
            // Establecer el valor del slider a la intensidad actual de la luz
            sliderIntensidadLuna.gameObject.GetComponent<Slider>().value = luzLuna.intensity;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeSelf)
                canvas.gameObject.SetActive(false);
            else
                canvas.gameObject.SetActive(true);
        }
    }


    public void CambiarIntensidadLuzLuna()
    {
        Light luzLuna = luna.GetComponent<Light>();

        if (luzLuna != null)
        {
            // Cambiar la intensidad
            luzLuna.intensity = sliderIntensidadLuna.gameObject.GetComponent<Slider>().value;
        }
    }
    

    public void CambiarColorLuzLuna(string color)
    {
        Light luzLuna = luna.GetComponent<Light>();

        if (luzLuna != null)
        {
            Color colorLuna = new Color(64f / 255f, 238f / 255f, 238f / 255f); // Azul por defecto

            if (color == "Rojo")
                colorLuna = new Color(238f / 255f, 64f / 255f, 84f / 255f); // Rojo
            else if(color == "Amarillo")
                colorLuna = new Color(235f / 255f, 238f / 255f, 64f / 255f); // Amarillo

            // Cambiar el color del filtro (color de la luz)
            luzLuna.color = colorLuna;
        }
    }
}
