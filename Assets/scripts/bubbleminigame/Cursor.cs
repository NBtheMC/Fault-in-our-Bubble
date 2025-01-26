using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public GameObject mike;

    public GameObject waveprefab;

    IEnumerator waveRoutine;

    bool waveRoutineRunning;

    void Start()
    {
        waveRoutine = spawnWaves();
    }

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x,mouseWorldPos.y,-1);

        Vector3 targ = mike.transform.position;
        targ.z = 0f;

        Vector3 cursorPos = transform.position;
        targ.x = targ.x - cursorPos.x;
        targ.y = targ.y - cursorPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButton(0)){
            if (!waveRoutineRunning){
                waveRoutineRunning = true;
                StartCoroutine(waveRoutine);
                AudioSource sorce = GetComponent(typeof(AudioSource)) as AudioSource;
                sorce.Play();
            }
            float dist = Vector3.Distance(mike.transform.position, transform.position);
            Vector3 dir = (mike.transform.position - this.transform.position).normalized;
            if (dist > 5){
                return;
            }

            Rigidbody2D mikeRB = mike.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

            print(Time.deltaTime);
            mikeRB.AddForce(((14*Time.deltaTime)/dist)*new Vector2(dir.x,dir.y),ForceMode2D.Impulse);
            
        } else {
            if (waveRoutineRunning){
                StopCoroutine(waveRoutine);
                waveRoutineRunning = false;
                AudioSource sorce = GetComponent(typeof(AudioSource)) as AudioSource;
                sorce.Stop();
            }
        }
    }

    private IEnumerator spawnWaves(){
        float waitTime = .3f;
        while(true){
            GameObject curWave = Instantiate(waveprefab,null);
            curWave.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
            wave w = curWave.GetComponent(typeof(wave)) as wave;
            Vector3 dir = (mike.transform.position - this.transform.position).normalized;

            w.setDir(dir);
            yield return new WaitForSeconds(waitTime);
        }
    }



//    void OnMouseDown()
//    {
//    }
}
