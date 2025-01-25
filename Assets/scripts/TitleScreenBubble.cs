using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sr.color = Color.HSVToRGB(Random.Range(0.0f,1.0f), .9f, .8f);
    }
}
