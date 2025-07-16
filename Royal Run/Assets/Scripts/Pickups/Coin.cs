using UnityEngine;

public class Coin : PickUp
{
    protected override void OnPickUp()
    {
        Debug.Log("Add 100 points");
    }
}
