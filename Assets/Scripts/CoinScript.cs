using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //copper=1 point, silver=2 points, gold=3 points
    public int pointValue;
    public string coinType = "copper";
    private Animator coinRotator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinRotator = GetComponent<Animator>();
        CoinSetter(coinType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CoinSetter(string coinType)
    {
        if(coinType == "copper")
        {
            pointValue = 1;
            coinRotator.Play("Copper_Rotation");
        } else if (coinType == "silver")
        {
            pointValue = 2;
            coinRotator.Play("Silver_Rotation");
        } else
        {
            pointValue= 3;
            coinRotator.Play("Gold_Rotation");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().CollectCoins(pointValue);
            Destroy(gameObject);
        }
    }
}
