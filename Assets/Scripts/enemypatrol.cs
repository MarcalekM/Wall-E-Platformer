using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 6f;
    public float range = 3;
    public float knockbackForce = 10f;
    private float startingX;
    private float initialScaleX;
    private int direction = 1;

    void Start()
    {
        startingX = transform.position.x;
        initialScaleX = transform.localScale.x;
    }

    void Update()
    {
        // Mozgatjuk az objektumot az új irányba
        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

        // Ellenőrizzük, hogy az objektum elérte-e a határt, és ha igen, változtatjuk az irányt és forgatjuk a sprite-ot
        if (transform.position.x < startingX || transform.position.x > startingX + range)
        {
            direction *= -1;
            FlipSprite();
        }

        // Ellenőrizzük, hogy a karakter nem mozdult ki a megengedett tartományból
        ClampCharacterPosition();
    }

    void FlipSprite()
    {
        // Forgatjuk a sprite-ot
        transform.localScale = new Vector3(initialScaleX * direction, transform.localScale.y, transform.localScale.z);

        // Ellenőrizzük, hogy a karakter nem mozdult ki a megengedett tartományból
        ClampCharacterPosition();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ellenőrizzük, hogy az ütközött objektum rendelkezik-e a PlayerMovement komponenssel
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            Rigidbody2D playerRb = playerMovement.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // A knockback számítása és alkalmazása a játékos objektumra
                Vector2 knockbackDirection = new Vector2(direction, 1).normalized;
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0); // Reseteljük az aktuális y sebességet
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }

    void ClampCharacterPosition()
    {
        // Korrigáljuk a karakter pozícióját, hogy ne mozduljon ki a megengedett tartományból
        float clampedX = Mathf.Clamp(transform.position.x, startingX, startingX + range);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}