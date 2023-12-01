using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    //Player == MovingObject
    private PlayerManager thePlayer; //이벤트 도중 플레이어 움직임 (키입력 처리) 방지
    private List<Player> characters; //배열의 크기는 한 번 지정하면 크기 변경이 되지 않는데 npc는 각 씬에 서로 다른 개수가 있을 수 있음 -> 리스트 사용

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    public void PreLoadCharacter()
    {
        characters = ToList();
    }

    public List<Player> ToList()
    {
        List<Player> tempList = new List<Player>();
        Player[] temp = FindObjectsOfType<Player>(); //배열은 이 함수에 들어왔을 때 새로 만들어지기 때문에 상관 X
        //FindObjectsOfType<>() : PlayerManager가 달린 모든 오브젝트를 찾아서 반환함
        for (int i = 0; i < temp.Length; i++)
        {
            tempList.Add(temp[i]);
        }
        return tempList;
    }

    public void NotMove(){
        thePlayer.notMove = true;
    }
    public void YesMove(){
        thePlayer.notMove = false;
    }

    public void Move(string _name, string _dir)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (_name == characters[i].characterName)
            {
                characters[i].Move(_dir);
            }
        }
    }

    public void SetThorought(string _name)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (_name == characters[i].characterName)
            {
                characters[i].boxCollider.enabled = false; //해당 캐릭터가 벽을 뚫게 함
            }
        }
    }

    public void UnSetThorought(string _name)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (_name == characters[i].characterName)
            {
                characters[i].boxCollider.enabled = true; //해당 캐릭터가 벽을 못 뚫게 함
            }
        }
    }

    public void SetTransparent(string _name)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (_name == characters[i].characterName)
            {
                characters[i].gameObject.SetActive(false); //해당 캐릭터가 투명해지도록 만듦
            }
        }
    }

    public void UnSetTransparent(string _name)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (_name == characters[i].characterName)
            {
                characters[i].gameObject.SetActive(true); //해당 캐릭터가 다시 보이도록 함
            }
        }
    }

    public void Turn(string _name, string _dir)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (_name == characters[i].characterName)
            {
                characters[i].animator.SetFloat("DirY", 0f);
                characters[i].animator.SetFloat("DirX", 0f);
                switch (_dir)
                {
                    case "UP":
                        characters[i].animator.SetFloat("DirY", 1f);
                        break;
                    case "DOWN":
                        characters[i].animator.SetFloat("DirY", -1f);
                        break;
                    case "LEFT":
                        characters[i].animator.SetFloat("DirX", -1f);
                        break;
                    case "RIGHT":
                        characters[i].animator.SetFloat("DirX", 1f);
                        break;
                }
            }
        }
    }
}
