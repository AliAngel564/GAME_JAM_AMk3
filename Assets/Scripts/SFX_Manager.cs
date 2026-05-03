using System;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip LightSlash;
    [SerializeField] private AudioClip HeavySlash;
    [SerializeField] private AudioClip Healing;
    [SerializeField] private AudioClip Ultimate;
    [SerializeField] private float VolumeScale = 0.5f;
    
    private AudioSource audioSource;

    private void Start() => audioSource = GetComponent<AudioSource>();

    public void PlayLightSlash()
    {
        audioSource.PlayOneShot(LightSlash, VolumeScale);
    }

    public void PlayHeavySlash()
    {
        audioSource.PlayOneShot(HeavySlash, VolumeScale);
    }

    public void PlayHealing()
    {
        audioSource.PlayOneShot(Healing, VolumeScale);

    }

    public void PlayUltimate()
    {
        audioSource.PlayOneShot(Ultimate, VolumeScale);
    }

    


}
