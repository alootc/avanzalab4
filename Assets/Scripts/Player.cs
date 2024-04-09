using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int points;

    //[SerializeField] private Slider slider;

    [SerializeField] List<Color> colors;
    private int healthMax = 10;
    public string color = "";
    private bool isCollision;

    private SpriteRenderer spr;

    public static Action<float> onUpdateHealth;
    public static Action<int> onUpdatePoints;

    public static Action<bool> onGameOver;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor( string color)
    {
        if (isCollision) return;

        switch (color)
        {
            case "Red":
                spr.color = colors[0];
                break;
            case "Blue":
                spr.color = colors[0];
                break;
            case "Yellow":
                spr.color = colors[0];
                break;
        }

        this.color = color;
    }

    public void ChangeColor(Color c, string color)
    {
        if (isCollision) return;

        spr.color = c;
        this.color = color;
    }

    public void UpdateHeath(int valor)
    {
        health = Mathf.Clamp(health + valor, 0, healthMax);
        //slider.value = (float)health / (float)healthMax;

        float value = (float)health / (float)healthMax;
        onUpdateHealth?.Invoke(value);

        if (health <= 0)
            onGameOver?.Invoke(false);
    }

    public void Updatestaygame()
    {
        onUpdatePoints?.Invoke(points);

        if (points == 30)
            onGameOver?.Invoke(true);
    }

    //public void AddHealth()
    //{
    //    health = Mathf.Clamp(health + 2, 0, healthMax);

    //    float value = (float)health / (float)healthMax;
    //    onUpdateHealth?.Invoke(value);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
           {
                isCollision = true;

                if (obstacle.Color != color)
                   UpdateHeath(-1);

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isCollision = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            UpdateHeath(2);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            points += 10;
            onUpdatePoints?.Invoke(points);
            Destroy(collision.gameObject);

            Updatestaygame();
        }
    }
}
