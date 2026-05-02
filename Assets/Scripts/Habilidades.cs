using System;
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
    public int cooldownBasico = 3;
    public int cooldownPesado = 3;
    public int cooldownUlti = 3;
    public int cooldownCurar = 3;

    private int contadorCooldownBasico = 0;
    private int contadorCooldownPesado = 0;
    private int contadorCooldownUlti = 0;
    private int contadorCooldownCurar = 0;
    
    private float cooldownTime = 0;


    private void Start()
    {
        contadorCooldownBasico = cooldownBasico;
        contadorCooldownPesado = cooldownPesado;
        contadorCooldownUlti = cooldownUlti;
        contadorCooldownCurar = cooldownCurar;
    }

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            AtaqueBasico();
        }

        if (Keyboard.current.wKey.wasPressedThisFrame && Time.time >= cooldownTime)
        {
            AtaquePesado();
            cooldownTime = Time.time + cooldownBasico;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Curar();
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Ulti();
        }
    }

    public void AtaqueBasico()
    {
        Enemigo enemigo = gm.ObtenerEnemigoActual();

        if (enemigo != null && contadorCooldownBasico == cooldownBasico)
        {
            enemigo.RecibirDanio(danioBasico);
            lienzo.ActualizarUI();
            enemigo.Atacar();
            
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
            enemigo.RecibirDanio(danioPesado);
            lienzo.ActualizarUI();
            enemigo.Atacar();
            
            if(contadorCooldownBasico < cooldownBasico)
            {
                contadorCooldownBasico++;
            }
            if (contadorCooldownPesado < cooldownPesado)
            {
                contadorCooldownPesado++;
            }else
            {
                contadorCooldownPesado = 0;
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
        if (jugador != null)
        {
            jugador.CurarJugador(curacion);
            lienzo.ActualizarUI();
            enemigo.Atacar();
            
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
            jugador.CurarJugador(curacionUlti);
            enemigo.RecibirDanio(danioUlti);
            
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
            }else
            {
                contadorCooldownUlti = 0;
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
    
    public int getContadorCooldownBasico() {
        return contadorCooldownBasico;
    }

    public int getContadorCooldownPesado() {
        return contadorCooldownPesado;
    }

    public int getContadorCooldownUlti() {
        return contadorCooldownUlti;
    }

    public int getContadorCooldownCurar() {
        return contadorCooldownCurar;
    }
}