using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
    public class AngryGlitch : MonoBehaviour
    {

        [SerializeField] private Transform leftBorder;
        [SerializeField] private Transform rightBorder;

        [SerializeField] private float movementSpeed;

        //ќбозначить изначальное направление
        [SerializeField] private Direction direction;

        private void Update()
        {
            //”перс€ в левую стенку
            if(transform.position.x <= leftBorder.position.x && direction == Direction.Left)
            {
                Flip();
            }
            //”перс€ в левую стенку
            else if(transform.position.x >= rightBorder.position.x && direction == Direction.Right)
            {
                Flip();
            }
            else
            {
                if(direction == Direction.Left)
                {
                    transform.Translate(-transform.right * movementSpeed * Time.deltaTime);
                }
                else if(direction == Direction.Right)
                {
                    transform.Translate(transform.right * movementSpeed * Time.deltaTime);
                }
            }
        }
        
        private void Flip()
        {
            if (direction == Direction.Right) 
                direction = Direction.Left;
            else 
                direction = Direction.Right;

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
        }
    }
}
