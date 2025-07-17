using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkPointTimeExstension = 5f;

    GameManager gameManager;

    const string playerString = "player";

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            gameManager.IncreaseTime(checkPointTimeExstension);
        }
    }
}
