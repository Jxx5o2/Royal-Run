using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    const string playerString = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            OnPickUp();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickUp();
}
