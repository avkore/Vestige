using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        anim.SetFloat("Speed", movement.sqrMagnitude);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsHitting", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("IsHitting", false);
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.Instance.OpenInventory(true);
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            Inventory.Instance.OpenInventory(false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        
        if (movement.x > 0)
            transform.localScale = Vector3.one;
        else if (movement.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}