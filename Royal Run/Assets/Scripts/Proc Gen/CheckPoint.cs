using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int checkPointTimeExstension = 5;

    GameManager gameManager;
    ScoreManager scoreManager;

    const string playerString = "Player";

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            gameManager.IncreaseTime(checkPointTimeExstension);
            scoreManager.IncreaseScore(checkPointTimeExstension);

        }
    }
}
