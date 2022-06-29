using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float speed = 1.0f;
    private float moveDirection;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;


    void Awake()
    {
        _anim = GetComponent<Animator>();

    }
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;

        }
        
        else
        {
            moving = false;

        }

        _rigidbody2D.velocity = new Vector2(x:speed * moveDirection, _rigidbody2D.velocity.y);
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;

        }
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))){
            
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _anim.SetFloat(name:"speed", speed);

            } else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _anim.SetFloat(name:"speed", speed);

            }

        } else if (grounded == true)
        {
            moveDirection = 0.0f;
            _anim.SetFloat("speed", 0.0f);

        }

        if (grounded == true && (Input.GetKey(KeyCode.W)))
        {
            jump = true;
            grounded = false;
            _anim.SetTrigger("jump");
            _anim.SetBool("grounded", false);


        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            _anim.SetBool("grounded", true);
            grounded = true;
        }
    }
}
 