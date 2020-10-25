using System;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    // Posição da raquete
    private Vector3 mPosition;
    public float mY;
    private float velocity = 3f;
    private float limit = 3.5f;

    // Se trata do jogador 1?
    public bool player1 = false;

    // Deve ser controlado pela AI?
    public bool isAi = false;

    // A bola
    public Transform ballTransform;

    void Start()
    {
        // Posição inicial da raquete
        mPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        racketControls();
    }

    public void racketControls()
    {
        // Passando a posição do mY
        mPosition.y = mY;

        // Modificar a posição da raquete
        transform.position = mPosition;

        // Velocidade com deltatime
        float deltaPosition = velocity * Time.deltaTime;

        if (player1)
        {
            // Subindo a raquete do jogador 1
            if (Input.GetKey(KeyCode.W) && mY < limit)
            {
                mY += deltaPosition;
            }

            // Descendo a raquete do jogador 1
            if (Input.GetKey(KeyCode.S) && mY > -limit)
            {
                mY -= deltaPosition;
            }
        }
        else
        {
            if (!isAi)
            {
                // Subindo a raquete do jogador 2
                if (Input.GetKey(KeyCode.UpArrow) && mY < limit)
                {
                    mY += deltaPosition;
                }

                // Descendo a raquete do jogador 2
                if (Input.GetKey(KeyCode.DownArrow) && mY > -limit)
                {
                    mY -= deltaPosition;
                }

                // Retirando o jogador 2 da AI
                if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
                {
                    isAi = true;
                }
            } else
            {
                // Racket controlada por AI usando Interpolação Linear
                mY = Mathf.Lerp(mY, ballTransform.position.y, 0.03f);

                // Colocando a AI pra jogar
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                {
                    isAi = false;
                }
            }
        }

        // Impedir que o jogador sai da tela por baixo
        if (mY < -limit)
        {
            mY = -limit;
        }

        // Impedir que o jogador sai da tela por cima
        if (mY > limit)
        {
            mY = limit;
        }
    }
}
