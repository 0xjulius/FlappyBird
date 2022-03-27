using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; //luodaan linnulle lentoasentojen renderöinti
    public Sprite[] sprites; //luodaan linnulle sprites-taulukko
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable() //aloitus positio
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //controllit
        {
            direction = Vector3.up * strength;
            SoundManager.PlaySound("fly");
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        Quaternion rot = transform.rotation; //linnun kulma muuttuu hyppiessä
        if (direction.y > 0)
        {
            rot.z = direction.y * 0.02f;
            transform.rotation = rot;
        }
        else
        {
            rot.z = direction.y * 0.05f;
            transform.rotation = rot;
        }
    }

    private void AnimateSprite() //animoidaan linnulle lentoasennot
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}