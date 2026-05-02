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

    private SpriteRenderer enemigoRenderer;

    private void Awake()
    {
        enemigoRenderer = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        ElegirSpriteAleatorio();
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
        vida -= cantidadDanio;

        if (vida <= 0)
        {
            Morir();
        }
    }

    public void Atacar()
    {
        jugador.TomarDanio(danio);
        lienzo.ActualizarUI();
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

    void Morir()
    {
        gm.VerificaEnemigos(this);
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
}
