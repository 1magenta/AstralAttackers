using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipScript : MonoBehaviour
{
    public int stepsToSide;
    public float sideStepUnits;
    public float downStepUnits;
    public float timeBetweenSteps;

    public float timeBetweenBombs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheAttack()
    {
        StartCoroutine(MoveMother());
        StartCoroutine(DropOneBomb());
    }

    public void StopTheAttack()
    {
        StopAllCoroutines();
    }

    public IEnumerator MoveMother()
    {
        // define the  step vectors
        Vector3 sideStepVector = Vector3.right * sideStepUnits;
        Vector3 downStepVector = Vector3.down * downStepUnits;

        // move the swarm
        while (transform.childCount > 0)
        {
            // move to the side
            for (int i = 0; i < stepsToSide; i++)
            {
                // move by the offset
                transform.position = transform.position + sideStepVector;

                // run swap frames
                BroadcastMessage("SwapFrames");
                SoundManager.S.MakeTheEnemyAdvanceNoise();


                // wait for the interval
                yield return new WaitForSeconds(timeBetweenSteps);
            }


            // move down

            // run swap frames
            BroadcastMessage("SwapFrames");
            transform.position += downStepVector;
            yield return new WaitForSeconds(timeBetweenSteps);

            // flip the direction
            sideStepVector *= -1;


        }

    }

    public IEnumerator DropOneBomb()
    {
        bool _isRunning = true;

        while (_isRunning)
        {
            // wait for the interval
            yield return new WaitForSeconds(timeBetweenBombs);

            // see how many children there are
            int enemyCount = transform.childCount;

            // if we have children, 
            if (enemyCount > 0)
            {
                // pick one at random
                int enemyIndex = Random.Range(0,enemyCount);

                // get the child of this
                Transform thisEnemy = transform.GetChild(enemyIndex);

                // get the component
                EnemyScript thisEnemyScript = thisEnemy.GetComponent<EnemyScript>();

                if (thisEnemyScript)
                {
                    // have it send a bomb
                    thisEnemyScript.DropABomb();
                }


            } else
            {
                // else we don't have children, so stop the script.
                _isRunning = false;
                GameManager.S.AllEnemiesDestroyed();
            }

        }
    }


}
