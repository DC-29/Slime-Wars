using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource chorus;

    private void Start() {
        intro.Play();
        chorus.PlayDelayed(intro.clip.length);
    }

}
