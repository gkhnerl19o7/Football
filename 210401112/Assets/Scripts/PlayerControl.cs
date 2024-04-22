using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody ballrb;
    protected byte Speed = 10; // oyuncu hýzý
    public Transform Ball, Dribbling;
    void Update()
    {
        PlayerMove();
    }
    
    void PlayerMove() 
    {
        float hareketInput = Input.GetAxis("Vertical"); // Ýleri/geri hareket için giriþ al
        float donmeInput = Input.GetAxis("Horizontal"); // Dönüþ için giriþ al

        // karakteri ileri/geri hareket ettir
        transform.Translate(Vector3.forward * hareketInput * Speed * Time.deltaTime);
        
            // karakteri saða veya sola döndür
        transform.Rotate(Vector3.up, 50 * donmeInput * Time.deltaTime);
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag=="Ball")
        {
            Ball.transform.position = Dribbling.transform.position;
        }    
    }
}
