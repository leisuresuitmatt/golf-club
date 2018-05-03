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
    public int victoryPoints;
    int p1VP;
    int p2VP;
    int p3VP;
    int p4VP;
    bool roundOver;

    private void Start()
    {
        time *= 60;
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
        timer.text = "" + minutes + ":" + seconds;        
    }

    public void GiveVP(int player)
    {
        switch (player)
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

        UpdateVP();
    }

    void UpdateVP()
    {
        Team1VP.text = "Team 1: " + p1VP + " points";
        Team2VP.text = "Team 2: " + p2VP + " points";
        Team3VP.text = "Team 3: " + p3VP + " points";
        Team4VP.text = "Team 4: " + p4VP + " points";
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

        AnnounceWinner(currentWinner);
    }

    void AnnounceWinner(int team)
    {
        player1.Death();
        player2.Death();
        player3.Death();
        player4.Death();

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
