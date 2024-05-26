using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // shoot our bullet
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = (Vector3.up * bulletSpeed);



    }


}
// 53353 UGE F23 W5