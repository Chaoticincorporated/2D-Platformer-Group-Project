using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int hitPoints = 100;

    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        StartCoroutine(IsDamaged());
    }
    private IEnumerator IsDamaged()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    void Die()
    {
        SceneManager.LoadScene("MainScene");
    }
}
