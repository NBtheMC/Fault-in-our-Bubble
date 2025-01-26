using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timePassed = 0;

    public GameObject visualNovel;
    void OnEnable()
    {
        StopAllCoroutines();
        IEnumerator coroutine;
        coroutine = winTimer();
        StartCoroutine(coroutine);
        timePassed = 0;
    }

    private IEnumerator winTimer(){
        while (timePassed < 20){
            yield return new WaitForSeconds(1);
            timePassed = timePassed + 1;
            Text t = GetComponent(typeof (Text)) as Text;
            t.text = "Time Left: " + (20 -timePassed);
        }

        this.transform.parent.parent.gameObject.SetActive(false);
        visualNovel.SetActive(true);
        Junk[] junk = FindObjectsOfType<Junk>();
        foreach (Junk a in junk) {
            Destroy(a.gameObject);
        }
    }
}
