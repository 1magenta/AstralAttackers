using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectScript : MonoBehaviour
{
    // movement variables
    public float playerSpeed;
    private float MAX_OFFSET = 15.0f;

    // bullet variables
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.S.currentState == GameState.Playing)
        {
            MovePlayer();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireBullet();
            }

        }

    }

    private void FireBullet()
    {
        // spawn a new bullet
        GameObject bulletObject = Instantiate(bulletPrefab, (transform.position + Vector3.up * 1.5f), Quaternion.identity);

        // set the self destruct timer
        Destroy(bulletObject, 2.0f);
    }

    void MovePlayer()
    {
        // getting the vector
        Vector3 currentPosition = transform.position;

        // set the x value based on input
        currentPosition.x = currentPosition.x + (Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime);

        // check our values with clamp
        currentPosition.x = Mathf.Clamp(currentPosition.x, -MAX_OFFSET, MAX_OFFSET);

        // update our position
        transform.position = currentPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "EnemyBomb")
        {
            // player object is destroyed
            GameManager.S.PlayerObjectDestroyed();

            // destroy this


        }
    }


}
// 53353 UGE F23 W5