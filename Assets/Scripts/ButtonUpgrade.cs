using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpgrade : MonoBehaviour
{
    public UpradeObject upradeObject;
    
    public void Click(){
        upradeObject.upgradeTypes.OnActivated();
        Destroy(transform.parent.gameObject);
        Time.timeScale = 1;
    }
}
