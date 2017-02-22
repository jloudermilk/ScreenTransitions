using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PixelateTransition : ScreenTransition {

    public Image filter;

    public float transitionTime = 1;

    public AnimationCurve pixelInCurve;
    public AnimationCurve pixelOutCurve;

    public override IEnumerator TransitionIn(Vector3 pos = default(Vector3))
    { 
        isAnimating = true;
        float time = 0;
        while (isAnimating)
        {
            float cellSize = pixelInCurve.Evaluate(time += Time.deltaTime * (1 / transitionTime));
            filter.material.SetFloat("_CellSize", cellSize);
            if (time > 1)
            {
                isAnimating = false;
            }
            yield return null;
        }
    }
    public override IEnumerator TransitionOut(Vector3 pos)
    {
        isAnimating = true;
        float time = 0;
        while (isAnimating)
        {
            float cellSize = pixelOutCurve.Evaluate(time += Time.deltaTime * (1 / transitionTime));
            filter.material.SetFloat("_CellSize", cellSize);
            if (time > 1)
            {
                isAnimating = false;
            }
            yield return null;
        }
    }
}
