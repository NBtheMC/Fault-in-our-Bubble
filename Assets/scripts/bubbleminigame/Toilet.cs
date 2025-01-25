using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    
    public Sprite openSprite;
    public Sprite closeSprite;

    public GameObject spout;

    void OnEnable()
    {
        IEnumerator coroutine;
        coroutine = openAfterTime(Random.Range(0,10.0f));
        StartCoroutine(coroutine);
    }

     private IEnumerator openAfterTime(float time){
        yield return new WaitForSeconds(time);
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        sr.sprite = openSprite;
        GameObject water = Instantiate(spout,this.transform);
        WaterSpout ws = water.GetComponent(typeof(WaterSpout)) as WaterSpout;
        
        ws.setToilet(this);
        water.transform.position = new Vector3(water.transform.position.x + 0.2f,water.transform.position.y,water.transform.position.z);

     }

     public void close(){
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        sr.sprite = closeSprite;
        IEnumerator coroutine;
        coroutine = openAfterTime(Random.Range(0,10.0f));
        StartCoroutine(coroutine);
     }
}
