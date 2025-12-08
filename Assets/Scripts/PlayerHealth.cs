using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hitPoints = 100;
    public Image healthImage;  //reference to HealthBar

    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        UpdateHealthBar();  //update HealthBar at start
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
        UpdateHealthBar();  //update HealthBar each frame
        StartCoroutine(IsDamaged());
    }

    private void UpdateHealthBar()
    {
        if (healthImage != null)
        {
            healthImage.fillAmount = hitPoints / 100f;
        }
    }

    private IEnumerator IsDamaged()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    void Die()
    {
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
