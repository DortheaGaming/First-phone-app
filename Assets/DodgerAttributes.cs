using UnityEngine;

public class DodgerAttributes
{
    private int Health;
    private int maxHealth;
    private int Score;

    public DodgerAttributes(int currentHealth, int currMaxHealth, int currentScore)
    {
        Health = currentHealth;
        maxHealth = currMaxHealth;
        Score = currentScore;
    } 

    public void ChangeHealth(int HealthEffect)
    {
        Health += HealthEffect;

        if (Health > maxHealth) 
        {
           Health = maxHealth;
        }

        if (Health < 0) 
        {
            Health = 0;
        }
    }

    public void ChangeScore(int ScoreEffect) 
    {
        Score += ScoreEffect;
    }

    public void ChangeMaxHealth(int MaxHealthEffect) 
    {
        maxHealth += MaxHealthEffect;
    }

    public int GetHealth()
    {
        return Health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetScore()
    {
        return Score;
    }

}
