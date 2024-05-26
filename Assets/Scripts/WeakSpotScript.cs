using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpotScript : MonoBehaviour
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
        Debug.Log("weak hit");
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            currHit++;

            //Boss flash
            transform.parent.GetComponent<BossScript>().FlashOnHit();

            if (currHit >= hitsToDestory)
            {
                audioSource.PlayOneShot(explosionSound);
                //destory the boss
                //Destroy(transform.parent.gameObject);
                transform.parent.GetComponent<BossScript>().BossDefeated();
            }
        }

    }

}
