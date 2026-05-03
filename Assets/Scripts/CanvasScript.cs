using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI vidaDelJugador;
    [SerializeField] private TextMeshProUGUI vidaDelEnemigo1;
    [SerializeField] private TextMeshProUGUI vidaDelEnemigo2;
    [SerializeField] private TextMeshProUGUI numRonda;
    [SerializeField] private TextMeshProUGUI contTurnos;

    [Header("Conexiónes")]
    [SerializeField] private Personaje jugador;
    [SerializeField] private GameManager gm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        ActualizarUI();
    }*/

    private void Start()
    {
        
    }

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
        MostrarRonda();
        MostrarTurnos();
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

    private void MostrarRonda()
    {
        numRonda.text = "Ronda: " + gm.Ronda.ToString();
    }

    private void MostrarTurnos()
    {
        contTurnos.text = "Turnos: " + gm.GetTurnos();
    }
}
