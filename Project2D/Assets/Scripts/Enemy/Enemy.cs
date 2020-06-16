using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
   
    [SerializeField]
    protected int Health;
    //public int _Health { get { return Health; } set { Health = value; } }
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int germs ;
    [SerializeField]
    protected Transform PointA, PointB;
    [SerializeField]
    protected SpriteRenderer SpriteRenderer;
    protected Vector3 TargetPosition;
    protected Animator Animator;
    protected bool IsHit = false;
    protected Player player;
    protected bool IsDead = false;
    [SerializeField]
    protected AudioClip WalkingSound;
    [SerializeField]
    protected AudioClip AttackSound;
    [SerializeField]
    protected AudioClip HitSound;
    [SerializeField]
    protected AudioClip DeadSound;
    [SerializeField]
    protected AudioSource EmenySoundEffect;

    // Start is called before the first frame update
    public virtual void Init()
    {
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        EmenySoundEffect = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Idel") && Animator.GetBool("IsCombat") == false)
        {
            return;
        }
        if (IsDead == false)
        {
            Movement();
            

        }
    }
    public virtual void Movement()              
    {
        if (TargetPosition == PointA.position)
        {
            SpriteRenderer.flipX = true;
            
        }
        else
        {
            SpriteRenderer.flipX = false;
           
        }

        if (transform.position == PointA.position)
        {
            TargetPosition = PointB.position;
            Animator.SetTrigger("IsIdel");

        }
        if (transform.position == PointB.position)
        {
            TargetPosition = PointA.position;
            Animator.SetTrigger("IsIdel");

        }
        if (IsHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed);
        }
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(distance>2.0f)
        {
            IsHit = false;
            EmenySoundEffect.clip = WalkingSound;
            EmenySoundEffect.Play();
            Animator.SetBool("IsCombat", false);    
        }

        Vector3 Playerdirection = player.transform.localPosition - transform.localPosition;
        if (Playerdirection.x > 0 && Animator.GetBool("IsCombat") == true)
            SpriteRenderer.flipX = false;
        if (Playerdirection.x < 0 && Animator.GetBool("IsCombat") == true)
            SpriteRenderer.flipX = true;
    }
    public void WalkingSoundEffect()
    {
        EmenySoundEffect.clip = WalkingSound;
        EmenySoundEffect.Play();
    }
    public void EnemyAttackSound()
    {
        EmenySoundEffect.clip = AttackSound;

        EmenySoundEffect.Play();
    }
  
    public void EnemyHitSound()
    {
        EmenySoundEffect.clip = HitSound;
        EmenySoundEffect.Play();
    }
    public void EnemyDeadSound()
    {
        EmenySoundEffect.clip = DeadSound;
        EmenySoundEffect.Play();
    }

}


