using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; // reference ke rigidbody nya
    public float jumpForce; // kekuatan jump nya
    public GameObject gameOverUI; // reference ke gameover ui nya
    [SerializeField] private int score;
    [SerializeField] private int highscore;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighscore;
    private string HIGHSCOREKEYPREFS = "highscore";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // ambil rigidbody nya
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt(HIGHSCOREKEYPREFS); // load datanya dulu
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    private void PlayerJump()
    {
        // klik kiri mouse
        // Input.GetMouseButtonDown = pas diklik
        // Input.GetMouseButtonUp = pas klik dilepas
        // Input.GetMouseButton = pas di klik, di tahan, dan dilepas
        // 0 = kiri mouse
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.singleton.PlaySFX(2); // play jump 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle")) // kalau nyentuh obstacle
        {
            // maka mati
            PlayerLose();
        }
    }

    private void PlayerLose()
    {
        AudioManager.singleton.PlaySFX(1); // play hit / die 
        if (score > highscore)
        {
            highscore = score; // update highscore nya
            PlayerPrefs.SetInt(HIGHSCOREKEYPREFS, highscore); // simpen
        }
        textHighscore.text = $"Highscore : {highscore}"; // tampilin
        Time.timeScale = 0; // di pause gamenya
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // gak di pause lagi
        // load ke scene gamenya lagi
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score")) // kalau nyentuh collider score
        {
            AddScore(); // maka add score
        }
    }

    private void AddScore()
    {
        AudioManager.singleton.PlaySFX(0); // play scoring 
        score++; // tambahin scorenya
        textScore.text = $"Score : {score}"; // update ke ui nya
    }
}
