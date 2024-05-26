using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorEffectScript))]

public class ColorDemo3Script : MonoBehaviour
{
    private ColorEffectScript thisEffectScript;
    private Renderer[] childRenders;

    public Color firstColor = Color.white;
    public Color secondColor = Color.white;

    public float transitionTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        thisEffectScript = GetComponent<ColorEffectScript>();
        childRenders = GetComponentsInChildren<Renderer>();

        thisEffectScript.SetThisObjectColor(childRenders, firstColor);

        // StartCoroutine(TransitionColor(firstColor, secondColor, transitionTime));
    }

    // Update is called once per frame
    void Update()
    {
        float currentLerpValue = Mathf.PingPong(Time.time, transitionTime) / transitionTime;
        Color newColor = Color.Lerp(firstColor, secondColor, currentLerpValue);
        thisEffectScript.SetThisObjectColor(childRenders, newColor);
    }

    private IEnumerator TransitionColor(Color startColor, Color endColor, float duration)
    {
        float currentTime = 0f;



        bool timeExpired = false;

        while (currentTime/duration < 1.0f) {

            Color newColor = Color.Lerp(startColor, endColor, currentTime / duration);
            thisEffectScript.SetThisObjectColor(childRenders, newColor);
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        thisEffectScript.SetThisObjectColor(childRenders, endColor);



    }

}
