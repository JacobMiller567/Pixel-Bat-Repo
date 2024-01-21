using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotateSpeed = 10f;
    private Rigidbody2D rb;
    private new AudioSource audio;
    [SerializeField] private AudioSource loseAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    public void PointerDown()
    {
        audio.Play();
        rb.velocity = Vector2.up * _velocity;  
    }

    public void PointerUp()
    {

    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * _rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        loseAudio.Play();
        GameManager.instance.GameOver();
    }

}
