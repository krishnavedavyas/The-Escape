using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour,IDamageAble
{
    public int Health { get; set; }
    public int diamond;
    bool IsDead = false;
    Rigidbody2D Rigidbody;
    bool IsGrounded = false;
    [SerializeField]
    float JumpForce = 5.0f;
    [SerializeField]
    float RayCastLength = 1f;
    [SerializeField]
    LayerMask Floor;
    [SerializeField]
    float speed =1f;
    //bool resetJumpNeeded = false;
    [SerializeField]
    protected SpriteRenderer SpriteRenderer;
    float KeyInputs;
   [SerializeField]
    int playerHealth;
      Animator Animator;
    [SerializeField]
    Animator Sword_Animation;
    [SerializeField]
    SpriteRenderer Sword_SpriteRenderer;
   
    [SerializeField]
    protected AudioClip AttackSword;
    [SerializeField]
    protected AudioClip AttackSwordfire;
    [SerializeField]
    protected AudioClip HitSound;
    [SerializeField]
    protected AudioClip DeadSound;
    [SerializeField]
    protected AudioClip JumpSound;
    [SerializeField]
    protected AudioSource PlayerAudio;
    //public Vector2 KeyInputs;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        playerHealth = Health;
        playerHealth = 8;
   
    }
    void jump()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, RayCastLength, Floor);
        Debug.DrawRay(transform.position, Vector2.down * RayCastLength, Color.blue);
        if (hitInfo.collider != null)
        {
           
        IsGrounded = true;
       
            Animator.SetBool("IsJump", false);
           
        }

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButton("Jump")) && IsGrounded == true)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpForce);
            Animator.SetBool("IsJump", true);
            IsGrounded = false;
            
        }
        
       
    }
    void Movement()
    {
        float KeyInputs = CrossPlatformInputManager.GetAxis("move");
        
        
        Rigidbody.velocity = new Vector2(KeyInputs * speed, Rigidbody.velocity.y) ;

        if (KeyInputs > 0f && IsGrounded == true )
        {  
            Animator.SetBool("Ismove", true);
            SpriteRenderer.flipX = false;
            Sword_SpriteRenderer.flipX = false;
        }
        else if (KeyInputs < 0f && IsGrounded == true )
        {
            Animator.SetBool("Ismove", true);
            SpriteRenderer.flipX = true;
            Sword_SpriteRenderer.flipX = true;
        }
        else
        {
            Animator.SetBool("Ismove", false);
        }

    }
    void Attack()
    {
        if (CrossPlatformInputManager.GetButton("Attack") && IsGrounded == true)
        {
            Animator.SetTrigger("IsAttack");
            Sword_Animation.SetTrigger("Sword_Ani");
        }
    } 
   public void Damage()
    { 
        if(playerHealth < 1)
        {
            return;
           
        }
        playerHealth--;
        Animator.SetTrigger("IsHit");
       
        UIManager.Instance.UpdateLifes(playerHealth);
        if(playerHealth < 1)
        {
            Animator.SetTrigger("Dead");
            IsDead = true;
            Invoke("DisableAnimation", 1f);
            StartCoroutine(waIt());
            SceneManager.LoadScene(2);
        }

    }
    public void UPdateGermCount(int count)
    {
        diamond += count;
        UIManager.Instance.GermCount(diamond);
    }
    void DisableAnimation()
    {
        Animator.enabled = false;
    }
   
    public void PlayerAttackSound()
    {
        PlayerAudio.clip = AttackSword;
        PlayerAudio.clip = AttackSwordfire;
        PlayerAudio.Play();
    }
    public void PlayerjumpSound()
    {
        PlayerAudio.clip = JumpSound;
        PlayerAudio.Play();
    }
    public void PlayerHitSound()
    {
        PlayerAudio.clip = HitSound;
        PlayerAudio.Play();
    }
    public void PlayerDeadSound()
    {
        PlayerAudio.clip = DeadSound;
        PlayerAudio.Play();
    }

    void Update()
    {
         if(IsDead == false) { 
        
            Movement();
            jump();
            Attack();
        }
    }

    IEnumerator waIt()
    {
        yield return new WaitForSeconds(60f);
    }
}
