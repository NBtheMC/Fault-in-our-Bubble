using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBubble : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 origin = new Vector2(0, 0);
    float timer = 0;
    int lastMove = 0;

    void Start()
    {
        print("Bubble spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        if (origin.x == 0 && origin.y == 0)
        {
            origin.x = transform.position.x;
            origin.y = transform.position.y;
        }
        var offs = Random.insideUnitCircle;
        if ((int)(timer * 10) != lastMove)
        {
            transform.position = (new Vector3((float)(origin.x + (offs.x - 0.5) * 0.05), (float)(origin.y + (offs.y - 0.5) * 0.05), transform.position.z));
            lastMove = (int)(timer * 10);
        }
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
