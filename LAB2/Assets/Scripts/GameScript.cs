using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    private Camera _camera;
    private int startIndex = 15;
    private bool gameFinish;
    [SerializeField] private Transform emptySpace = null;
    [SerializeField] private TileScript[] tiles;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text endPanelTimerText;

    void Start()
    {
        endPanel.SetActive(false);
        _camera = Camera.main;
        ShakeTiles();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 3)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    emptySpace.position = thisTile.targetPostition;
                    thisTile.targetPostition = lastEmptySpacePosition;

                    int tileIndex = findIndex(thisTile);
                    tiles[startIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    startIndex = tileIndex;
                }
            }
        }

        if (!gameFinish)
        {
            int correctTiles = 0;

            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                        correctTiles++;
                    endPanel.SetActive(false);
                }               
            }

            if (correctTiles == tiles.Length - 1)
            {
                gameFinish = true;
                endPanel.SetActive(true);

                var a = GetComponent<TimerScript>();
                a.StopTimer();
                endPanelTimerText.text = (a.minutes < 10 ? "0" : "") + a.minutes + "-" + (a.seconds < 10 ? "0" : "") + a.seconds;
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShakeTiles()
    {
        if (startIndex != 15)
        {
            var tile15LastPos = tiles[15].targetPostition;
            tiles[15].targetPostition = emptySpace.position;
            emptySpace.position = tile15LastPos;

            tiles[startIndex] = tiles[15];
            tiles[15] = null;
            startIndex = 15;
        }

        int inversion;

        do
        {
            for (int i = 0; i <= 14; i++)
            {
                if (tiles[0] != null)
                {
                    var lastpos = tiles[i].targetPostition;
                    int randomPosition = Random.Range(0, 14);

                    tiles[i].targetPostition = tiles[randomPosition].targetPostition;
                    tiles[randomPosition].targetPostition = lastpos;

                    var tile = tiles[i];
                    tiles[i] = tiles[randomPosition];
                    tiles[randomPosition] = tile;
                }
            }
            inversion = GetInversions();
        }while(inversion%2 != 0);
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

    public int findIndex(TileScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }

        return -1;
    }
}
