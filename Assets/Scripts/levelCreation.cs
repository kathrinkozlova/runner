using UnityEngine;
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

    private float gameSpeed = 4.0f;
    private float autofbounceX;
    private int blankCounter = 0;
    private int middleCounter = 0;
    private string lastTile = "right";
    private float startTime;

    
    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    // Use this for initialization
    void Start()
    {
        
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

        collectedTiles.transform.position = new Vector2(-60.0f, -20.0f);
        tilePos = GameObject.Find("startTilePosition");
        startUpPosY = tilePos.transform.position.y;
        autofbounceX = tilePos.transform.position.x - 5.0f;

        fillScene();
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if (startTime - Time.time % 5 == 0)
        {
            gameSpeed += 0.5f;
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
                    default:
                        Destroy(child.gameObject);
                        break;
                }

            }
        }

        if (gameLayer.transform.childCount < 25)
            spawnTile();
    }

    private void fillScene()
    {
        for (int i = 0; i < 7; i++)
        {
            setTile("middle");
        }
        setTile("right");
    }

    // Update is called once per frame
    void Update()
    {

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
        }

        tmpTile.transform.parent = gameLayer.transform;
        tmpTile.transform.position = new Vector2(tilePos.transform.position.x + (tileWidth), startUpPosY + (heightLevel * tileWidth));
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
            return;
        }
        if (lastTile == "blank")
        {
            changeHeight();
            setTile("left");
            middleCounter = (int)Random.Range(1,8);
        }
        else if (lastTile == "right")
        {
            blankCounter = (int)Random.Range(2,4);
        }
        else if (lastTile == "middle")
        {
            setTile("right");
        }
        
    }

    private void changeHeight()
    {
        int newHeightLevel = (int)Random.Range(0,4);
        if (newHeightLevel < heightLevel)
            heightLevel--;
        else if (newHeightLevel > heightLevel)
            heightLevel++;
    }


}
