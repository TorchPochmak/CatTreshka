using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class Player : MonoBehaviour
    {

        public AudioSource MoveAudio;

        [SerializeField] private SpriteRenderer sprite;
        public Transform RightGround;
        public Transform LeftGround;
        public LayerMask groundLayer;

        protected Transform position;
        protected Animator animator;
        protected Rigidbody2D physicShape;

        public int maxJumps = 2;
        public int jumpsLeft = 2;

        public float jumpPower = 2f;
        public float movementSpeed = 2f;

        public bool isJumping = false;
        public bool isFliped = false;

        private bool isGrounded;

        private void Awake()
        {
            Singletons.CatPlayer = this.gameObject;
        }
        void Start()
        {
            MoveAudio = this.GetComponent<AudioSource>();
            position = GetComponent<Transform>();
            animator = GetComponent<Animator>();
            physicShape = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            float x = Input.GetAxis("Horizontal"),
                  y = Input.GetAxis("Vertical");

            AudioMove();
            AnimationMovement(new float[] { x, y });
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && ((jumpsLeft == 1) || (jumpsLeft == 2 && isGrounded)))
            {
                Jump();
            }
            physicShape.velocity = (new Vector3(x * movementSpeed, physicShape.velocity.y, 0));
        }


        private bool isPlayed = false;
        private void AudioMove()
        {
            if(isGrounded && physicShape.velocity.x != 0)
            {
                if (!MoveAudio.isPlaying) MoveAudio.Play();
            }
            else
            {
                if(MoveAudio.isPlaying) MoveAudio.Stop();
            }
        }

        /// <summary>
        /// Производит все необходимые анимации
        /// </summary>
        /// <param name="ways"></param>
        private void AnimationMovement(float[] ways)
        {
            float x = ways[0], y = ways[1];
            if (x < 0 && isFliped || x > 0 && !isFliped) Flip();
            if (x != 0) animator.SetBool("isRunning", true);
            else animator.SetBool("isRunning", false);
        }
        private void FixedUpdate()
        {
            if (physicShape.velocity.y <= 0)
            {
                isGrounded = Physics2D.OverlapArea(RightGround.position, LeftGround.position, groundLayer);
            }
            else
            {
                isGrounded = false;
            }

            if (isGrounded)
            {
                jumpsLeft = maxJumps;
            }

            if (isGrounded)
                animator.SetBool("isLanded", true);
            else
                animator.SetBool("isLanded", false);

        }
        protected void Jump()
        {
            Debug.Log(jumpsLeft);
            jumpsLeft--;
            animator.SetTrigger("isJump");
            physicShape.velocity = (new Vector3(physicShape.velocity.x, 1f * jumpPower, 0));

        }
        protected void Flip()
        {
            isFliped = !isFliped;
            position.localScale = new Vector3(-position.localScale.x, position.localScale.y, 0);
        }

    }
}