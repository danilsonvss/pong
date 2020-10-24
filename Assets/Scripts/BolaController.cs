using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    public Rigidbody2D mRb;
    public Vector2 mVelocidade;
    public float velocidade = 6f;
    // Start is called before the first frame update
    void Start()
    {
        // Passando a velocidade
        mVelocidade.x = -velocidade;

        // Velocidade para esquerda
        mRb.velocity = mVelocidade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
