using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
   
{
    public float velocidadeInimigo;
    public float velocidadeAtual;
    private bool verificarDirecao;
    public float limiteDireito, limiteEsquerdo;

    public Transform posicaoDireita, posicaoEsquerda;
    void Start()
    {
        velocidadeInimigo = velocidadeAtual;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= posicaoEsquerda.position.x && verificarDirecao == true) 
        {
            velocidadeInimigo = velocidadeAtual;
            direcao();
        }else if (transform.position.x>=posicaoDireita.position.x && verificarDirecao==false)
        {
            velocidadeInimigo = -velocidadeAtual;
            direcao();
        }
        transform.Translate(new Vector2(velocidadeInimigo, 0) * Time.deltaTime);  
    }
    public void direcao()
    {
        verificarDirecao = !verificarDirecao;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("tiro"))
        {

            Debug.Log("colidiu");
            Destroy(gameObject);
            Destroy(collision.gameObject);  

        }
    }
    

}
