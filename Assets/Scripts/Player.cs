using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int idPlayer;
    [SerializeField] public float playerSpeed;

    [SerializeField] private Transform gunPoint;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private Rigidbody2D rb;

    public int Health = 100;
    public int maxHealth = 100;
    public float reloadTime = 5;
    public float reloadedTime = 5;

    public GameManager gameManager;
    public Rigidbody2D bullet;

    public bool isGrounded = false;

    private void Update()
    {
        if (gameManager.gameIsGoing)
        {
            if(reloadedTime < reloadTime)
            {
                reloadedTime += 1*Time.deltaTime;
            }
            if(reloadedTime > reloadTime) reloadedTime = reloadTime;

            if (idPlayer == 1)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (Input.GetKey(KeyCode.W) && isGrounded)
                {
                    rb.AddForce(new Vector2(0, 40));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if(reloadedTime == reloadTime)
                    {
                        if(transform.rotation.y == 0)
                        {
                            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation) as Rigidbody2D;
                            clone.velocity = transform.TransformDirection(gunPoint.right * 50);
                            clone.transform.right = gunPoint.right;
                            reloadedTime = 0;
                        }
                        else
                        {
                            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, transform.rotation) as Rigidbody2D;
                            clone.velocity = transform.TransformDirection(gunPoint.right * -50);
                            clone.transform.right = gunPoint.right;
                            reloadedTime = 0;
                        }
                    }
                }
            }
            if (idPlayer == 2)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
                {
                    rb.AddForce(new Vector2(0, 40));
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (reloadedTime == reloadTime)
                    {
                        if (transform.rotation.y == 0)
                        {
                            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation) as Rigidbody2D;
                            clone.velocity = transform.TransformDirection(gunPoint.right * -50);
                            clone.transform.right = gunPoint.right;
                            reloadedTime = 0;
                        }
                        else
                        {
                            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, transform.rotation) as Rigidbody2D;
                            clone.velocity = transform.TransformDirection(gunPoint.right * 50);
                            clone.transform.right = gunPoint.right;
                            reloadedTime = 0;
                        }
                    }
                }
            }
            if (Health < 0) Health = 0;
            if (Health == 0) { if (idPlayer == 1) gameManager.p2wins += 1; else gameManager.p1wins += 1; gameManager.gameIsGoing = false; }
        }
        if (!gameManager.gameIsGoing)
        {
            transform.position = spawnPoint.position;
            if (idPlayer == 1)gameManager.p2wins += 1;
            else gameManager.p1wins += 1;
            Health = 100;
            gameManager.gameIsGoing = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Map" || collision.gameObject.tag == "Player")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Map" || collision.gameObject.tag == "Player")
        {
            isGrounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jumppad") { rb.AddForce(new Vector2(0, 100)); }
    }
}