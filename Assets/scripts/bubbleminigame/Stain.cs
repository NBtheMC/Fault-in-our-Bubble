using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stain : MonoBehaviour
{

    public GameObject bubblePrefab;

    float timer = 0;
    int bubbleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        print("Stain spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        while (timer / 0.2 > bubbleCount)
        {
            if (bubbleCount > 10)
            {
                break;
            }
            var bubble = Instantiate(bubblePrefab);
            var offs = Random.insideUnitCircle;
            bubble.transform.position = new Vector3(bubble.transform.position.x + offs.x * 0.5f, bubble.transform.position.y + offs.y * 0.5f, bubble.transform.position.z);
            bubbleCount++;
        }
    }
}
