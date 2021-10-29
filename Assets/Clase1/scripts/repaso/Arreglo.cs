using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arreglo : MonoBehaviour
{
    int contador = 1;
    public int[,] matriz = new int[4, 4];

    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 4 ; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                matriz[i,j] = contador;
                contador++;
                Debug.Log(matriz[i,j].ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
