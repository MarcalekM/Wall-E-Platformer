using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private ParticleSystem _pickupEffect;
    public AudioClip sound;
    private int _score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            _score++;
            _scoreText.text = "Trash: " + _score + "/13";
            AudioSource.PlayClipAtPoint(sound, transform.position,1);
            Instantiate(_pickupEffect, collision.transform.position, Quaternion.identity);
        }
    }
}
