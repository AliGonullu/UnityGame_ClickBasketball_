using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 11f, firstMoveSpeed = 1.5f, moveSpeed, firstGravityScale;
    private Vector2 moveDir = Vector2.right;
    private int scoreMtp = 1;
    private TextMeshProUGUI scoreMtpText;
    [SerializeField] private TextMeshProUGUI lifeText;
    private int life = 3;

    public int getScoreMtp()
    {
        return scoreMtp;        
    }

    public void setScoreMtp(int _scoreMtp)
    {
        scoreMtp = _scoreMtp;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public void setMoveSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }

    void Start()
    {
        scoreMtpText = GetComponentInChildren<TextMeshProUGUI>();
        moveSpeed = firstMoveSpeed;
        rb = GetComponent<Rigidbody2D>();
        firstGravityScale = rb.gravityScale;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))       
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        if (transform.position.x >= 2.45f)
            moveDir = Vector2.left;
        else if (transform.position.x <= -2.45f)
            moveDir = Vector2.right;

        rb.velocity = new Vector2(moveDir.x * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Edge"))
        {
            if(rb.velocity.x > 0)
            {
                moveDir.x = 1;
            }
            else
            {
                moveDir.x = -1;
            }
        }
                    
        if (collision.gameObject.tag.Equals("Ground"))
        {
            rb.gravityScale = firstGravityScale;
            moveSpeed = firstMoveSpeed;
            scoreMtp = 1;
            scoreMtpText.text = scoreMtp.ToString();
            life -= 1;
            lifeText.text = "x" + life.ToString();
            if (life <= 0)
            {
                Destroy(gameObject);
            }       
        }
    }
}
