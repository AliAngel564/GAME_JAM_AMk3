using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public int vidaJugador = 80;
    public int vidaJugadorMaximo = 80;

    [SerializeField] private ParticleSystem particulasDanio;
    [SerializeField] private GameManager gm;
    [SerializeField] private Animator _animator;
    [SerializeField] private SFXManager sfx;

    private void Awake()
    {
        particulasDanio = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        
    }

    public void TomarDanio(int damage)
    {
        StartCoroutine(RecibirDañoVisual());
        vidaJugador -= damage;

        if (vidaJugador <= 0)
        {
            vidaJugador = 0;
            gm.Derrota();
            Debug.Log("Derrota");

        }
    }

    public void CurarJugador(int cantCuracion)
    {
        sfx.PlayHealing();
        vidaJugador += cantCuracion;

        if (vidaJugador > vidaJugadorMaximo)
        {
            vidaJugador = vidaJugadorMaximo;
        }
    }
    IEnumerator RecibirDañoVisual()
    {
        
        _animator.SetTrigger("Danio");
        particulasDanio.Play();
        yield return null;
    }
    
}
