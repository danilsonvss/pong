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
        float velocidadeDelta = velocity * Time.deltaTime;

        if (player1)
        {
            // Subindo a raquete do jogador 1
            if (Input.GetKey(KeyCode.W) && mY < limit)
            {
                mY += velocidadeDelta;
                Debug.Log($"Movendo a raquete do jogador 1 para cima");
            }

            // Descendo a raquete do jogador 1
            if (Input.GetKey(KeyCode.S) && mY > -limit)
            {
                mY -= velocidadeDelta;

                Debug.Log($"Movendo a raquete do jogador 1 para baixo");
            }
        }
        else
        {
            if (!isAi)
            {
                // Subindo a raquete do jogador 2
                if (Input.GetKey(KeyCode.UpArrow) && mY < limit)
                {
                    mY += velocidadeDelta;

                    Debug.Log($"Movendo a raquete do jogador 2 para cima");
                }

                // Descendo a raquete do jogador 2
                if (Input.GetKey(KeyCode.DownArrow) && mY > -limit)
                {
                    mY -= velocidadeDelta;

                    Debug.Log($"Movendo a raquete do jogador 2 para baixo");
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
