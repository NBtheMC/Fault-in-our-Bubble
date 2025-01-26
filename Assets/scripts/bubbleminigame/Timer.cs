using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using VNCreator;

public class Timer : MonoBehaviour
{
    float timePassed = 0;

    public GameObject visualNovel;

    public MinigamePlayer mp;
    void OnEnable()
    {
        StopAllCoroutines();
        IEnumerator coroutine;
        coroutine = winTimer();
        StartCoroutine(coroutine);
        timePassed = 0;
        Text t = GetComponent(typeof (Text)) as Text;
        t.text = "Time Left: 20";
    }

    private IEnumerator winTimer(){
        while (timePassed < 20){
            yield return new WaitForSeconds(1);
            timePassed = timePassed + 1;
            Text t = GetComponent(typeof (Text)) as Text;
            t.text = "Time Left: " + (20 -timePassed);
        }

        this.transform.parent.parent.gameObject.SetActive(false);
        //visualNovel.SetActive(true);
        mp.returnToVN();

        Junk[] junk = FindObjectsOfType<Junk>();
        foreach (Junk a in junk) {
            Destroy(a.gameObject);
        }
    }
}
