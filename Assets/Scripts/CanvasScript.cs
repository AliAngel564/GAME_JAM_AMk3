using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI vidaDelJugador;
    [SerializeField] private TextMeshProUGUI vidaDelEnemigo1;
    [SerializeField] private TextMeshProUGUI vidaDelEnemigo2;

    [Header("Conexiónes")]
    [SerializeField] private Personaje jugador;
    [SerializeField] private GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        ActualizarUI();
    }*/

    private void Update()
    {
        ActualizarUI();
    }

    public void cambiarVidaJugador()
    {
        vidaDelJugador.text = jugador.vidaJugador.ToString() + "/" + jugador.vidaJugadorMaximo.ToString();
    }

    public void ActualizarUI()
    {
        cambiarVidaJugador();
        mostrarVidaEnemigos();
    }

    private void mostrarVidaEnemigos()
    {
        List<Enemigo> enemigos = gm.ObtenerEnemigosVivos();

        if (enemigos.Count > 0 && enemigos[0] != null)
        {
            vidaDelEnemigo1.text = enemigos[0].ObtenerVida().ToString() + "/" + enemigos[0].vidaMaxima.ToString();
        }
        else
        {
            vidaDelEnemigo1.text = "";
        }

        if (enemigos.Count > 1 && enemigos[1] != null)
        {
            vidaDelEnemigo2.text = enemigos[1].ObtenerVida().ToString() + "/" + enemigos[1].vidaMaxima.ToString();
        }
        else
        {
            vidaDelEnemigo2.text = "";
        }
    }
}
