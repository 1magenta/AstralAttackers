using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager S;

    public AudioSource backgroundMusic;  // play/pause another object
    public AudioClip enemyAdvanceSoundClip; // use playoneshot from sound manager audio source
    public GameObject enemyExplosionSoundPrefab; // spawn this object

    private AudioSource managerAudio; //

    private void Awake()
    {
        S = this; // singleton definition
    }

    private void Start()
    {
        managerAudio = GetComponent<AudioSource>();
    }

    public void StartTheMusic()
    {
        backgroundMusic.Play();
    }

    public void StopTheMusic()
    {
        backgroundMusic.Stop();
    }

    public void MakeTheEnemyAdvanceNoise()
    {
        // make our enemy advance sounds
        managerAudio.PlayOneShot(enemyAdvanceSoundClip);
    }

    public void MakeEnemyExplosionSound()
    {
        GameObject thisExplosion = Instantiate(enemyExplosionSoundPrefab, transform);
        Destroy(thisExplosion, 5.0f);
    }

    public void PlayerExplosionSequence()
    {
        // turn off all currently playing sounds
        AudioSource[] childAudioSources = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource thisChild in childAudioSources)
        {
            thisChild.Stop();
        }

        // play the player explosion sound

    }

}
// 53353 UGE F23 W5