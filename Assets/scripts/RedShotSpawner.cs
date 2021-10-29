using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShotSpawner : MonoBehaviour
{
    public GameObject badShot;
    public float timer = 0f;
    public float rate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rate;
    }

    public void FireAtplayer()
    {

    }
}
