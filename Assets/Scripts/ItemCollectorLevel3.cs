using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector3 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    public AudioClip sound;
    private int _score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            _score++;
            _scoreText.text = "Trash: " + _score + "/21";
            AudioSource.PlayClipAtPoint(sound, transform.position, 1);
        }
    }
}
