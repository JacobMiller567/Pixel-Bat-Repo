using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 6f;
  
    private SpriteRenderer spriteRenderer;
    private Vector2 startSize;
    private float offset; //offset

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }

    /*
    private void FixedUpdate()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime, spriteRenderer.size.y);

        if (spriteRenderer.size.x > width)
        {
            offset += spriteRenderer.size.x - width; // Update the offset by the extra size
            spriteRenderer.size = startSize;
        }
        spriteRenderer.transform.position = new Vector2(-offset, spriteRenderer.transform.position.y); // Set the position using the offs
    }
    */

    private void Update()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime, spriteRenderer.size.y);

        if (spriteRenderer.size.x > width)
        {
            offset += spriteRenderer.size.x - width; // Update the offset by the extra size
            spriteRenderer.size = startSize;
        }
        spriteRenderer.transform.position = new Vector2(-offset, spriteRenderer.transform.position.y); // Set the position using the offs
    }
}
