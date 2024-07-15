using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixotes : MonoBehaviour
{
    public GameObject meteoro;
    public float aleatorio;
    private Transform posicao;
    void Start()
    {
        aleatorio = Random.Range(170, 220);
        InvokeRepeating("meteoros", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void meteoros()
    {
        aleatorio = Random.Range(170, 220);

        GameObject temp = Instantiate(meteoro,new Vector2(aleatorio, 4), Quaternion.identity);

        Destroy(temp.gameObject, 3);
    }
}
