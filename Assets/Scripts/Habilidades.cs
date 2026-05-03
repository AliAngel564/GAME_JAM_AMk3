using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Habilidades : MonoBehaviour
{
    [Header("Conexiones")]
    [SerializeField] private Personaje jugador;
    [SerializeField] private Enemigo enemigo; 
    [SerializeField] private GameManager gm;
    [SerializeField] private CanvasScript lienzo;

    [Header("Configuracion de daño")]
    public int danioBasico = 10;
    public int danioPesado = 25;
    public int danioUlti = 50;

    [Header("Configuracion de curación")]
    public int curacion = 20;
    public int curacionUlti = 30;

    [Header("Cooldown")]
    public float cooldownBasico = 3;
    public float cooldownPesado = 3;
    public float cooldownUlti = 3;
    public float cooldownCurar = 3;

    private float contadorCooldownBasico = 0;
    private float contadorCooldownPesado = 0;
    private float contadorCooldownUlti = 0;
    private float contadorCooldownCurar = 0;

    private bool ataquePesadoDisponible = true;
    private bool ataqueUltiDisponible = true;
    private bool curarDisponible = true;

    public int turnos = 1;
    
    private void Start()
    {
        contadorCooldownBasico = cooldownBasico;
        contadorCooldownPesado = cooldownPesado;
        contadorCooldownUlti = cooldownUlti;
        contadorCooldownCurar = cooldownCurar;
    }

    public void AtaqueBasico()
    {
        Enemigo enemigo = gm.ObtenerEnemigoActual();

        if (enemigo != null && contadorCooldownBasico == cooldownBasico)
        {
           
            enemigo.RecibirDanio(danioBasico);
            lienzo.ActualizarUI();
            if (enemigo.ObtenerVida() > 0)
            {
                StartCoroutine(enemigo.Atacar());
            }
            
            if(contadorCooldownBasico < cooldownBasico)
            {
                contadorCooldownBasico++;
            }
            else
            {
                contadorCooldownBasico = 0;
            }

            if (contadorCooldownPesado < cooldownPesado)
            {
                contadorCooldownPesado++;
            }

            if (contadorCooldownUlti < cooldownUlti)
            {
                contadorCooldownUlti++;
            }

            if (contadorCooldownCurar < cooldownCurar)
            {
                contadorCooldownCurar++;
            }
        }
        else
        {
            Debug.Log("Ataque básico está en Cooldown");
        }
    }

    public void AtaquePesado()
    {
        Enemigo enemigo = gm.ObtenerEnemigoActual();

        if (enemigo != null && contadorCooldownPesado == cooldownPesado)
        {
            
            ataquePesadoDisponible = true;
            enemigo.RecibirDanio(danioPesado);
            lienzo.ActualizarUI();
            if (enemigo.ObtenerVida() > 0)
            {
                StartCoroutine(enemigo.Atacar());
            }
            if(contadorCooldownBasico < cooldownBasico)
            {
                contadorCooldownBasico++;
            }
            if (contadorCooldownPesado < cooldownPesado)
            {
                contadorCooldownPesado++;
            }
            if(ataquePesadoDisponible)
            {
                contadorCooldownPesado = 0;
                ataquePesadoDisponible = false;
            }
            if (contadorCooldownUlti < cooldownUlti)
            {
                contadorCooldownUlti++;
            }

            if (contadorCooldownCurar < cooldownCurar)
            {
                contadorCooldownCurar++;
            }
        }
        else
        {
            Debug.Log("Ataque pesado está en Cooldown");
        }
        
    }

    public void Curar()
    {
        if (jugador && contadorCooldownCurar == cooldownCurar)
        {
            curarDisponible = true;
            jugador.CurarJugador(curacion);
            lienzo.ActualizarUI();
            if (enemigo.ObtenerVida() > 0)
            {
                StartCoroutine(enemigo.Atacar());
            }
            
            if(contadorCooldownBasico < cooldownBasico)
            {
                contadorCooldownBasico++;
            }
            if (contadorCooldownPesado < cooldownPesado)
            {
                contadorCooldownPesado++;
            }
            if (contadorCooldownUlti < cooldownUlti)
            {
                contadorCooldownUlti++;
            }

            if (contadorCooldownCurar < cooldownCurar)
            {
                contadorCooldownCurar++;
            }else
            {
                contadorCooldownCurar = 0;
                curarDisponible = false;
            }
        }
        else
        {
            Debug.Log("Curación está en cooldown");
        }
    }

    public void Ulti()
    {
        Enemigo enemigo = gm.ObtenerEnemigoActual();

        if (jugador&& enemigo && contadorCooldownUlti == cooldownUlti)
        {
            ataqueUltiDisponible = true;
            jugador.CurarJugador(curacionUlti);
            enemigo.RecibirDanio(danioUlti);
            lienzo.ActualizarUI();
            if (enemigo.ObtenerVida() > 0)
            {
                StartCoroutine(enemigo.Atacar());
            }
            if(contadorCooldownBasico < cooldownBasico)
            {
                contadorCooldownBasico++;
            }
            if (contadorCooldownPesado < cooldownPesado)
            {
                contadorCooldownPesado++;
            }
            if (contadorCooldownUlti < cooldownUlti)
            {
                contadorCooldownUlti++;
            }
            else
            {
                contadorCooldownUlti = 0;
                ataqueUltiDisponible = false;
            }
            if (contadorCooldownCurar < cooldownCurar)
            {
                contadorCooldownCurar++;
            }
        }

        /*if (enemigo != null)
        {
            enemigo.RecibirDanio(danioUlti);
        }
        lienzo.ActualizarUI();
        enemigo.Atacar();
        */
    }
    
    public float getContadorCooldownBasico() {
        return contadorCooldownBasico;
    }

    public float getContadorCooldownPesado() {
        return contadorCooldownPesado;
    }

    public float getContadorCooldownUlti() {
        return contadorCooldownUlti;
    }

    public float getContadorCooldownCurar() {
        return contadorCooldownCurar;
    }
    
    public float getCooldownBasico() {
        return cooldownBasico;
    }

    public float getCooldownPesado() {
        return cooldownPesado;
    }

    public float getCooldownUlti() {
        return cooldownUlti;
    }

    public float getCooldownCurar() {
        return cooldownCurar;
    }
    
    public bool getAtaquePesadoDisponible() {
        return ataquePesadoDisponible;
    }

    public bool getAtaqueUltiDisponible() {
        return ataqueUltiDisponible;
    }

    public bool getCurarDisponible() {
        return curarDisponible;
    }
}