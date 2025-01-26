using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Bleach : MonoBehaviour
{
    int bleachpoints = 0;
    public GameObject bleachText;

    public void OnMouseDown(){
        bleachpoints = bleachpoints + Random.Range(1,420);
        Text t = bleachText.GetComponent(typeof (Text)) as Text;
        t.text = "Points: " + bleachpoints;
    }
}
