using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    void OnEnable()
    {
        IEnumerator coroutine;
        coroutine = playFart();
        StartCoroutine(coroutine);
    }

    private IEnumerator playFart(){
        yield return new WaitForSeconds(45);
        AudioSource sorce = GetComponent(typeof(AudioSource)) as AudioSource;
        sorce.Play();
    }
}
