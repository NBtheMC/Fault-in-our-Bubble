using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpout : MonoBehaviour
{

    Toilet toilet;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator coroutine;
        coroutine = scaleUp();
        StartCoroutine(coroutine);
    }


    private IEnumerator scaleUp(){
        while (transform.localScale.y < 18){
            yield return null;
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y + 0.06f,1);
            transform.position = new Vector3(transform.position.x,transform.position.y + 0.01f,transform.position.z);
        }
        transform.localScale = new Vector3(transform.localScale.x,18,1);

        IEnumerator coroutine;
        coroutine = scaleDown(Random.Range(2.0f,5.0f));
        StartCoroutine(coroutine);
        
     }

    private IEnumerator scaleDown(float after){
        yield return new WaitForSeconds(after);
        while (transform.localScale.y > 0){
            yield return null;
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y - 0.066f,1);
            transform.position = new Vector3(transform.position.x,transform.position.y - 0.01f,transform.position.z);
        }
        toilet.close();
        Destroy(gameObject);
     }

    public void setToilet(Toilet newToilet){
        toilet = newToilet;
    }

    public void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.GetComponent(typeof(Bubble)) != null){
            
            Rigidbody2D mikeRB = other.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

            mikeRB.AddForce(0.3f*new Vector2(0,1),ForceMode2D.Impulse);
        }
    }
}
