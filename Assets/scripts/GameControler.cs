using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public HitablePlayer player1;
    public HitablePlayer player2;
    public HitablePlayer player3;
    public HitablePlayer player4;

    public Text timer;
    public Text Team1VP;
    public Text Team2VP;
    public Text Team3VP;
    public Text Team4VP;
    public Text Team1WIN;
    public Text Team2WIN;
    public Text Team3WIN;
    public Text Team4WIN;
    public Text Tie;
    public Text playAgainText;
    public GameObject endCamSetup;
    public Transform endCamSpawner;

    public float time;
    public bool isClassic;
    int p1VP;
    int p1LP;
    int p2VP;
    int p2LP;
    int p3VP;
    int p3LP;
    int p4VP;
    int p4LP;
    int p1HiddenVP;
    int p2HiddenVP;
    int p3HiddenVP;
    int p4HiddenVP;
    bool roundOver;

    public static GameControler Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        time = GameSetup.Instance.timer;
        isClassic = GameSetup.Instance.isClassic;
        Team1WIN.enabled = false;
        Team2WIN.enabled = false;
        Team3WIN.enabled = false;
        Team4WIN.enabled = false;
        Tie.enabled = false;
        playAgainText.enabled = false;
        roundOver = false;
    }

    void Update()
    {
        if (Instance != this) Instance = this;        

        if (roundOver)
        {
            CheckLevelRestart();
            return;
        }

        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
            CheckTimeWin();
        }

        int minutes = (int)time / 60;
        int seconds = (int)time % 60;

        if (seconds >= 10) timer.text = "" + minutes + ":" + seconds;
        else timer.text = "" + minutes + ": 0" + seconds;
    }

    public void GiveVP(int playerReceiving, int playerLosing)
    {
        switch (playerReceiving)
        {
            case 1:
                p1VP++;
                break;
            case 2:
                p2VP++;
                break;
            case 3:
                p3VP++;
                break;
            case 4:
                p4VP++;
                break;
        }
        if (isClassic)
            switch (playerLosing)
            {
                case 1:
                    p1VP--;
                    break;
                case 2:
                    p2VP--;
                    break;
                case 3:
                    p3VP--;
                    break;
                case 4:
                    p4VP--;
                    break;
            }
        else
            switch (playerLosing)
            {
                case 1:
                    p1LP++;
                    break;
                case 2:
                    p2LP++;
                    break;
                case 3:
                    p3LP++;
                    break;
                case 4:
                    p4LP++;
                    break;
            }

        UpdateVP();
    }

    public void GiveHiddenVP(int playerReceiving, int playerLosing)
    {
        switch (playerReceiving)
        {
            case 1:
                p1HiddenVP++;
                break;
            case 2:
                p2HiddenVP++;
                break;
            case 3:
                p3HiddenVP++;
                break;
            case 4:
                p4HiddenVP++;
                break;
        }
        switch (playerLosing)
        {
            case 1:
                p1LP++;
                break;
            case 2:
                p2LP++;
                break;
            case 3:
                p3LP++;
                break;
            case 4:
                p4LP++;
                break;
        }

    }

    void UpdateVP()
    {
        Team1VP.text = p1VP.ToString();
        Team2VP.text = p2VP.ToString();
        Team3VP.text = p3VP.ToString();
        Team4VP.text = p4VP.ToString();
    }

    void CheckTimeWin()
    {
        int winnerPoints = 0;
        int currentWinner = 0;

        if (p1VP > winnerPoints) { winnerPoints = p1VP; currentWinner = 1; }
        if (p2VP > winnerPoints) { winnerPoints = p2VP; currentWinner = 2; }
        if (p3VP > winnerPoints) { winnerPoints = p3VP; currentWinner = 3; }
        if (p4VP > winnerPoints) { winnerPoints = p4VP; currentWinner = 4; }

        if (p2VP == winnerPoints && currentWinner != 2) currentWinner = 0;
        if (p3VP == winnerPoints && currentWinner != 3) currentWinner = 0;
        if (p4VP == winnerPoints && currentWinner != 4) currentWinner = 0;

        if (currentWinner == 0)
        {
            if (isClassic)
            {
                winnerPoints = 0;
                currentWinner = 0;

                if (p1VP > winnerPoints) { winnerPoints = p1HiddenVP; currentWinner = 1; }
                if (p2VP > winnerPoints) { winnerPoints = p2HiddenVP; currentWinner = 2; }
                if (p3VP > winnerPoints) { winnerPoints = p3HiddenVP; currentWinner = 3; }
                if (p4VP > winnerPoints) { winnerPoints = p4HiddenVP; currentWinner = 4; }

                if (p2VP == winnerPoints && currentWinner != 2) currentWinner = 0;
                if (p3VP == winnerPoints && currentWinner != 3) currentWinner = 0;
                if (p4VP == winnerPoints && currentWinner != 4) currentWinner = 0;
            }
            if (!isClassic || currentWinner == 0)
            {
                int loserPoints = p1LP;
                currentWinner = 1;

                if (p2LP > loserPoints) { loserPoints = p2LP; currentWinner = 2; }
                if (p3LP > loserPoints) { loserPoints = p3LP; currentWinner = 3; }
                if (p4LP > loserPoints) { loserPoints = p4LP; currentWinner = 4; }

                if (p2LP == loserPoints && currentWinner != 2) currentWinner = 0;
                if (p3LP == loserPoints && currentWinner != 3) currentWinner = 0;
                if (p4LP == loserPoints && currentWinner != 4) currentWinner = 0;
            }
        }

        AnnounceWinner(currentWinner);
    }

    void AnnounceWinner(int team)
    {
        if (player1) player1.Death();
        if (player2) player2.Death();
        if (player3) player3.Death();
        if (player4) player4.Death();

        Instantiate(endCamSetup, endCamSpawner);

        switch (team)
        {
            case 0:
                Tie.enabled = true;
                break;
            case 1:
                Team1WIN.enabled = true;
                break;
            case 2:
                Team2WIN.enabled = true;
                break;
            case 3:
                Team3WIN.enabled = true;
                break;
            case 4:
                Team4WIN.enabled = true;
                break;
        }

        playAgainText.enabled = true;

        roundOver = true;
    }

    void CheckLevelRestart()
    {
        Scene scene = SceneManager.GetActiveScene();
        bool reloadScene = false;

        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            reloadScene = true;
        }

        if (reloadScene)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
