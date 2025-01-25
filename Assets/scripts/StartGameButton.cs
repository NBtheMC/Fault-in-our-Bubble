using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;


    void OnMouseDown(){
        SceneManager.LoadScene(1);
    }

    void OnMouseEnter(){
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sr.sprite = openSprite;
    }

    void OnMouseExit(){
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sr.sprite = closedSprite;
    }
}
