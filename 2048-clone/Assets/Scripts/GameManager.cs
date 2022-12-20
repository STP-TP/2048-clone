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
        //ó���� ���� 2�� ����
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
                //Ŭ���� �ϰ�(buttondown) �������� �ѹ��� ����(gap)�� �� �ֵ���
                wait = false;

                //���ʹ���. �巡�׸� ��Ȯ�� ������ �� ������ x�� ������� ������
                if(gap.y > 0 && gap.x > -0.5f && gap.x < 0.5f)
                {
                    
                }
                //�Ʒ�
                if (gap.y < 0 && gap.x > -0.5f && gap.x < 0.5f)
                {
                    
                }
                //��
                if (gap.x < 0 && gap.y > -0.5f && gap.y < 0.5f)
                {
                    
                }
                //��
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
        // 1/7�� Ȯ���� n[1](4)�� ����, �� �ܿ��� n[0](2)�� ����, ��ǥ�� ���� �뺸�� ���...
        Square[x, y] = Instantiate(Random.Range(0, 8) > 0 ? n[0] : n[1], new Vector3(1.2f * x - 1.8f, 1.2f * y - 1.8f, 0), Quaternion.identity);
        Square[x, y].GetComponent<Animator>().SetTrigger("Spawn");
        
    }

    //restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
