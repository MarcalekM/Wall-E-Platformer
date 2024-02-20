using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameManagerScript GameManager;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            GameManager.GameOver();
            player.SetActive(false);
        }
    }

    private void Update()
    {
        if (scoreText.text == "Trash: 13/13" || scoreText.text == "Trash: 15/15" || scoreText.text == "Trash: 21/21")
        {
            GameManager.Win();
            player.SetActive(false);
        }
    }
}
