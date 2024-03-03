using TMPro;
using UnityEngine;

public class ScoreMng : MonoBehaviour
{
    private BasketMng basket;
    [SerializeField] private TextMeshProUGUI scoreText, scoreMtpText;

    void Start()
    {
        basket = GetComponentInParent<BasketMng>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (basket.getScoreCheck())
        {
            basket.setScoreCheck(false);
            var ball = collision.gameObject.GetComponent<BallMovement>();
            basket.setScore(basket.getScore() + ball.getScoreMtp());
            if(ball.getScoreMtp() < 5)
            {
                ball.setScoreMtp(ball.getScoreMtp() + 1);
            }            
            ball.setMoveSpeed(ball.getMoveSpeed() + 0.1f);
            ball.GetComponent<Rigidbody2D>().gravityScale += 0.1f;

            scoreText.text = basket.getScore().ToString();
            scoreMtpText.text = ball.getScoreMtp().ToString();          
        }     
    }
}
