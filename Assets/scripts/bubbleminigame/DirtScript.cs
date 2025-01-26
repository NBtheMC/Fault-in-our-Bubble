using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour
{

    public GameObject stainPrefab;
    public GameObject spongePrefab;
    GameObject mySponge;

    Texture2D texture;
    Vector3 lastMousePos = new Vector3(0,0,0);

    float minigameTimeSeconds = 60;
    float timeRemaining = 0;
    bool minigameOver = false;
    float scoreToWin = 200;

    float score = 20000;

    float getScore()
    {
        return score;
    }

    float scrubFunction(float x)
    {
        return Mathf.Pow((Mathf.Pow(2.71828f, -Mathf.Pow(Mathf.Sqrt((4.0f / 300) * x) - 2, 2) / 2) / Mathf.Sqrt(2 * 3.141592f)) * (1 / .3984f), 2);
    }

    void beginMinigame(string dirt_texture)
    {
        texture = Instantiate(Resources.Load<Texture2D>(dirt_texture));
        var sprite = Sprite.Create(texture, new Rect(0, 0, 960, 540), new Vector2(0f, 0f));
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;

        timeRemaining = minigameTimeSeconds;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++) //Goes through each pixel
            {
                var c = texture.GetPixel(x, y);
                if (c.a >= 0.1)
                {
                    texture.SetPixel(x, y, new Color(c.r, c.g, c.b, 0.5f));
                }
            }
        }

        mySponge = Instantiate(spongePrefab);
        minigameOver = false;

    }

    void endMinigame()
    {
        minigameOver = true;
        Destroy(mySponge);
    }

    // Start is called before the first frame update
    void Start()
    {
        beginMinigame("toilet_mask");
    }

    // Update is called once per frame
    void Update()
    {

        if (!minigameOver)
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

            var MousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            var MouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mouseX = MousePos.x * texture.width;
            var mouseY = MousePos.y * texture.height;

            mySponge.transform.position = new Vector2(MouseWorld.x, MouseWorld.y);

            var cleanRadius = 48;
            var scrubStrength = 300;
            var scrubDampen = 0.025f;

            // Calculate mouse diff
            var mouseDiff = 0f;
            mouseDiff = Mathf.Sqrt((MousePos.x - lastMousePos.x) * (MousePos.x - lastMousePos.x) + (MousePos.y - lastMousePos.y) * (MousePos.y - lastMousePos.y));
            lastMousePos = new Vector3(MousePos.x, MousePos.y, 0);
            var scrubAmount = scrubFunction(mouseDiff * scrubStrength / Time.deltaTime);

            for (int y = (int)mouseY - cleanRadius; y <= (int)mouseY + cleanRadius; y++)
            {
                for (int x = (int)mouseX - cleanRadius; x <= (int)mouseX + cleanRadius; x++) //Goes through each pixel
                {
                    if ((MousePos.x * texture.width - x) * (MousePos.x * texture.width - x) + (MousePos.y * texture.height - y) * (MousePos.y * texture.height - y) < cleanRadius * cleanRadius) //50/50 chance it will be black or white
                    {
                        var c = texture.GetPixel(x, y);
                        texture.SetPixel(x, y, new Color(c.r, c.g, c.b, c.a - scrubAmount * scrubDampen));
                    }

                }
            }

            float currScore = 0;
            for (int y = 0; y < texture.height; y += 8)
            {
                for (int x = 0; x < texture.width; x += 8) //Goes through each pixel
                {
                    var c = texture.GetPixel(x, y);
                    score += c.a;
                }
            }
            score = currScore;
            texture.Apply();

            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                minigameOver = true;
                if (score < scoreToWin)
                {
                    onWin();
                } else
                {
                    onLose();
                }
            }
        }
    }

    void onWin()
    {
        endMinigame();
    }

    void onLose()
    {
        endMinigame();
    }

}
