using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            SceneManager.LoadScene("MainMenu");
    }
}
