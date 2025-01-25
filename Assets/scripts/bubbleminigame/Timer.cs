using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float winTime = 20.0f;
    void OnEnable()
    {
        StopAllCoroutines();
        IEnumerator coroutine;
        coroutine = winTimer();
        StartCoroutine(coroutine);
    }

    private IEnumerator winTimer(){
        yield return new WaitForSeconds(winTime);
        print("you win");
        //TODO go back to VN
    }
}
