using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    Vector3 dir;

    bool fadingOut = false;

    void Start(){
        IEnumerator coroutine;
        coroutine = starFadeOut(0.3f);
        StartCoroutine(coroutine);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + dir.x,transform.position.y + dir.y,transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x + 0.002f,transform.localScale.y + 0.002f,transform.localScale.z);
        
        if (fadingOut){
            SpriteRenderer sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

            sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,sr.color.a - .05f);
            if (sr.color.a <= 0){
                Destroy(gameObject);
            }
        }
    }

    public void setDir(Vector3 newDir){
        dir = newDir;

        float angle = Mathf.Atan2(newDir.y, newDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private IEnumerator starFadeOut(float timeBefore){
        yield return new WaitForSeconds(timeBefore);
        fadingOut = true;
    }
}
