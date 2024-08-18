using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float           moveSpeed;
    [SerializeField]
    private Rigidbody2D     rb2d;
    private Vector2         moveInput;
    private SpriteRenderer  sprite;
    private Animator        animator;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        moveInput.Normalize();

        rb2d.velocity = moveInput*moveSpeed;

        //update animation parameters
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);

        sprite.flipX = moveInput.x==-1;
    }

    public void StopMvmt()
    {
        rb2d.velocity = Vector3.zero;
    }
}
