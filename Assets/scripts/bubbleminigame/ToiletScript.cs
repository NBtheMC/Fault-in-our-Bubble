using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletScript : MonoBehaviour
{

    Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        texture = Instantiate(Resources.Load<Texture2D>("cleaning_bg"));
        var sprite = Sprite.Create(texture, new Rect(0, 0, 1920, 1080), new Vector2(0f, 0f));
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // Scale to screen size
        var bl = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var tr = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        transform.position = new Vector3(bl.x, bl.y, 0f);
        var sprite_width = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        var sprite_height = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        var sprite_scale_x = ((tr.x - bl.x) / sprite_width);
        var sprite_scale_y = ((tr.y - bl.y) / sprite_height);
        transform.localScale = new Vector3(sprite_scale_x, sprite_scale_y, 0f);
    }
}
