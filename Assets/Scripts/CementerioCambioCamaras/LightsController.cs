using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField]
    private GameObject canvas;

    [Header("Luna")]
    [SerializeField]
    private GameObject luna;

    [SerializeField]
    private GameObject sliderIntensidadLuna;


    [Header("Calabazas")]
    private GameObject[] calabazas;

    [SerializeField]
    private GameObject sliderIntensidadCalabazas;


    [Header("Farolas")]
    private GameObject[] farolas;

    [SerializeField]
    private GameObject sliderIntensidadFarolas;

    #region Start & Update

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Luz de la luna

        Light luzLuna = luna.GetComponent<Light>();

        if (luzLuna != null && sliderIntensidadLuna != null)
        {
            // Establecer el valor del slider a la intensidad actual de la luz
            sliderIntensidadLuna.gameObject.GetComponent<Slider>().value = luzLuna.intensity;
        }


        // Luces de las calabazas

        calabazas = GameObject.FindGameObjectsWithTag("Calabaza");

        if (calabazas.Length > 0 && sliderIntensidadCalabazas != null)
        {
            // Suponemos que la luz es el primer hijo de la calabaza
            Light luzPrimeraCalabaza = calabazas[0].transform.GetChild(0).GetComponent<Light>();

            if (luzPrimeraCalabaza != null)
            {
                // Asignar al slider la intensidad actual de la luz
                sliderIntensidadCalabazas.GetComponent<Slider>().value = luzPrimeraCalabaza.intensity;
            }
        }


        // Luces de las farolas

        farolas = GameObject.FindGameObjectsWithTag("Farola");

        if (farolas.Length > 0 && sliderIntensidadFarolas != null)
        {
            // Suponemos que la luz es el primer hijo de la farola
            Light luzPrimeraFarola = farolas[0].transform.GetChild(0).GetComponent<Light>();

            if (luzPrimeraFarola != null)
            {
                // Asignar al slider la intensidad actual de la luz
                sliderIntensidadFarolas.GetComponent<Slider>().value = luzPrimeraFarola.intensity;
            }
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

    #endregion

    #region Luna

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
            else if (color == "Amarillo")
                colorLuna = new Color(235f / 255f, 238f / 255f, 64f / 255f); // Amarillo

            // Cambiar el color del filtro (color de la luz)
            luzLuna.color = colorLuna;
        }
    }

    #endregion

    #region Calabazas

    public void CambiarIntensidadLuzCalabazas()
    {
        if (calabazas != null)
        {
            foreach (GameObject calabaza in calabazas)
            {
                if (calabaza.transform.childCount > 0)
                {
                    // Suponemos que el hijo es la Point Light
                    Transform hijo = calabaza.transform.GetChild(0);
                    Light luz = hijo.GetComponent<Light>();

                    if (luz != null)
                    {
                        // Cambiar intensidad
                        luz.intensity = sliderIntensidadCalabazas.gameObject.GetComponent<Slider>().value;
                    }
                }
            }
        }
    }

    public void CambiarColorLuzCalabazas(string color)
    {
        if (calabazas != null)
        {
            foreach (GameObject calabaza in calabazas)
            {
                if (calabaza.transform.childCount > 0)
                {
                    // Suponemos que el hijo es la Point Light
                    Transform hijo = calabaza.transform.GetChild(0);
                    Light luz = hijo.GetComponent<Light>();

                    if (luz != null)
                    {
                        // Cambiar color

                        Color colorCalabazas = new Color(255f / 255f, 109f / 255f, 0f / 255f); // Naranja por defecto

                        if (color == "Lila")
                            colorCalabazas = new Color(238f / 255f, 64f / 255f, 210f / 255f); // Lila
                        else if (color == "Verde")
                            colorCalabazas = new Color(0.251f, 0.933f, 0.275f); // Verde

                        // Cambiar el color del filtro (color de la luz)
                        luz.color = colorCalabazas;
                    }
                }
            }
        }
    }

    #endregion

    #region Farolas

    public void CambiarIntensidadLuzFarolas()
    {
        if (farolas != null)
        {
            foreach (GameObject farola in farolas)
            {
                if (farola.transform.childCount > 0)
                {
                    // Suponemos que el hijo es la Point Light
                    Transform hijo = farola.transform.GetChild(0);
                    Light luz = hijo.GetComponent<Light>();

                    if (luz != null)
                    {
                        // Cambiar intensidad
                        luz.intensity = sliderIntensidadFarolas.gameObject.GetComponent<Slider>().value;
                    }
                }
            }
        }
    }

    public void CambiarColorLuzFarolas(string color)
    {
        if (farolas != null)
        {
            foreach (GameObject farola in farolas)
            {
                if (farola.transform.childCount > 0)
                {
                    // Suponemos que el hijo es la Point Light
                    Transform hijo = farola.transform.GetChild(0);
                    Light luz = hijo.GetComponent<Light>();

                    if (luz != null)
                    {
                        // Color por defecto (amarillo)
                        Color colorFarolas = new Color(224f / 255f, 210f / 255f, 22f / 255f);

                        if (color == "Lila")
                            colorFarolas = new Color(98f / 255f, 22f / 255f, 224f / 255f); // Lila
                        else if (color == "Rojo")
                            colorFarolas = new Color(224f / 255f, 32f / 255f, 22f / 255f); // Rojo

                        // Cambiar el color de la luz
                        luz.color = colorFarolas;
                    }
                }
            }
        }
    }

    #endregion
}
