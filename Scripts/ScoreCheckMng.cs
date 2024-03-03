using UnityEngine;

public class ScoreCheckMng : MonoBehaviour
{
    private BasketMng basket;

    private void Start()
    {
        basket = GetComponentInParent<BasketMng>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        basket.setScoreCheck(true);
    }
}
