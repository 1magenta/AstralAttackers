using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this requires the ColorEffectScript to be applied
[RequireComponent(typeof(ColorEffectScript))]

public class ColorDemo2Script : MonoBehaviour
{
    public Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        ColorEffectScript thisColorEffectScript = GetComponent<ColorEffectScript>();
        Renderer[] theseRenderers = GetComponentsInChildren<Renderer>();
        thisColorEffectScript.SetThisObjectColor(theseRenderers, newColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
