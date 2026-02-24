using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
[SerializeField] float spamRate;
bool gameStarted = false;
Vector2 screenPos;
[SerializeField] TextMeshProUGUI scoreText;
public GameObject tapText;
private Player player;
    
    void Start() 
    {
        player = FindObjectOfType<Player>();
    }
    
    void SpawnEnemy()
    {
        float randomX = Random.Range(0f, 1f);

        Vector2 viewportPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);

        Instantiate(enemyPrefab, worldPos, Quaternion.identity);

        player.myPlayerHS.ChangeScore(1);

        UpdateText(player.myPlayerHS.GetScore());
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, spamRate);
    }

    void Update()
    {
        if (transform.GetComponent<inputSys>().IsPressing(out screenPos) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true; 
            tapText.SetActive(false);
        }
        
    }

    void UpdateText(int score)
    {
        scoreText.text = score.ToString(); 
    }
}
