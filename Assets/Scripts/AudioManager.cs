using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;
    
    [Header("Card Sounds")]
    public AudioClip cardFlipSound;
    public AudioClip cardDealSound;
    public AudioClip cardShuffleSound;
    public AudioClip cardPlaceSound;
    
    [Header("Game Sounds")]
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip buttonClickSound;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayCardFlip()
    {
        PlaySFX(cardFlipSound);
    }
    
    public void PlayCardDeal()
    {
        PlaySFX(cardDealSound);
    }

    public void PlayWin()
    {
        PlaySFX(winSound);
    }
    
    public void PlayLose()
    {
        PlaySFX(loseSound);
    }
    
    private void PlaySFX(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip == null) return;
        
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(clip, volume);
    }
    
    // Метод с вариациями для разнообразия
    public void PlayCardFlipVaried()
    {
        PlaySFX(cardFlipSound, 1f, Random.Range(0.9f, 1.1f));
    }
}