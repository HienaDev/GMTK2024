using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    private SpriteRenderer sprite;
    
    //playarea bounds
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        //get camera bounds
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane)).x;
        minY = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).y;
        maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane)).y;

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
       
        float spriteHalfWidth = sprite.bounds.size.x/2f;
        float spriteHalfHeight = sprite.bounds.size.y/2f;
        
        moveInput.Normalize();

        rb2d.velocity = moveInput*moveSpeed;
    }

    public void StopMvmt()
    {
        rb2d.velocity = Vector3.zero;
    }
}
