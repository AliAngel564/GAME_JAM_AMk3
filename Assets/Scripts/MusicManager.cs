using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    [Header("Music")]
    [SerializeField] private AudioClip MusicDefault;
    [SerializeField] private AudioClip MusicBossfight;
    [SerializeField] private AudioClip MusicCredits;

    [SerializeField] private float VolumeScale = 0.5f;

    [SerializeField]private AudioSource audioSource;
    
    private void Start() => audioSource = GetComponent<AudioSource>();

    public void PlayMusicBossfight()
    {
        audioSource.clip = MusicBossfight;
        audioSource.Play();
    }


    public void PlayMusicDefault()
    {
        audioSource.clip = MusicDefault;
        audioSource.Play();
    }
    
    public void PlayMusicCredits()
    {
        audioSource.clip = MusicCredits;
        audioSource.Play();
    }
}
