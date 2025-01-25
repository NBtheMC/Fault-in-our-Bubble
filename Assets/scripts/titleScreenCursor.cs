using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScreenCursor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x,mouseWorldPos.y,-1);
    }
}
