using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D mRb;
    public Vector2 mVelocidade;
    public float velocidade = 6f;

    // Start is called before the first frame update
    void Start()
    {
        // Passando a velocidade
        mVelocidade.x = velocidade;
        mVelocidade.y = velocidade;

        // Gerando um valor aleatorio
        int random = Random.Range(0, 4);

        // Gerando a direção aleatória da bola
        switch(random)
        {
            // Superior direita
            case 0:
                mVelocidade.x = velocidade;
                mVelocidade.y = velocidade;
                break;

            // Superior esquerda
            case 1:
                mVelocidade.x = -velocidade;
                mVelocidade.y = -velocidade;
                break;

            // Inferior direita
            case 2:
                mVelocidade.y = -velocidade;
                mVelocidade.x = velocidade;
                break;

            // Inferior esquerda
            case 3:
                mVelocidade.y = velocidade;
                mVelocidade.x = -velocidade;
                break;
        }

        // Velocidade para esquerda
        mRb.velocity = mVelocidade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{this.tag} Colidiu");
    }
}
