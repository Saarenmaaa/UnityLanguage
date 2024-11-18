using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public int points = 0;
    private int highScore = 0; // For storing the high score
    public TextMeshProUGUI pointText; // Current score display
    public TextMeshProUGUI highScoreText; // High score display

    public float moveSpeed = 5f;

    private int currentPosition = 1; // Current position index (-1, 0, 1)
    private float[] positions = new float[] { -3f, 0f, 3f }; // Positions on the X-axis

    private Vector2 touchStartPos; // For tracking the start of a touch
    private float swipeThreshold = 50f; // Minimum swipe distance to trigger a move

    void Start()
    {
        // Load the high score at the start
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    void Update()
    {
        // Mobile swipe detection
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                float swipeDistance = touch.position.x - touchStartPos.x;

                if (Mathf.Abs(swipeDistance) > swipeThreshold)
                {
                    if (swipeDistance > 0)
                    {
                        MoveRight(); // Swipe Right
                    }
                    else
                    {
                        MoveLeft(); // Swipe Left
                    }
                }
            }
        }

        transform.position = new Vector3(positions[currentPosition], transform.position.y, transform.position.z);
    }

    void MoveLeft()
    {
        currentPosition--;
        if (currentPosition < 0) currentPosition = 0;
    }

    void MoveRight()
    {
        currentPosition++;
        if (currentPosition > 2) currentPosition = 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("correct"))
        {
            // Destroy the object
            Destroy(other.gameObject);
            points++;
            pointText.text = points.ToString();
            UpdateHighScore();
        }
        else if (other.CompareTag("incorrect"))
        {
            SaveHighScore(); // Save the high score before restarting
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateHighScore()
    {
        if (points > highScore)
        {
            highScore = points;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    private void SaveHighScore()
    {
        if (points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", points);
            PlayerPrefs.Save();
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
