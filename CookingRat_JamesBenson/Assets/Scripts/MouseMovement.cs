using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    // private float _directionx = 0.0f;
    // private float _directiony = 0.0f;
    
    [Header("Movement")]
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    SpriteRenderer _spriteRenderer;
    bool _facingRight = true;

    [Header("Directions")]
    [SerializeField] private KeyCode _jump = KeyCode.UpArrow;
    [SerializeField] private KeyCode _down = KeyCode.DownArrow;
    [SerializeField] private KeyCode _shoot = KeyCode.Space;
    
    [Header("Laser")] //still in the works
    [SerializeField] private float _laserSpeed = 10.0f;

    [HideInInspector] public bool CanShoot = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        // _rb.linearVelocityX = _directionx * _speed;
        // _rb.linearVelocityY = _directiony * _speed;
    }

    void Update()
    {
        // _directionx = 0.0f;
        // _directiony = 0.0f;

        if (GameBehavior.Instance.State == Utilities.GameState.Play)
        { 
            float deltaX = Input.GetAxis("Horizontal") * _speed;

            if ((deltaX > 0 && !_facingRight) || (deltaX < 0 && _facingRight))
            { 
                Flip(); 
            }
            Vector2 movement = new(deltaX, _rb.linearVelocity.y);
           _rb.linearVelocity = movement;

           Vector3 min = _collider.bounds.min;
           Vector3 max = _collider.bounds.max;

           float groundDetectionOffset = 0.2f;
           Vector2 corner1 = new(min.x, min.y - groundDetectionOffset); //Bottom left
           Vector2 corner2 = new(max.x, min.y + groundDetectionOffset); //Bottom right
           
           //if my corners overlap with ground, then I can jump :)
           Collider2D groundCollision = Physics2D.OverlapArea(corner1, corner2);

           bool grounded = groundCollision != null;

           if (grounded && Input.GetKeyDown(_jump))
           {
               _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
           }

           void Flip()
           {
               _facingRight = !_facingRight;
               _spriteRenderer.flipX = !_spriteRenderer.flipX;
               transform.Rotate(0f, 180f, 0f);
           }
           
           //insert CanShoot code with shoot key for player shooting
        }

        
    }
}
