using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    private Vector3 posicaoIni;
    // Start is called before the first frame update
    void Start()
    {
        posicaoIni = this.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            Vector3 pos = this.transform.position;
            pos.x +=  velocidade;
            this.transform.position = pos;
        }
        if(Input.GetKey(KeyCode.A))
        {
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
        }
        tempoPulado -= Time.deltaTime;
        
         if(this.transform.position.y < -14f)
        {
            this.transform.position = posicaoIni;
        }
    }
    

    //-----------------------//
    void OnCollisionEnter2D(Collision2D col)
    {

       
        
        
    }
}
