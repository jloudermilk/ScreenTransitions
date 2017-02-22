using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeTransition : ScreenTransition {


    public Image Fade;

    public float transitionTime = 1;

    public AnimationCurve fadeInCurve;
    public AnimationCurve fadeOutCurve;
    public Color fadeColor;



    public override IEnumerator TransitionIn(Vector3 pos)
    {
        isAnimating = true;
      
        float time = 0;
        while (isAnimating)
        {
            Color clear = fadeColor;
            clear.a = 0;
            clear.a = fadeInCurve.Evaluate(time += Time.deltaTime * (1 / transitionTime));
            Fade.color = clear;
           
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
            Color solid = fadeColor;
            solid.a = fadeOutCurve.Evaluate(time += Time.deltaTime * (1 / transitionTime));
            Fade.color = solid;
            
            if (time > 1)
            {
                isAnimating = false;
            }
            yield return null;
        }
    }

    Vector2 WorldToCavasPos(Vector3 pos)
    {
        RectTransform CanvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(pos);
        float xPos = ((ViewportPosition.x * CanvasRect.sizeDelta.x) -
            (CanvasRect.sizeDelta.x * 0.5f));
        float yPos = ((ViewportPosition.y * CanvasRect.sizeDelta.y) -
            (CanvasRect.sizeDelta.y * 0.5f));
        Vector2 WorldObject_ScreenPosition = new Vector2(xPos, yPos);
        return WorldObject_ScreenPosition;
    }

}
