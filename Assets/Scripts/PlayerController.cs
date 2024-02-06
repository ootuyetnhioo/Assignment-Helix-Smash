using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float overpowerBuildUp;
    [SerializeField] private bool isClicked, isOverPowered;
    [SerializeField] private float moveSpeed = 500f;
    private float speedLimit = 30f;
    [SerializeField] private float bounceSpeed = 480f;
    public GameObject fireEffect;
    public GameObject breakEffectPrefab;
    private int count;
    private int score;

    public AudioSource audioSource;
    public AudioClip bounceSound;

    public enum PlayerState
    {
        Prepare,
        Play,
        Dead,
        Finish
    }
    public PlayerState _state = PlayerState.Prepare;

    public GameController gameController;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();
        count = 0;
        score = 0;
        overpowerBuildUp = 0f;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        audioSource.enabled = false;
        StartCoroutine(StartLevelText());
    }

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Prepare:
                break;
            case PlayerState.Play:
                ClickCheck();
                OverpowerCheck();
                break;
            case PlayerState.Dead:
                break;
            case PlayerState.Finish:
                break;
        }
    }

    void FixedUpdate()
    {
        BallMovement();
    }

    private void BallMovement()
    {
        if (_state == PlayerState.Play)
        {
            if (isClicked)
            {
                rb.velocity = new Vector3(0, -moveSpeed * Time.smoothDeltaTime, 0);
            }
        }

        if (rb.velocity.y > speedLimit)
        {
            rb.velocity = new Vector3(rb.velocity.x, speedLimit, rb.velocity.z);
        }
    }

    public void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if (!isClicked)
        {
            rb.velocity = new Vector3(0, bounceSpeed * Time.fixedDeltaTime, 0);
            Physics.gravity = new Vector3(0, -50, 0);
            _state = PlayerState.Play;
        }
        else
        {
            if (isOverPowered)
            {
                if (target != null && (target.gameObject.tag == "GoodPart" || target.gameObject.tag == "BadPart"))
                {
                    target.transform.parent.GetComponent<CircutController>().BreakAllCircuts();
                }
            }
            else
            {
                if (target != null)
                {
                    if (target.gameObject.tag == "GoodPart")
                    {
                        target.transform.parent.GetComponent<CircutController>().BreakAllCircuts();
                        if (count == 0)
                        {
                            count++;
                        }
                        score++;
                        audioSource.enabled = true;
                        if (audioSource != null && bounceSound != null)
                        {
                            audioSource.PlayOneShot(bounceSound);
                        }
                    }
                    if (target.gameObject.tag == "BadPart")
                    {
                        HandleGameOver();
                        Destroy(gameObject);
                    }
                }
            }
        }

        if (target != null && target.gameObject.CompareTag("WinLocation") && _state == PlayerState.Play)
        {
            gameController.GameFinish();
            ChangeState(PlayerState.Finish);
        }
    }

    void HandleGameOver()
    {
        GameObject breakEffect = Instantiate(breakEffectPrefab, transform.position, Quaternion.identity);
        breakEffect.transform.parent = transform;

        transform.GetChild(0).gameObject.SetActive(false);

        gameController.GameOver();
        ChangeState(PlayerState.Dead);
    }

    public int GetScore()
    {
        return score;
    }

    void OverpowerCheck()
    {
        if (isOverPowered)
        {
            overpowerBuildUp -= Time.deltaTime * 0.5f;
            if (!fireEffect.activeInHierarchy)
                fireEffect.SetActive(true);
        }
        else
        {
            if (fireEffect.activeInHierarchy)
                fireEffect.SetActive(false);
            if (isClicked)
                overpowerBuildUp += Time.deltaTime * 0.8f;
            else
                overpowerBuildUp -= Time.deltaTime * 0.5f;
        }

        if (overpowerBuildUp >= 1)
        {
            overpowerBuildUp = 1;
            isOverPowered = true;
        }
        else if (overpowerBuildUp <= 0)
        {
            overpowerBuildUp = 0;
            isOverPowered = false;
        }
    }

    private void ChangeState(PlayerState newstate)
    {
        if (newstate == _state) return;
        ExitCurrentState();
        _state = newstate;
        EnterNewState();
    }

    IEnumerator StartLevelText()
    {
        if (gameController != null && gameController.clickToSmashText != null)
        {
            gameController.clickToSmashText.gameObject.SetActive(true);
            gameController.clickToSmashText.text = "Click to smash";

            yield return new WaitForSeconds(2f);

            if (gameController.fadeInComplete)
            {
                gameController.clickToSmashText.gameObject.SetActive(false);
            }
        }
    }

    private void EnterNewState()
    {
        switch (_state)
        {
            case PlayerState.Prepare:
                break;
            case PlayerState.Play:
                break;
            case PlayerState.Dead:
                break;
            case PlayerState.Finish:
                break;
        }
    }

    private void ExitCurrentState()
    {
        switch (_state)
        {
            case PlayerState.Prepare:
                break;
            case PlayerState.Play:
                break;
            case PlayerState.Dead:
                break;
            case PlayerState.Finish:
                break;
        }
    }
}
