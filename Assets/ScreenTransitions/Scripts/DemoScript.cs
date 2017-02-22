using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {

    public ScreenTransition Fade;
    public ScreenTransition Iris;
    public ScreenTransition Pixelate;


    // Update is called once per frame
   void Update () {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            StartCoroutine(Fade.TransitionIn(Vector3.zero));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            StartCoroutine(Fade.TransitionOut(Vector3.zero));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            StartCoroutine(Pixelate.TransitionIn(Vector3.zero));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            StartCoroutine(Pixelate.TransitionOut(Vector3.zero));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            StartCoroutine(Iris.TransitionIn(Vector3.zero));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            StartCoroutine(Iris.TransitionOut(Vector3.zero));
        }

    }
}
