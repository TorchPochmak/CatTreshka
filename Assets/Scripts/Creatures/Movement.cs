using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{

    //тут физика чуть лучше будет, а то там совсем кринж был
    public abstract class Movement : MonoBehaviour
    {
        protected abstract void ComputeVelocity();
        protected float _gravityModifier = 1f;
        protected Rigidbody2D _thisRigidbody2D;

        public float ForwardForce { get; protected set; }
        public bool IsGrounded { get; protected set; }

        public virtual void Start()
        {
            _thisRigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            ComputeVelocity();//override
            AddPhysicsToVelocity();
        }
        protected virtual void MoveX(float direction, float speed, float smoothTime)
        {
            Vector3 vel = Vector3.zero;//бесполещно, только для SmoothDamp;

            Vector3 targetVelocity = new Vector3(direction * speed, _thisRigidbody2D.velocity.y);
            _thisRigidbody2D.velocity = Vector3.SmoothDamp(_thisRigidbody2D.velocity, targetVelocity, ref vel, smoothTime);
        }

        protected void Jump(float speed)
        {
            //_thisRigidbody2D.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
            //Второй прыжок здесь будет не оч
            _thisRigidbody2D.velocity = (new Vector3(_thisRigidbody2D.velocity.x, 1f * speed, 0));
            IsGrounded = false;
        }

        protected void Fly(Vector2 direction, float speed)
        {
            _thisRigidbody2D.AddForce(direction * speed, ForceMode2D.Force);
        }

        protected void Teleport(Vector2 position)
        {
            transform.position = position;
        }

        private void AddPhysicsToVelocity()
        {
            //Быстрее будет падать, но сомнительно, пока закомменчу

            //Vector2 velocity = _thisRigidbody2D.velocity;

            //if (velocity.y < 0)
            //{
            //    velocity += _gravityModifier * Physics2D.gravity * Time.fixedDeltaTime;
            //}
            //else
            //{
            //    velocity += Physics2D.gravity * Time.fixedDeltaTime;
            //}
            //Debug.Log(velocity);
            //_thisRigidbody2D.velocity = velocity;
        }
    }
}