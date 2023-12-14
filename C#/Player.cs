using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//NPC와 Player의 부모

public class Player : MonoBehaviour
{
    public string characterName;
    public float speed;
    protected Vector3 vector;
    public int walkCount;
    protected int currentWalkCount;
    public Animator animator;

    public Queue<string> queue;
    private bool notCo = false;
    public BoxCollider2D boxCollider;
    public LayerMask layerMask; //어떤 레이어와 충돌했는지 판단하기 위한 변수 -> 통과할 수 없는 레이어 설정

    public void Move(string _dir, int _fre = 5) //_fre에 아무런 값도 넘어오지 않을 경우, _fre값은 5가 됨. 즉, 생략 가능
    {
        queue.Enqueue(_dir);
        if (!notCo) //처음엔 무조건 실행 -> 다시 Move가 실행되면 notCo가 true이기 때문에 기존 큐가 사라질 때까지 MoveCoroutine이 반복 실행됨
        {
            notCo = true;
            StartCoroutine(MoveCoroutine(_dir, _fre));
        }
    }
    IEnumerator MoveCoroutine(string _dir, int _fre)
    {
        while (queue.Count != 0)
        { //큐의 count가 0이 될 때 == 큐가 빌 때
            string direction = queue.Dequeue();
            vector.Set(0, 0, vector.z);
            switch (direction)
            {
                case "up":
                    vector.y = 1f;
                    break;
                case "down":
                    vector.y = -1f;
                    break;
                case "right":
                    vector.x = 1f;
                    break;
                case "left":
                    vector.x = -1f;
                    break;
            }
            //애니메이션 변경
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            animator.SetBool("Walking", true);
            while (currentWalkCount < walkCount)
            {
                transform.Translate(vector.x * speed, vector.y * speed, 0);
                currentWalkCount++;
                yield return new WaitForSeconds(0.1f);
            }
            currentWalkCount = 0;
            if (_fre != 5)
            {
                animator.SetBool("Walking", false);
            }
        }
        animator.SetBool("Walking", false); //while이 끝나면 애니메이션 종료
        notCo = false;
    }

    protected bool CheckCollsion()
    {
        RaycastHit2D hit;
        Vector2 start = new Vector2(transform.position.x + vector.x * speed * walkCount, transform.position.y + vector.y * speed * walkCount);
        Vector2 end = start + new Vector2(vector.x * speed, vector.y * speed); //캐릭터가 이동하고자 하는 위치값

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxCollider.enabled = true;

        if (hit.transform != null) return true;
        return false;
    }
}
