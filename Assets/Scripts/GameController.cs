using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject UIGameOver;
    public GameObject UIFinish;
    public Text finishScoreText;
    public Text scoreText;
    public Text clickToSmashText;
    public Text levelText;
    public float fadeInSpeed = 1.5f;
    public bool fadeInComplete = false;
    private PlayerController player;
    private Levelling lv;

    void Awake()
    {
        lv = FindObjectOfType<Levelling>();
        player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        if (UIGameOver != null)
        {
            UIGameOver.SetActive(false);
        }

        if (UIFinish != null)
        {
            UIFinish.SetActive(false);
        }

        ShowClickToSmashText();
    }

    void Update()
    {
        UpdateScoreText();
    }

    void ShowClickToSmashText()
    {
        clickToSmashText.gameObject.SetActive(true);
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
        Color originalColor = clickToSmashText.color;
        float timer = 0f;

        while (timer < 1f)
        {
            timer += Time.deltaTime * fadeInSpeed;
            clickToSmashText.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1f, 0f, timer));
            yield return null;
        }

        fadeInComplete = true;
        clickToSmashText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        UIGameOver.SetActive(true);
    }

    public void GameFinish()
    {
        UIFinish.SetActive(true);
    }

    private void UpdateScoreText()
    {
        if (scoreText != null && player != null)
        {
            scoreText.text = "Score: " + player.GetScore().ToString();
        }

        finishScoreText.text = "Score: " + player.GetScore().ToString();
    }

    public void ReplayGame()
    {
        lv.level = 1;
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
