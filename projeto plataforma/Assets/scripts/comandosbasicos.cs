using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class comandosbasicos : MonoBehaviour
{
    public float velocidadePersonagem;
    private Rigidbody2D rbPlayer;
    private float movimentoHorizontal;
    private Animator anim;
    private bool verificarDirecao;
    public float jump;
    public Transform posicaoSensor;
    public bool sensor;
    public LayerMask chao;
    public TextMeshProUGUI textovida;
    public TextMeshProUGUI textomunicao;
    private float vida;
    private float municao;
    public GameObject painelGameOver;
    public GameObject EntrarnoJogo;
    public GameObject SairdoJogo;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vida = 5;

    }

    // Update is called once per frame
    void Update()
    {
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoHorizontal * velocidadePersonagem, rbPlayer.velocity.y);

       

        if (movimentoHorizontal > 0 && verificarDirecao == true)
        {
            direcao();
        }
        else if (movimentoHorizontal < 0 && verificarDirecao == false)
        {
            direcao();
        }
        pular();
        detectarChao();

        anim.SetInteger("run", (int)movimentoHorizontal);

        textovida.text=vida.ToString();
        textomunicao.text=municao.ToString();
        if (vida<=0)
        {
            anim.SetTrigger("inimigo");
            Time.timeScale = 0;
            painelGameOver.SetActive(true);
             
        }

    }

    public void direcao()
    {
        verificarDirecao = !verificarDirecao;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

    }
    public void pular()
    {
        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            rbPlayer.AddForce(new Vector2(0, jump));
            
        }
        anim.SetBool("sensor", sensor);
    }



    public void detectarChao()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.25f, chao);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coletavel"))
        {
            vida++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("municao"))
        {
            municao++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("inimigo"))
        {
            vida -= 1;
           
        }

    }
    public void reiniciarJogo()
    {
        SceneManager.LoadScene("cena");
    }
    public void sairJogo()
    {
        Application.Quit(); 
    }
    public void entrarJogo()
    {
        SceneManager.LoadScene("cena");
    }

    public void sair()
    {
        Application.Quit();
    }
}
