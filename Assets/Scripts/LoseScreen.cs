using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI loseTime;
    public Animator scenetransition;
    // Start is called before the first frame update
    
    private void Start() {
        
    }
    // Update is called once per frame
    void Update()
    {
        loseTime.text = "Time survived: " + time.text;
    }

    public void PlayAgain(){
        
        StartCoroutine(PlayAgainTransition());
        
    }


    IEnumerator PlayAgainTransition(){
        
        scenetransition.SetTrigger("lose");
        yield return new WaitForSecondsRealtime(4/12f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator EnableAnimator(){
        yield return new WaitForSecondsRealtime(0.2f);
        scenetransition.enabled = true;
    }
}
