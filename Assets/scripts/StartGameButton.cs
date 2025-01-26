using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    bool starting = false;


    void OnMouseDown(){
        if (!starting){
            AudioSource sorce = GetComponent(typeof(AudioSource)) as AudioSource;
            sorce.Play();

            IEnumerator coroutine;
            coroutine = startGame();
            StartCoroutine(coroutine);
        }
    }

    void OnMouseEnter(){
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sr.sprite = openSprite;
    }

    void OnMouseExit(){
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        sr.sprite = closedSprite;
    }

    private IEnumerator startGame(){
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
}
