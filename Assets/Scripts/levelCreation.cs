using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelCreation : MonoBehaviour
{

    private GameObject tilePos;
    private float startUpPosY;
    private const float tileWidth = 1.0f;
    private int heightLevel = 0;
    private GameObject tmpTile;

    private GameObject collectedTiles;
    private GameObject gameLayer;
    private GameObject bgLayer;

    public float gameSpeed = 4.0f;
    private float autofbounceX;
    private int blankCounter = 0;
    private int middleCounter = 0;
    private string lastTile = "right";

    public Text scoreTxt;
    public Text moneyTxt;
    static public int score;
    public float scoreMultiply = 0.5f;
    public float _score;

    private int timer = 5;

    private bool bonusAdded = false;
    public Transform BonusLucky;
    public Transform BonusMoney;
    public int RandomBonus;

    private bool enemyAdded = false;
    public Transform Enemy1;
    public Transform Enemy2;
    public Transform Enemy3;
    public int RandomEnemy;


    private bool lose;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    // Use this for initialization
    void Start()
    {
        score = 0;

        gameLayer = GameObject.Find("gameLayer");
        bgLayer = GameObject.Find("backgroundLayer");
        collectedTiles = GameObject.Find("tiles");

        for (int i = 0; i < 21; i++)
        {
            GameObject tmpG1 = Instantiate(Resources.Load("ground_left", typeof(GameObject))) as GameObject;
            tmpG1.transform.parent = collectedTiles.transform.FindChild("gLeft").transform;
            GameObject tmpG2 = Instantiate(Resources.Load("ground_middle", typeof(GameObject))) as GameObject;
            tmpG2.transform.parent = collectedTiles.transform.FindChild("gMiddle").transform;
            GameObject tmpG3 = Instantiate(Resources.Load("ground_right", typeof(GameObject))) as GameObject;
            tmpG3.transform.parent = collectedTiles.transform.FindChild("gRight").transform;
            GameObject tmpG4 = Instantiate(Resources.Load("blank", typeof(GameObject))) as GameObject;
            tmpG4.transform.parent = collectedTiles.transform.FindChild("gBlank").transform;
        }

        for (int i = 0; i < 10; i++)

        {

            GameObject tmpG5 = Instantiate(Resources.Load("enemy1", typeof(GameObject))) as GameObject;
            tmpG5.transform.parent = collectedTiles.transform.FindChild("enemy1").transform;
            tmpG5.transform.position = Vector2.zero;

            GameObject tmpG6 = Instantiate(Resources.Load("enemy2", typeof(GameObject))) as GameObject;
            tmpG6.transform.parent = collectedTiles.transform.FindChild("enemy2").transform;
            tmpG6.transform.position = Vector2.zero;

            GameObject tmpG7 = Instantiate(Resources.Load("enemy3", typeof(GameObject))) as GameObject;
            tmpG7.transform.parent = collectedTiles.transform.FindChild("enemy3").transform;
            tmpG7.transform.position = Vector2.zero;

        }


        collectedTiles.transform.position = new Vector2(-40.0f, -20.0f);
        tilePos = GameObject.Find("startTilePosition");
        startUpPosY = tilePos.transform.position.y;
        autofbounceX = tilePos.transform.position.x - 2.0f;

        fillScene();
    }


    void FixedUpdate()
    {

        if ((int)Time.timeSinceLevelLoad == timer)
        {
            gameSpeed += 0.5f;
            scoreMultiply += 0.02f;
            timer += 5;

        }

        gameLayer.transform.position = new Vector2(gameLayer.transform.position.x - gameSpeed * Time.deltaTime, 0);
        bgLayer.transform.position = new Vector2(bgLayer.transform.position.x - gameSpeed / 10 * Time.deltaTime, 0);

        foreach (Transform child in gameLayer.transform)
        {
            if (child.position.x < autofbounceX)
            {
                switch (child.gameObject.name)
                {
                    case "ground_left(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("gLeft").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("gLeft").transform;
                        break;
                    case "ground_middle(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("gMiddle").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("gMiddle").transform;
                        break;
                    case "ground_right(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("gRight").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("gRight").transform;
                        break;
                    case "blank(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("gBlank").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("gBlank").transform;
                        break;
                    case "enemy1(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("enemy1").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("enemy1").transform;
                        break;
                    case "enemy2(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("enemy2").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("enemy2").transform;
                        break;
                    case "enemy3(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("enemy3").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("enemy3").transform;
                        break;
                    default:
                        Destroy(child.gameObject);
                        break;
                }

            }
        }

        if (gameLayer.transform.childCount < 30)
            spawnTile();
    }

    private void fillScene()
    {
        for (int i = 0; i < 5; i++)
        {
            setTile("middle");
        }
        setTile("right");
    }

    void OnTriggerEnter2D()
    {
        if (GetComponent<Collider2D>().gameObject.tag == "lose")
            Application.LoadLevel("Game over");
        //lose = true;
    }



    // Update is called once per frame
    void Update()
    {

        //if (lose)
        // Application.LoadLevel("Game over");

        _score += scoreMultiply;
        score = (int)_score;
        scoreTxt.text = "Score " + score.ToString();
        moneyTxt.text = "Money " + player.money.ToString();


    }





    public void setTile(string type)
    {
        switch (type)
        {
            case "left":
                tmpTile = collectedTiles.transform.FindChild("gLeft").transform.GetChild(1).gameObject;
                break;
            case "right":
                tmpTile = collectedTiles.transform.FindChild("gRight").transform.GetChild(1).gameObject;
                break;
            case "middle":
                tmpTile = collectedTiles.transform.FindChild("gMiddle").transform.GetChild(1).gameObject;
                break;
            case "blank":
                tmpTile = collectedTiles.transform.FindChild("gBlank").transform.GetChild(1).gameObject;
                break;
            case "coin":
                tmpTile = collectedTiles.transform.FindChild("bonusM").transform.GetChild(1).gameObject;
                break;
            case "lucky":
                tmpTile = collectedTiles.transform.FindChild("bonusS").transform.GetChild(1).gameObject;
                break;
        }

        tmpTile.transform.parent = gameLayer.transform;
        tmpTile.transform.position = new Vector2(tilePos.transform.position.x + (tileWidth) + 1.52f, startUpPosY + (heightLevel * tileWidth));
        tilePos = tmpTile;
        lastTile = type;
    }

    private void spawnTile()
    {
        if (blankCounter > 0)
        {
            setTile("blank");
            blankCounter--;
            return;
        }
        if (middleCounter > 0)
        {
            setTile("middle");
            middleCounter--;
            randomizeBonus();
            randomizeEnemy();
            return;
        }
        bonusAdded = false;
        enemyAdded = false;

        if (lastTile == "blank")
        {
            changeHeight();
            setTile("left");
            middleCounter = (int)Random.Range(1, 4);
        }
        else if (lastTile == "right")
        {
            blankCounter = (int)Random.Range(2, 3);
        }
        else if (lastTile == "middle")
        {
            setTile("right");
        }

    }

    private void changeHeight()
    {
        int newHeightLevel = (int)Random.Range(0, 4);
        if (newHeightLevel < heightLevel)
            heightLevel--;
        else if (newHeightLevel > heightLevel)
            heightLevel++;
    }


    private void randomizeBonus()
    {

        if (bonusAdded)
            return;
        if (Random.Range(1, 5) == 1)
        {
            bonusAdded = true;
            {
                RandomBonus = Random.Range(1, 3);
                if (RandomBonus == 1)
                {
                    var _bonusMoney = Instantiate(BonusMoney) as Transform;
                    _bonusMoney.transform.position = new Vector2(tilePos.transform.position.x + tileWidth, startUpPosY + (heightLevel + tileWidth + (tileWidth + 2)));
                    _bonusMoney.transform.parent = gameLayer.transform;
                }
                if (RandomBonus == 2)
                {
                    var _bonusLucky = Instantiate(BonusLucky) as Transform;
                    _bonusLucky.transform.position = new Vector2(tilePos.transform.position.x + tileWidth, startUpPosY + (heightLevel + tileWidth + (tileWidth + 2)));
                    _bonusLucky.transform.parent = gameLayer.transform;
                }
            }
        }
    }

    private void randomizeEnemy()
    {
        if (enemyAdded)
            return;
        if ((int)Random.Range(0, 5) == 1)
        {
            enemyAdded = true;
            {
                RandomEnemy = Random.Range(1, 4);
                if (RandomEnemy == 1)
                {
                    GameObject newEnemy = collectedTiles.transform.FindChild("enemy1").transform.GetChild(0).gameObject;
                    newEnemy.transform.parent = gameLayer.transform;
                    newEnemy.transform.position = new Vector2(tilePos.transform.position.x + tileWidth, startUpPosY + (heightLevel * tileWidth + (tileWidth + 0.9f)));
                    enemyAdded = true;
                }
                if (RandomEnemy == 2)
                {
                    GameObject newEnemy = collectedTiles.transform.FindChild("enemy2").transform.GetChild(0).gameObject;
                    newEnemy.transform.parent = gameLayer.transform;
                    newEnemy.transform.position = new Vector2(tilePos.transform.position.x + tileWidth, startUpPosY + (heightLevel * tileWidth + (tileWidth + 0.8f)));
                    enemyAdded = true;
                }
                if (RandomEnemy == 3)
                {
                    GameObject newEnemy = collectedTiles.transform.FindChild("enemy3").transform.GetChild(0).gameObject;
                    newEnemy.transform.parent = gameLayer.transform;
                    newEnemy.transform.position = new Vector2(tilePos.transform.position.x + tileWidth, startUpPosY + (heightLevel * tileWidth + (tileWidth + 0.85f)));
                    enemyAdded = true;
                }

            }
        }
    }
}
