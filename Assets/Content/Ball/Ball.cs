using UniRx;
using UnityEngine;

namespace SpacePortals
{
    public partial class Ball : MonoBehaviour, IEnterInPortals
    {
        public const float MAX_VELOCITY = 20f;
        public const float MIN_VELOCITY = 1f;

        public const float MAX_SCALE = 3f;
        public const float MIN_SCALE = 0.3f;

        [Range(MIN_VELOCITY, MAX_VELOCITY)]
        [SerializeField] private float _velocity = 5;

        [Space]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private ParticleSystem _destroyEffect;

        private bool _isTransformInPortal = false;

        private Rigidbody2D _rigidbody2D;

        public Sprite BallSprite => _spriteRenderer.sprite;
        public bool IsTransformInPortal => _isTransformInPortal;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public float Velocity
        {
            get { return _velocity; }
            set
            {
                if (value < MIN_VELOCITY || value > MAX_VELOCITY)
                    return;

                _velocity = value;
            }
        }
        public float Scale
        {
            get { return transform.localScale.x; }
            set
            {
                if (value < MIN_SCALE || value > MAX_SCALE)
                    return;

                transform.localScale = new Vector3(value, value, value);
            }
        }

        public ReactiveCommand OnDestroy = new();

        public void Awake()
            => _rigidbody2D = GetComponent<Rigidbody2D>();

        public void FixedUpdate()
            => RigidbodyVelocityContoll();

        public void ActionInEnter()
        {
            _isTransformInPortal = true;
            _rigidbody2D.isKinematic = true;
        }
        public void ActionInExit()
        {
            _isTransformInPortal = false;
            _rigidbody2D.isKinematic = false;
            ResetTrail();
        }

        public void Destroy()
        {
            OnDestroy.Execute();

            Instantiate(_destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void ResetTrail()
            => _trailRenderer.Clear();

        private void RigidbodyVelocityContoll()
            => _rigidbody2D.velocity = Vector3.ClampMagnitude(_rigidbody2D.velocity, Velocity);
    }
}