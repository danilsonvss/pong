using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    // Posição da raquete
    private Vector3 mPosicao;
    public float mY;
    private float velocidade = 3f;
    private float limit = 3.5f;

    public bool player1;

    void Start()
    {
        // Posição inicial da raquete
        mPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moverRaquete();
    }

    public void moverRaquete()
    {
        // Passando a posição do mY
        mPosicao.y = mY;

        // Modificar a posição da raquete
        transform.position = mPosicao;

        // Velocidade com deltatime
        float velocidadeDelta = velocidade * Time.deltaTime;

        if (player1)
        {
            // Subindo a raquete do jogador 1
            if (Input.GetKey(KeyCode.UpArrow) && mY < limit)
            {
                mY += velocidadeDelta;
                Debug.Log($"Movendo a raquete do jogador 1 para cima");
            }

            // Descendo a raquete do jogador 1
            if (Input.GetKey(KeyCode.DownArrow) && mY > -limit)
            {
                mY -= velocidadeDelta;

                Debug.Log($"Movendo a raquete do jogador 1 para baixo");
            }
        } else {
            // Subindo a raquete do jogador 2
            if (Input.GetKey(KeyCode.W) && mY < limit)
            {
                mY += velocidadeDelta;

                Debug.Log($"Movendo a raquete do jogador 2 para cima");
            }

            // Descendo a raquete do jogador 2
            if (Input.GetKey(KeyCode.S) && mY > -limit)
            {
                mY -= velocidadeDelta;

                Debug.Log($"Movendo a raquete do jogador 2 para baixo");
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
