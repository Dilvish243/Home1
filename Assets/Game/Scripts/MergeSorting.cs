using System.Collections.Generic;
using UnityEngine;

public class MergeSorting : MonoBehaviour
{
    private List<string> Enemies;

    void Start()
    {
        // ������� ����� ������ ��� �������� ������
        Enemies = new List<string>();

        // ������� ���� ������ � ����� Cube (���������� ��� ���� ���� � �� ������� :D)
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        // ��������� ������ ������� ������ �� ����� �� ���� Cube
        foreach (GameObject cube in cubes)
        {
            Enemies.Add(cube.name);
        }

        // �������� ����� MergeSort ��� ������ Enemies
        Enemies = MergeSort(Enemies);

        // ������� � ������� ��������������� ������
        foreach (string name in Enemies)
        {
            Debug.Log(name);
        }
    }

    
   // ������� ����� MergeSort ��� ���������� ��������
    List<string> MergeSort(List<string> unsortedList)
    {
        // ���� ������ �������� ���� ������� ��� ����, ���������� ��� ��� ���������

        if (unsortedList.Count <= 1)
            return unsortedList;

        // ������� ��� ����� ������ ��� �������� ����� � ������ ������ ��������� ������
        List<string> left = new List<string>();
        List<string> right = new List<string>();

        // ������� ������ �������� ��������� ������
        int middle = unsortedList.Count / 2;

        // ��������� ����� ������ ���������� �� �������� ��������� ������
        for (int i = 0; i < middle; i++)
        {
            left.Add(unsortedList[i]);
        }
        // ��������� ������ ������ ���������� �� �������� �� ����� ��������� ������
        for (int i = middle; i < unsortedList.Count; i++)
        {
            right.Add(unsortedList[i]);
        }

        // �������� MergeSort ��� ������ � ������� �������

        left = MergeSort(left);
        right = MergeSort(right);

        // ������� ��������������� ����� � ������ ������ � ���������� ���������
        return Merge(left, right);
    }

    // ����� Merge ��������� ��� ��������������� ������ ����� � ������� �� � ���� ��������������� ������
    List<string> Merge(List<string> left, List<string> right)
    {
        // ������� ����� ������ ��� �������� ���������� �������

        List<string> result = new List<string>();

        // ���� ��� ������ �� �����, ���������� �� ������ �������� � ��������� ������� � ���������

        while (left.Count > 0 && right.Count > 0)
        {
            if (left[0].CompareTo(right[0]) < 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }

        // ���� � ����� ������ �������� ��������, ��������� �� � ���������

        while (left.Count > 0)
        {
            result.Add(left[0]);
            left.RemoveAt(0);
        }

        // ���� � ������ ������ �������� ��������, ��������� �� � ���������

        while (right.Count > 0)
        {
            result.Add(right[0]);
            right.RemoveAt(0);
        }

        // ���������� ��������� �������

        return result;
    }
   

}
