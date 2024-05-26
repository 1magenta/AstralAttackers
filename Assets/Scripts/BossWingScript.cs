using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWingScript : MonoBehaviour
{
    public int hitsToDestory = 2;
    private int currHit = 0;

    public AudioClip explosionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hIT");
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            currHit++;
            if (currHit >= hitsToDestory)
            {
                DestroyAppendage();
            } 
        }

    }

    private void DestroyAppendage()
    {
        audioSource.PlayOneShot(explosionSound);

        //Destroy(this.gameObject);
        gameObject.SetActive(false);
        transform.parent.GetComponent<BossScript>().AppendageDestroyed();
    }
}
