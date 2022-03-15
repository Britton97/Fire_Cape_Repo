using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    [SerializeField] private SpriteRenderer mySprite;
    [Header("Tail")]
    [SerializeField] public GameObject tail;
    [Range(1,10)]
    [SerializeField] private int tailLength;
    private float nextActionTime = 0.0f;
    public float period = 0.5f;
    [SerializeField] public List<Tail> tailList = new List<Tail>();
    [Header("Movement")]
    public float waitPeriod = 1f;
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3((int)(gridManager._width / 2 - .5f), (int)(gridManager._length / 2 - .5f), 0);
        tailLength += 1;
        GenerateTail(tailLength, transform.position);


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //MovementBasic();
        if (time >= waitPeriod)
        {
            MovementTilemap();
        }
        MouseToWorld();
        BurnTail();

    }

    private void GenerateTail(int _tailLength, Vector3 pos)
    {
        int newLength = _tailLength - 1;
        if (newLength > 0)
        {
            Vector3 tailPos = new Vector3(pos.x - 1, pos.y, pos.z);
            RaycastHit2D hit = Physics2D.Raycast(tailPos, -Vector3.forward);

            if (hit && hit.transform.name == "Ground_Map")
            {
                //print("got here");
                //print($"Hit {hit.transform.name}");
                var spawnedTile = Instantiate(tail, tailPos, Quaternion.identity);
                tailList.Add(spawnedTile.GetComponent<Tail>());

            }

            GenerateTail(newLength, tailPos);
        }
    }

    private void BurnTail()
    {
        if (Time.time > nextActionTime && tailList.Count >= 1)
        {
            nextActionTime += period;

            if (tailList[tailList.Count - 1].myLife <= .1f)
            {
                Tail destroyMe = tailList[tailList.Count - 1];
                tailList.RemoveAt(tailList.Count - 1);
                destroyMe.DestroyMe();
            }
            else
            {
                tailList[tailList.Count - 1].DecreaseMyLife(.1f);
            }
            // execute block of code here
        }
        else
        {
            //do thing
        }
    }

    private void MouseToWorld()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector3.forward);


            if (hit && hit.transform.GetComponent<Tail>())
            {
                print("hit a tail");
            }
            else if(hit)
            {
                print(hit.transform.name);
            }
            else
            {
                print("hit noting");
            }
        }
    }
    private void MovementTilemap()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
                time = 0.0f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
                time = 0.0f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
                time = 0.0f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
                time = 0.0f;
            }
        }
    }
    private void MovementBasic()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 orginal = transform.position;
            Vector3 tryMove = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            RaycastHit2D hit = Physics2D.Raycast(tryMove, -Vector3.forward);
            if (TestIfWalkable(tryMove, hit))
            {
                transform.position = tryMove;
                MoveTail(orginal);
            }
        }
    }

    private void MoveTail(Vector3 pos)
    {
        Vector3 returnedPos = Vector3.zero;
        for(int i = 0; i < tailList.Count; i++)
        {
            if (i == 0 && tailList.Count > 1)
            {
                 returnedPos = tailList[0].MoveMe(pos);
            }
            else if (i == 0 && tailList.Count == 1)
            {
                returnedPos = tailList[i].MoveMe(pos);
                if (tailList[i].DecreaseMyLife(.2f) == -1f)
                {
                    Tail destroyMe = tailList[i];
                    tailList.RemoveAt(i);
                    destroyMe.DestroyMe();
                }
            }
            else if (i == tailList.Count -1 | tailList.Count == 1)
            {
                returnedPos = tailList[i].MoveMe(returnedPos);
                if (tailList[i].DecreaseMyLife(.2f) == -1f)
                {
                    Tail destroyMe = tailList[i];
                    tailList.RemoveAt(i);
                    destroyMe.DestroyMe();
                }
            }
            else
            {
                returnedPos = tailList[i].MoveMe(returnedPos);
            }
        }
    }

    private bool TestIfWalkable(Vector3 tryMove, RaycastHit2D hit)
    {
        if (hit && hit.transform.name == "Ground_Map")
        {
            return true;
        }
        return false;
    }
}
