using System;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Conexion")] [SerializeField] private GameObject Enemigo;
    [SerializeField] private CanvasScript lienzo;
    [SerializeField] private Habilidades habilidades;

    [Header("Pantallas UI")] [SerializeField]
    private GameObject pantallaVictoria;

    [SerializeField] private GameObject pantallaDerrota;

    private int EnemigosEnTablero = 0;
    public int Ronda = 0;
    private int EnemigosDerrotados = 0;

    private Enemigo enemigoActual;
    private List<Enemigo> enemigosVivos = new List<Enemigo>();

    private void Start()
    {
        Rondas();

    }

    private void Update()
    {
        Debug.Log("Cooldown Básico: " + habilidades.getContadorCooldownBasico());
        Debug.Log("Cooldown Pesado: " + habilidades.getContadorCooldownPesado());
        Debug.Log("Cooldown Curación: " + habilidades.getContadorCooldownPesado());
        Debug.Log("Cooldown Ulti: " + habilidades.getContadorCooldownUlti());

    }

    private void
        GenerarEnemigo(int param_tipoEnemigo,
            float param_posicionEnemigo) //Enemigo de tipo 1 es normal, Enemigo de tipo 2 es especial y Enemigo de tipo 3 es el jefe
    {
        GameObject EnemigoGenerado = Instantiate(Enemigo);
        EnemigoGenerado.transform.position = transform.position + new Vector3(param_posicionEnemigo, -1.8f, 0);
        Enemigo enemigoScript = EnemigoGenerado.GetComponent<Enemigo>();
        enemigoScript.TipoEnemigo(param_tipoEnemigo);
        enemigoScript.AsignarGameManager(this);

        enemigosVivos.Add(enemigoScript);

        enemigoActual = enemigoScript;
    }

    private void Rondas()
    {
        Ronda += 1;
        enemigosVivos.Clear();
        enemigoActual = null;


        switch (Ronda)
        {
            case 1:
                GenerarEnemigo(1, 7f);
                EnemigosEnTablero = 1;
                lienzo.ActualizarUI();
                break;
            case 2:
                GenerarEnemigo(1, 7f);
                GenerarEnemigo(1, 4f);
                EnemigosEnTablero = 2;
                break;
            case 3:
                GenerarEnemigo(2, 7f);
                EnemigosEnTablero = 1;
                break;
            case 4:
                GenerarEnemigo(2, 7f);
                GenerarEnemigo(1, 4f);
                EnemigosEnTablero = 2;
                break;
            case 5:
                GenerarEnemigo(3, 7f);
                EnemigosEnTablero = 1;
                break;
            case 6:
                Victoria();
                break;

        }
    }


    public void VerificaEnemigos(Enemigo param_EnemigoDerrotado)
    {
        EnemigosDerrotados += 1;

        enemigosVivos.Remove(param_EnemigoDerrotado);

        if (enemigosVivos.Count > 0)
        {
            enemigoActual = enemigosVivos[0];
        }
        else
        {
            enemigoActual = null;
        }

        if (EnemigosEnTablero == EnemigosDerrotados) //si todos los enemigos son derrotados entonces pasa de ronda
        {
            EnemigosDerrotados = 0;
            StartCoroutine(CooldownNuevaRonda());
            Rondas();
        }
    }

    public Enemigo ObtenerEnemigoActual()
    {
        return enemigoActual;
    }

    public List<Enemigo> ObtenerEnemigosVivos()
    {
        return enemigosVivos;
    }


    IEnumerator CooldownNuevaRonda()
    {
        yield return new WaitForSecondsRealtime(5f);
        yield return null;
    }

    public void Victoria()
    {
        if (pantallaVictoria != null)
        {
            pantallaVictoria.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Victoria !!");
        }
    }

    public void Derrota()
    {
        if (pantallaDerrota != null)
        {
            pantallaDerrota.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Derrota!!");
        }

    }
}
