using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    //Скрипт для Аудио и Анимации, надо бы переименовать, но мне лень
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        [SerializeField] private AudioSource _moveAudio;
        
        private SpriteRenderer _sprite;

        private Animator _animator;
        private Rigidbody2D _thisRigidbody2D;

        public bool IsJumping = false;
        public bool IsFliped = false;


        private void Awake()
        {
            Singletons.CatPlayer = this.gameObject;
        }
        void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _playerMovement = GetComponent<PlayerMovement>();
            _thisRigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }


        private void Update()
        {
            float x = _playerMovement.ForwardForce;

            AudioMove();
            AnimationMovement(x);
        }
        private void AudioMove()
        {
            if (_playerMovement.IsGrounded && _thisRigidbody2D.velocity.x != 0)
            {
                if (!_moveAudio.isPlaying) _moveAudio.Play();
            }
            else
            {
                if (_moveAudio.isPlaying) _moveAudio.Stop();
            }
        }

        private void AnimationMovement(float x)
        {
            if (x < 0 && IsFliped || x > 0 && !IsFliped) Flip();
            if (x != 0) _animator.SetBool("isRunning", true);
            else _animator.SetBool("isRunning", false);

            if (_playerMovement.IsGrounded && landed_allowed)
                _animator.SetBool("isLanded", true);
            else
            {
                _animator.SetBool("isLanded", false);
            }
        }
        public void Jump()//Подписаться на PlayerMovement;
        {
            StartCoroutine(MiniDelay());
            _animator.SetTrigger("isJump");
        }
        public void Flip()
        {
            IsFliped = !IsFliped;
            _sprite.flipX = !_sprite.flipX;
        }
        bool landed_allowed = true;
        private IEnumerator MiniDelay()
        {
            landed_allowed = false;
            yield return new WaitForEndOfFrame();

            landed_allowed = true;
        }

    }
}