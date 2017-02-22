using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScreenTransition: MonoBehaviour {

    protected bool isAnimating;


    public abstract IEnumerator TransitionIn(Vector3 pos);

    public abstract IEnumerator TransitionOut(Vector3 pos);


}
