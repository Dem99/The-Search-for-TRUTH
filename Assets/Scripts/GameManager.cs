using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private bool hasWonFakeNewsHunter = false;
    public bool HasWonFakeNewsHunter
    {
        get { return hasWonFakeNewsHunter; }
        set { hasWonFakeNewsHunter = value; }
    }
    private bool hasTalkToNpc1 = false;
    public bool HasTalkToNpc1
    {
        get { return hasTalkToNpc1; }
        set { hasTalkToNpc1 = value; }
    }

    private bool hasTalkToGang1 = false;
    public bool HasTalkToGang1
    {
        get { return hasTalkToGang1; }
        set { hasTalkToGang1 = value; }
    }
    private bool hasTalkToGang2 = false;
    public bool HasTalkToGang2
    {
        get { return hasTalkToGang2; }
        set { hasTalkToGang2 = value; }
    }
    private bool hasTalkToGang3 = false;
    public bool HasTalkToGang3
    {
        get { return hasTalkToGang3; }
        set { hasTalkToGang3 = value; }
    }
    private bool hasTalkToGang4 = false;
    public bool HasTalkToGang4
    {
        get { return hasTalkToGang4; }
        set { hasTalkToGang4 = value; }
    }

    private float musicVolume = 1.0f;
    public float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }

    private float masterVolume = 1.0f;
    public float MasterVolume
    {
        get { return masterVolume; }
        set { masterVolume = value; }
    }

    private bool hasWonPuzzleGame = false;
    public bool HasWonPuzzleGame
    {
        get { return hasWonPuzzleGame; }
        set { hasWonPuzzleGame = value; }
    }

    private bool hasWonNewsNinjaGame = false;
    public bool HasWonNewsNinjaGame
    {
        get { return hasWonNewsNinjaGame; }
        set { hasWonNewsNinjaGame = value; }
    }


    private bool hasWonHoaxNews = false;
    public bool HasWonHoaxNews
    {
        get { return hasWonHoaxNews; }
        set { hasWonHoaxNews = value; }
    }

    private Vector3 playerPosition;
    public Vector3 PlayerPosition
    {
        get { return playerPosition; }
        set { playerPosition = value; }
    }

    private Quaternion playerRotation;
    public Quaternion PlayerRotation
    {
        get { return playerRotation; }
        set { playerRotation = value; }
    }

    private bool shouldReturnToMainScene = false;
    public bool ShouldReturnToMainScene
    {
        get { return shouldReturnToMainScene; }
        set { shouldReturnToMainScene = value; }
    }
}