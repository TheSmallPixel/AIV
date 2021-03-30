using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SimplePlayer>() == null)
            return;

        //MainMenu.mainMenu.GetComponent<ScoreManager>().AddPoints(pointsToAdd);

        Destroy(gameObject);
    }
}
