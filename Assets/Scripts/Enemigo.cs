using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Estadisticas")]
    [SerializeField] private int vida;
    public int vidaMaxima { get; private set; }
    [SerializeField] private int danio;

    [Header("Conexión")]
    [SerializeField] private GameManager gm;
    [SerializeField] private Personaje jugador;
    [SerializeField] private CanvasScript lienzo;
    [SerializeField] private Sprite[] enemigoSprite;

    [Header("Apoyo Visual o nose")] [SerializeField]
    private ParticleSystem particulasDanio;
    
    private SpriteRenderer enemigoRenderer;
    private Color colorInicial;

    private void Awake()
    {
        enemigoRenderer = GetComponent<SpriteRenderer>();
        particulasDanio = GetComponentInChildren<ParticleSystem>();
        particulasDanio.Stop();
    }


    private void Start()
    {
        ElegirSpriteAleatorio();
        colorInicial = enemigoRenderer.material.color;
    }

    public void ElegirSpriteAleatorio()
    {
        if (enemigoSprite.Length > 0)
        {

            int indiceAleatorio = Random.Range(0, enemigoSprite.Length);
            enemigoRenderer.sprite = enemigoSprite[indiceAleatorio];
        }
    }

    public void RecibirDanio(int cantidadDanio)
    {
        StartCoroutine(RecibirDañoVisual());
        vida -= cantidadDanio;
        
        if (vida <= 0)
        {
            vida = 0;
            StartCoroutine(Morir());
        }
    }

    public IEnumerator Atacar()
    {
        yield return new WaitForSecondsRealtime(2f);
        jugador.TomarDanio(danio);
        lienzo.ActualizarUI();
        yield return null;
    }

    public int ObtenerVida()
    {
        return vida;
    }

    public bool EnemigoSigueVivo()
    {
        if (vida > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Morir()
    {
        yield return new WaitForSecondsRealtime(3f);
        gm.VerificaEnemigos(this);
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject); // PLOOOOOOOOOOOOOOOOWJHDVWKJSBBQLEKVBNWLKE
    }

    public void TipoEnemigo(int tipoEnemigo)
    {
        switch (tipoEnemigo)
        {
            case 1:
                vida = 20;
                vidaMaxima = 20;
                danio = 5;
                break;

            case 2:
                vida = 40;
                vidaMaxima = 40;
                danio = 10;
                break;

            case 3:
                vida = 80;
                vidaMaxima = 80;
                danio = 20;
                break;
        }
    }

    public void AsignarGameManager(GameManager gameManager)
    {
        gm = gameManager;
    }

    IEnumerator RecibirDañoVisual()
    {
        particulasDanio.Play();
        yield return null;
    }

    public IEnumerator DelayAtacar()
    {
        yield return new WaitForSecondsRealtime(5f);
        yield return null;
    }
}
