using System.Collections;
using UnityEngine;
using TMPro;




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
   [SerializeField] private GameObject[] enemigoSprite;
   [SerializeField] private Animator _animator;
   [SerializeField] private SFXManager sfx;

   [Header("Apoyo Visual o nose")] [SerializeField]
   private ParticleSystem particulasDanio;
  
   private SpriteRenderer enemigoRenderer;
   private Color colorInicial;
   private int indiceAleatorio;
   public bool isBoss = false;
  
   private void Awake()
   {
       enemigoRenderer = GetComponentInChildren<SpriteRenderer>();
       particulasDanio = GetComponentInChildren<ParticleSystem>();
       particulasDanio.Stop();
       gm = FindAnyObjectByType<GameManager>();
       jugador = FindAnyObjectByType<Personaje>();
       lienzo = FindAnyObjectByType<CanvasScript>();
   }




   private void Start()
   {
       ElegirSpriteAleatorio();
   }


   public void ElegirSpriteAleatorio()
   {
       if (2 > 0 && isBoss == false)
       {
           indiceAleatorio = Random.Range(0, 2);
           enemigoSprite[indiceAleatorio].SetActive(true);
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
       yield return new WaitForSecondsRealtime(2f);
       gm.AumentarTurno();
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
       _animator.SetBool("estaMuerto",true);
       yield return new WaitForSecondsRealtime(2f);
       enemigoSprite[indiceAleatorio].SetActive(false);
       yield return new WaitForSecondsRealtime(2f);
       gm.VerificaEnemigos(this);
       gm.AumentarTurno();
       Destroy(gameObject); // PLOOOOOOOOOOOOOOOOWJHDVWKJSBBQLEKVBNWLKE
   }


   public void TipoEnemigo(int tipoEnemigo)
   {
    switch (tipoEnemigo)
    {
        case 1:
            vida = 20;
            vidaMaxima = 20;
            danio = 10;
            break;


        case 2:
            vida = 40;
            vidaMaxima = 40;
            danio = 20;
            break;


        case 3:
            isBoss = true;
            enemigoSprite[indiceAleatorio].SetActive(false);
            enemigoSprite[3].SetActive(true);
            vida = 80;
            vidaMaxima = 80;
            danio = 25;
            break;
        
    }
   }




   public void AsignarGameManager(GameManager gameManager)
   {
       gm = gameManager;
   }


   IEnumerator RecibirDañoVisual()
   {
       _animator.SetTrigger("Danio");
       particulasDanio.Play();
       yield return null;
   }


   public IEnumerator DelayAtacar()
   {
       yield return new WaitForSecondsRealtime(5f);
       yield return null;
   }
  
}
