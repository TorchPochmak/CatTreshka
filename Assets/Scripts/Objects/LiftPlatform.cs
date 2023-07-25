using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CatTreshka
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LiftPlatform : MonoBehaviour
    {
        public GameObject platformPathStart;
        public GameObject platformPathEnd;
        public int speed;

        [SerializeField] private Vector2 startPosition;
        [SerializeField] private Vector2 endPosition;
        private Rigidbody2D rBody;

        void Start()
        {
            rBody = GetComponent<Rigidbody2D>();
            startPosition = platformPathStart.transform.position;
            endPosition = platformPathEnd.transform.position;
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }

        void Update()
        {
            if (rBody.position == endPosition)
            {
                StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
            }
            if (rBody.position == startPosition)
            {
                StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
            }
        }

        IEnumerator Vector3LerpCoroutine(GameObject obj, Vector2 target, float speed)
        {
            Vector2 startPosition = obj.transform.position;
            float time = 0f;

            while (rBody.position != target)
            {
                obj.transform.position = Vector2.Lerp(startPosition, target, (time / Vector2.Distance(startPosition, target)) * speed);
                time += Time.deltaTime;
                yield return null;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Singletons.CatPlayer.transform.SetParent(gameObject.transform, true);
        }

        void OnCollisionExit2D(Collision2D col)
        {
            Singletons.CatPlayer.transform.transform.parent = null;
        }

    }
}