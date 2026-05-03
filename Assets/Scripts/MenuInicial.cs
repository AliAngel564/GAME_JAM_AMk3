using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Instruccione()
    {

    }

    public void salir()
    {
        Debug.Log("Saliste del programa");
        Application.Quit();
    }
}
