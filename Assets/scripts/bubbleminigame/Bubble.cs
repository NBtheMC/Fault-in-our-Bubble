using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject loseScreen;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(typeof(Vent)) != null || col.gameObject.GetComponent(typeof(Junk)) != null){
             GameObject[] allObjects = FindObjectsOfType<GameObject>();
             foreach (GameObject a in allObjects) {
                if (a.transform.parent == this.transform.parent || a.name == "Junk(Clone)" || a.name == "waterspout(Clone)"){
                    if (a.name == "Main Camera"){
                        continue;
                    }
                    if (a.name == "Junk(Clone)" || a.name == "wave(Clone)" || a.name == "waterspout(Clone)"){
                        Destroy(a);
                        continue;
                    }
                    Toilet t = a.GetComponent(typeof(Toilet)) as Toilet;
                    if (t != null){
                        t.close();
                    }
                    a.SetActive(false);
                }
             }
            this.transform.position = new Vector3(0,0,-.5f);
            loseScreen.SetActive(true);
        }
    }
}
