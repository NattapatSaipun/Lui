using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    public LayerMask groundLayer;
    public float jump = 5f;
    public bool isMoving = false;
    public GameObject Hand;

    private Animator Anime;
    


    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();   
         Anime = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FilpSprite();
        CheckGround();
        Jump();
        AnimePlayer();
    }
    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 	rb.velocity.y);
         isMoving = (Input.GetAxisRaw("Horizontal") != 0); 
    }
    void FilpSprite()
    {
        bool filp = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        Vector3 theScale = Hand.transform.localScale;
        if (filp)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
            
            
        }
     
       
        
        
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer); // checks if you are within 0.5 position in the Y of the ground
    }
    private void Jump()
    {
      
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            AudioManager.instance.playJump();
           
          
        } 
       
    }
    private void AnimePlayer()
    {
        Anime.SetBool("IsMoving", isMoving);
        
    }





}
