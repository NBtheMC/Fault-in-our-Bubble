using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject mike;

    public GameObject junkPrefab;

    void OnEnable(){
        IEnumerator coroutine;
        coroutine = spawnJunk();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D mikeRB = mike.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        mikeRB.AddForce((1.33f*Time.deltaTime)*new Vector2(0,1),ForceMode2D.Impulse);
    }

    private IEnumerator spawnJunk(){
    
        while (true){
            float nextJunkTime = Random.Range(.3f,1.0f);
            yield return new WaitForSeconds(nextJunkTime);
            GameObject junk = Instantiate(junkPrefab,null);

            junk.transform.position = new Vector3(Random.Range(0,20.0f) - 10.0f,this.transform.position.y,junk.transform.position.z);

            Rigidbody2D junkRB = junk.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

            junkRB.AddForce(new Vector2(Random.Range(0,8.0f) - 4,-4),ForceMode2D.Impulse);
        }

    }


}
