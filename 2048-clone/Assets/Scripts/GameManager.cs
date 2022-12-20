using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] n;

    bool wait;
    int x, y;
    Vector3 firstPos, gap;
    GameObject[,] Square = new GameObject[4, 4];

    
    void Start()
    {
        //처음에 숫자 2개 생성
        Spawn();
        Spawn();
    }

    void Update()
    {
        //esc
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        //click
        if (Input.GetMouseButtonDown(0))
        {
            wait = true;
            firstPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            gap = Input.mousePosition - firstPos;
            if (gap.magnitude < 100) return;
            gap.Normalize();

            if(wait)
            {
                //클릭을 하고(buttondown) 움직임을 한번만 감지(gap)할 수 있도록
                wait = false;

                //위쪽방향. 드래그를 정확히 위로할 순 없으니 x도 어느정도 범위만
                if(gap.y > 0 && gap.x > -0.5f && gap.x < 0.5f)
                {
                    
                }
                //아래
                if (gap.y < 0 && gap.x > -0.5f && gap.x < 0.5f)
                {
                    
                }
                //좌
                if (gap.x < 0 && gap.y > -0.5f && gap.y < 0.5f)
                {
                    
                }
                //우
                if (gap.x > 0 && gap.y > -0.5f && gap.y < 0.5f)
                {
                    
                }
            }
        }
    }

    void Spawn()
    {
        while (true)
        {
            x = Random.Range(0, 4);
            y = Random.Range(0, 4);
            if (Square[x, y] == null) break;
        }
        // 1/7의 확률로 n[1](4)가 스폰, 그 외에는 n[0](2)가 스폰, 좌표는 직접 대보고 계산...
        Square[x, y] = Instantiate(Random.Range(0, 8) > 0 ? n[0] : n[1], new Vector3(1.2f * x - 1.8f, 1.2f * y - 1.8f, 0), Quaternion.identity);
        Square[x, y].GetComponent<Animator>().SetTrigger("Spawn");
        
    }

    //restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
