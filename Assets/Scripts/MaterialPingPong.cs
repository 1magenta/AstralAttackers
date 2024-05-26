using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPingPong : MonoBehaviour
{
    public Material[] myMaterials;
    public float duration = 2.0f;

    private Renderer thisRender;

    // Start is called before the first frame update
    void Start()
    {
        thisRender = GetComponent<Renderer>();
        thisRender.material = myMaterials[0];
    }

    // Update is called once per frame
    void Update()
    {
        float myLerp = Mathf.PingPong(Time.time, duration) / duration;
        thisRender.material.Lerp(myMaterials[0], myMaterials[1], myLerp);
    }
}
