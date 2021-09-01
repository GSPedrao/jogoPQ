using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{

    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    private Vector3 posicaoIni;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject textoQtdClube;
    private int qtdClube;

    // Start is called before the first frame update
    void Start()
    {
        posicaoIni = this.transform.position;
        anim = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>(); 
        qtdClube = 0;
        AtualizarHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
             sprite.flipX = false;
            Vector3 pos = this.transform.position;
            pos.x +=  velocidade;
            this.transform.position = pos;
        }
        if(Input.GetKey(KeyCode.A))
        {
              sprite.flipX = true;
             Vector3 pos = this.transform.position;
             pos.x -= velocidade;
             this.transform.position = pos;
        }
        if(Input.GetKey(KeyCode.W) && tempoPulado <= 0)
        {

             Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
             Vector2 forca = new  Vector2(0f, 7f);
             rb.AddForce(forca, ForceMode2D.Impulse);
             tempoPulado = tempoPulo;
             anim.SetBool("estaPulando", true);
        }
        tempoPulado -= Time.deltaTime;
        
         if(this.transform.position.y < -14f)
        {
            this.transform.position = posicaoIni;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("andando", true);
        }
        else
        {
            anim.SetBool("andando", false);
        }
    }
    

    //-----------------------//
    void OnCollisionEnter2D(Collision2D col)
    {
         if(col.gameObject.tag == "spike")
         {
             this.transform.position = posicaoIni;
         }
         if(col.gameObject.tag == "chao")
        {
            anim.SetBool("estaPulando", false);
        }
        if(col.gameObject.tag == "clubeSocial")
        {
            qtdClube++;
            AtualizarHUD();
            Destroy(col.gameObject);
        }   

    
    }
            void AtualizarHUD(){
            textoQtdClube.GetComponent<Text>().text = qtdClube.ToString();
        }
       
        
        
    
}
