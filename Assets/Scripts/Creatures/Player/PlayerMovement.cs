using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace CatTreshka {
    public class PlayerMovement : Movement
    {
        public float SmoothTime = 0.01f;
        public float JumpForce = 7f;
        public int MaxJumps = 2;//Больше не поддерживает, можно потом починить
        public float Speed = 5f;
        public float JumpDelay = 0.1f;

        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private Transform _leftCornerGroundCheck;
        [SerializeField] private Transform _rightCornerGroundCheck;

        public UnityEvent PlayerJumped;

        [SerializeField] private int _jumpsLeft = 2;

        private bool _isJumpAllowed = true;
        
        public bool IsJumpPressed = false;


        private void Update()
        {
            GetInput();
            
            if (IsJumpPressed)
            {
                PlayerJumped.Invoke();
                _jumpsLeft--;
                Jump(JumpForce);
                IsGrounded = false;
                _isJumpAllowed = false;
                StartCoroutine(JumpDel());
            }
            
        }
        private void GetInput()
        {
            ForwardForce = Input.GetAxisRaw("Horizontal");
            if (
                   (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && 
                   (
                        (_jumpsLeft == 1) || (_jumpsLeft == 2 && IsGrounded)
                   )
               )
            {
                IsJumpPressed = true;
            }
            else
            {
                IsJumpPressed = false;
            }
        }

        protected override void ComputeVelocity()//FixedUpdate
        {
            if (_isJumpAllowed)
            {
                IsGrounded = Physics2D.OverlapArea(_rightCornerGroundCheck.position, _leftCornerGroundCheck.position, _whatIsGround);
                if (IsGrounded)
                {
                    _jumpsLeft = MaxJumps;
                }
            }
            MoveX(ForwardForce, Speed, SmoothTime);

        }
        private IEnumerator JumpDel()
        {
            _isJumpAllowed = false;
            yield return new WaitForSecondsRealtime(JumpDelay);
            _isJumpAllowed = true;
        }
    }
}
