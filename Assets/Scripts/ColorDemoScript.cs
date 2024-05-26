using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDemoScript : MonoBehaviour
{
    public Color newColor = Color.white;

    private ColorEffectScript thisColorEffect;

    // Start is called before the first frame update
    void Start()
    {
        thisColorEffect = GetComponent<ColorEffectScript>();
        Renderer[] cubeRenders = GetComponentsInChildren<Renderer>();
        foreach (Renderer cube in cubeRenders)
        {
            thisColorEffect.SetThisObjectColor(cube, newColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
