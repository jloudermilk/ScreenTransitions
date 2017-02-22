using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrisTransition : ScreenTransition
{

    public Transform Mask;

    public float transitionTime = 1;

    public AnimationCurve minCurve;
    public AnimationCurve maxCurve;



    public override IEnumerator TransitionIn(Vector3 pos)
    {
        isAnimating = true;
        Mask.GetComponent<RectTransform>().anchoredPosition = WorldToCavasPos(pos);
        float time = 0;
        while (isAnimating)
        {

            Mask.localScale = Vector2.one * minCurve.Evaluate(time += Time.deltaTime * (1 / transitionTime));
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
        Mask.GetComponent<RectTransform>().anchoredPosition = WorldToCavasPos(pos);
        float time = 0;
        while (isAnimating)
        {
            Mask.localScale = Vector2.one * maxCurve.Evaluate(time += Time.deltaTime * (1 / transitionTime));
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
