using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
             Object[] allObjects = FindObjectsOfType(typeof(GameObject),true);
             foreach (GameObject a in allObjects) {
                if (a.transform.parent == this.transform.parent){
                    a.SetActive(true);
                }
             }
            gameObject.SetActive(false);
        }
    }
}
