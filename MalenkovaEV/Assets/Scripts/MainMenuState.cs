using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : IGameState
{
    public void EnterState()
    {
        Debug.Log("���� � MainMenu");
        Time.timeScale = 0f; // ������������� ����� (���� �����)
                             // ����� ����� �������� UI ����
        GameObject.Find("MainMenuPanel").SetActive(true);
        Cursor.visible = true;
    }

    public void ExitState()
    {
        Debug.Log("����� �� MainMenu");
        GameObject.Find("MainMenuPanel").SetActive(false);
        Time.timeScale = 1f; // ������������ �����
        // ����� ����� ��������� UI ����
    }

    public void UpdateState()
    {
        // ������ ���������� (���� �����)
    }
}

