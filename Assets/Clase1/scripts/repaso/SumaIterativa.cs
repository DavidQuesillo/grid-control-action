using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumaIterativa : MonoBehaviour
{
    public int first = 4;
    public int second = 9;
    public int suma = 0;

    // Start is called before the first frame update
    void Start()
    {
        suma = first;

        for (int i = 0; i < second; i++)
        {
            suma += first;
        }

        Debug.Log(suma.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
