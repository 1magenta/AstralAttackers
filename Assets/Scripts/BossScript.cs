using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject weakSpot; 
    public GameObject[] appendages; 
    public AudioClip bossMusic;
    private AudioSource audioSource;
    public float speed = 5f;
    private bool isMovingRight = true;

    public int bossScoreValue = 1000;

    //-----------------change color when weak spot hitted----------------------
    public Color flashColor = Color.white; // Color to flash when hit
    public float flashDuration = 1f; // Duration of flash

    private Renderer[] bossRenderers;
    private Color[] originalColors;

    private void Start()
    {
        weakSpot.SetActive(false);

        if(GameManager.S.currentState == GameState.Playing)
        {
            // Start the boss music
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = bossMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

        // Initialize the renderer arrays
        bossRenderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[bossRenderers.Length];

        for (int i = 0; i < bossRenderers.Length; i++)
        {
            originalColors[i] = bossRenderers[i].material.color;
        }

    }

    private void Update()
    {
        if (GameManager.S.currentState == GameState.Playing)
        {
            if (isMovingRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);

                if (transform.position.x >= 30)
                {
                    isMovingRight = false;
                }
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);

                if (transform.position.x <= -30)
                {
                    isMovingRight = true;
                }
            }
        }


    }

    public void AppendageDestroyed()
    {
        // Check if all appendages are destroyed
        bool allDestroyed = false;
        foreach (GameObject appendage in appendages)
        {
            if (appendage.activeSelf)
            {
                allDestroyed = false;
                break;
            }
            allDestroyed = true;
        }

        if (allDestroyed)
        {
            // Activate the weak spot
            weakSpot.SetActive(true);
        }
    }

    public void BossDefeated()
    {
        // Reward player with score for defeating the boss
       // GameManager.S.AddScore(bossScoreValue);

        GameManager.S.BossDefeated();

        Destroy(gameObject);
    }

    //-----------------change color when weak spot hitted----------------------
    public void FlashOnHit()
    {
        StartCoroutine(FlashEffect());
    }

    private IEnumerator FlashEffect()
    {
        // Set all boss parts to flash color
        foreach (Renderer rend in bossRenderers)
        {
            rend.material.color = flashColor;
        }
        yield return new WaitForSeconds(flashDuration);

        // Reset the colors
        for (int i = 0; i < bossRenderers.Length; i++)
        {
            bossRenderers[i].material.color = originalColors[i];
        }
    }
}
