using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : IGameState
{
    public void EnterState()
    {
        Debug.Log("���� � GamePlay");
        Time.timeScale = 1f; // ���� ��������
                             // ����� ����� �������� ������� ��������
        GameObject.Find("PausePanel").SetActive(false); // �������� �����
        Cursor.visible = false;
    }

    public void ExitState()
    {
        Debug.Log("����� �� GamePlay");
        // ����� ����� ��������� ������� ��������
    }

    public void UpdateState()
    {
        // ������ ���������� (��������, �������� ������� ������ �����)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseGame(); // ���������� ����� GameManager
        }
    }
}
