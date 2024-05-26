using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisScript : MonoBehaviour
{
    public Material startMaterial, endMaterial;
    public float duration;

    public void StartFade(Material startMat, Material endMat, float fadeTime)
    {
        startMaterial = startMat;
        endMaterial = endMat;
        duration = fadeTime;

        // start the coroutine
        StartCoroutine(FadeThisDebris());

    }

    public IEnumerator FadeThisDebris()
    {
        float currentTime = 0f;
        Renderer renderer = GetComponent<Renderer>();

        renderer.material = startMaterial;

        while (currentTime < duration)
        {
            // get lerp material values
            float lerpValue = currentTime / duration;

            // set the material to blend
            renderer.material.Lerp(startMaterial, endMaterial, lerpValue);

            // update current time
            currentTime += Time.deltaTime;

            // pause until next frame
            yield return new WaitForEndOfFrame();

        }

        // time has expired
        Destroy(this.gameObject);

    }


}
