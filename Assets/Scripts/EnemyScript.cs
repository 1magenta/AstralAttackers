using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyBombPrefab;

    public GameObject enemyFrameOne, enemyFrameTwo, enemyExplode;

    public int points = 100;

    [HeaderAttribute("Explosion Parameters")]
    public float explosionForce;
    public float explosionRadius;

    [HeaderAttribute("Material Parameters")]
    public Material startMaterial;
    public Material endMaterial;
    public float maxFadeTime = 1f;

    // Stronger enemy
    public int hitToExplode = 2;
    private int currHit = 0;
    public Material[] damageMaterials;

    // Start is called before the first frame update
    void Start()
    {
        enemyFrameOne.SetActive(true);
        enemyFrameTwo.SetActive(false);
        enemyExplode.SetActive(false);




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            DropABomb();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SwapFrames();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EnemyExplode();
        }

    }


    private void EnemyExplode()
    {
        // turn off the other objects and turn on the explosion frame
        enemyFrameOne.SetActive(false);
        enemyFrameTwo.SetActive(false);
        enemyExplode.SetActive(true);

        // Make the enemy explosion noise
        SoundManager.S.MakeEnemyExplosionSound();
        

        // get all of the rigidbodies
        Rigidbody[] enemyBlocks = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody block in enemyBlocks)
        {
            // adding the explosive force
            block.AddExplosionForce(explosionForce, (transform.position + Vector3.back * 2f), explosionRadius, 0f, ForceMode.Impulse);

            // randomize the fade time
            float thisFadeTime = Random.Range(0.1f, maxFadeTime);

            // set up the material fading process
            GameObject thisObject = block.gameObject;
            DebrisScript thisScript = thisObject.AddComponent<DebrisScript>();
            thisScript.StartFade(startMaterial, endMaterial, thisFadeTime);

        }
        // orphan the explosion object
        enemyExplode.transform.parent = null;
    }

    private void SwapFrames()
    {
        enemyFrameOne.SetActive(!enemyFrameOne.activeSelf);
        enemyFrameTwo.SetActive(!enemyFrameTwo.activeSelf);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "PlayerBullet")
        {
            /*// make everything explode
            EnemyExplode();
            GameManager.S.AddScore(points);

            // destroy this enemy object
            Destroy(this.gameObject);

            // destroy the bullet
            Destroy(collision.gameObject);*/

            currHit++;
            CheckDamageState();

            Destroy(collision.gameObject);
        }
    }

    private void CheckDamageState()
    {
        if(currHit >= hitToExplode)
        {
            EnemyExplode();
            GameManager.S.AddScore(points);
            Destroy(this.gameObject);
        }
        else
        {
            ChangeAppearanceOnDamage();
        }
    }

    private void ChangeAppearanceOnDamage()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        foreach(Renderer renderer in childRenderers)
        {
            if (currHit < damageMaterials.Length)
            {
                renderer.material = damageMaterials[currHit];
            }
        }

    }

    public void DropABomb()
    {
        // make an instance of the bomb
        Instantiate(enemyBombPrefab, transform.position + Vector3.down, Quaternion.identity);
    }

}
