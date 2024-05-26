using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEffectScript : MonoBehaviour
{
    public bool setStartColor = false;
    public Color startColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        if(setStartColor) { SetThisObjectColor(startColor); };
    }

    public void SetThisObjectColor(Color thisColor)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = thisColor;
    }

    public void SetThisObjectColor(Renderer thisRenderer, Color thisColor)
    {
        thisRenderer.material.color = thisColor;
    }

    public void SetThisObjectColor(Renderer[] theseRenderers, Color thisColor)
    {
        foreach (Renderer renderer in theseRenderers)
        {
            renderer.material.color = thisColor;
        }
    }

    
}
