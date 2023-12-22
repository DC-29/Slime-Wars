using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator scenetransition;
    // Start is called before the first frame update
    void Start()
    {
        scenetransition.enabled = false;
        StartCoroutine(EnableAnimator());
    }

    IEnumerator EnableAnimator(){
        yield return new WaitForFixedUpdate();
        scenetransition.enabled = true;
    }
}
