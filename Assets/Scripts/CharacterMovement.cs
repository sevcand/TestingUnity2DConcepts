using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera;
    private int sayi;


    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        charPos = transform.position;
        sayi = 1;

    }


    private void FixedUpdate()
    {
        //Debug.Log("Fixed:" + sayi);
        // r2d.velocity = new Vector2(speed, 0.0f)
        //_camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
        sayi = 2;

    }


    void Update()
    {

        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal")) * (speed * Time.deltaTime), (charPos.y));
        transform.position = charPos;

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            speed = 0f;
            _animator.SetFloat("speed", speed);

        }
        else
        {
            speed = 1f;
            _animator.SetFloat("speed", speed);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;

        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
        _animator.SetFloat("speed", speed);
        sayi = 3;

    }

    private void LateUpdate()
    {
        //_camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
        sayi = 4;

    }
}
