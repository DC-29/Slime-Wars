using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSelector : MonoBehaviour
{
    public List<UpradeObject> upgradeObject;
    public Button[] buttons;

    private void Start() {
        for (int i=0; i<buttons.Length;i++){
            
            int randomObject = UnityEngine.Random.Range(0,upgradeObject.Count);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = upgradeObject[randomObject].description;
            buttons[i].GetComponent<ButtonUpgrade>().upradeObject = upgradeObject[randomObject];
            upgradeObject.Remove(upgradeObject[randomObject]);
        }
    }

    

}
