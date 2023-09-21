using System.Collections.Generic;
using UnityEngine;

public class MergeSorting : MonoBehaviour
{
    private List<string> Enemies;

    void Start()
    {
        // создаем новый список для хранения врагов
        Enemies = new List<string>();

        // находим всех врагов с тэгом Cube (изначально они были кубы а не капсулы :D)
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        // Заполняем список именами капсул на сцене по тэгу Cube
        foreach (GameObject cube in cubes)
        {
            Enemies.Add(cube.name);
        }

        // Вызываем метод MergeSort для списка Enemies
        Enemies = MergeSort(Enemies);

        // выводим в консоль отсортированный список
        foreach (string name in Enemies)
        {
            Debug.Log(name);
        }
    }

    
   // создаем метод MergeSort для сортировки слиянием
    List<string> MergeSort(List<string> unsortedList)
    {
        // Если список содержит один элемент или пуст, возвращаем его без изменений

        if (unsortedList.Count <= 1)
            return unsortedList;

        // Создаем два новых списка для хранения левой и правой частей исходного списка
        List<string> left = new List<string>();
        List<string> right = new List<string>();

        // Находим индекс середины исходного списка
        int middle = unsortedList.Count / 2;

        // Заполняем левый список элементами до середины исходного списка
        for (int i = 0; i < middle; i++)
        {
            left.Add(unsortedList[i]);
        }
        // Заполняем правый список элементами от середины до конца исходного списка
        for (int i = middle; i < unsortedList.Count; i++)
        {
            right.Add(unsortedList[i]);
        }

        // Вызываем MergeSort для левого и правого списков

        left = MergeSort(left);
        right = MergeSort(right);

        // Сливаем отсортированные левый и правый списки и возвращаем результат
        return Merge(left, right);
    }

    // Метод Merge принимает два отсортированных списка строк и сливает их в один отсортированный список
    List<string> Merge(List<string> left, List<string> right)
    {
        // Создаем новый список для хранения результата слияния

        List<string> result = new List<string>();

        // Пока оба списка не пусты, сравниваем их первые элементы и добавляем меньший в результат

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

        // Если в левом списке остались элементы, добавляем их в результат

        while (left.Count > 0)
        {
            result.Add(left[0]);
            left.RemoveAt(0);
        }

        // Если в правом списке остались элементы, добавляем их в результат

        while (right.Count > 0)
        {
            result.Add(right[0]);
            right.RemoveAt(0);
        }

        // Возвращаем результат слияния

        return result;
    }
   

}
