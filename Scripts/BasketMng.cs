using UnityEngine;

public class BasketMng : MonoBehaviour
{
    private static bool scoreCheck = false;
    private static int score = 0;
    private Vector2 nextPos = Vector2.zero;

    public void setScore(int _score)
    {
        score = _score;
        nextPos = transform.position;
        nextPos.y += (int)Random.Range(1f, 2f);
        nextPos.y = nextPos.y % 4f;
        transform.position = nextPos;
    }

    public void setScoreCheck(bool _score_check)
    {
        scoreCheck = _score_check;
    }

    public bool getScoreCheck()
    {
        return scoreCheck;
    }

    public int getScore()
    {
        return score;
    }
}
