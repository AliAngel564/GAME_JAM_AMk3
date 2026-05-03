using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private GameObject Instrucciones;
    
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ActivarInstrucciones()
    {
        Instrucciones.SetActive(true);
    }

    public void salir()
    {
        Debug.Log("Saliste del programa");
        Application.Quit();
    }
}
