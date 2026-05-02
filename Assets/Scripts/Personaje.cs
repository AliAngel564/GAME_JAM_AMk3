using UnityEngine;

public class Personaje : MonoBehaviour
{
    public int vidaJugador = 80;
    public int vidaJugadorMaximo = 80;

    private void Start()
    {
    }

    public void TomarDanio(int damage)
    {
        vidaJugador -= damage;

        if (vidaJugador < 0)
        {
            vidaJugador = 0;
        }
    }

    public void CurarJugador(int cantCuracion)
    {
        vidaJugador += cantCuracion;

        if (vidaJugador > vidaJugadorMaximo)
        {
            vidaJugador = vidaJugadorMaximo;
        }
    }

}
