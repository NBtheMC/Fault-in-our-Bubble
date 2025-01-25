using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    public List <Sprite> junks;
    void Start()
    {
        int spriteNum = Random.Range(0,junks.Count);
        SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        sr.sprite = junks[spriteNum];

        
    }

    void Update()
    {
        transform.Rotate(0,0,1,Space.Self);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
    }

}
