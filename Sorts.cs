using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorts : MonoBehaviour
{
    int min, index, temp;
    int[] array = { 2, 4, 7, 8, 9, 6, 5, 3, 1, 10 };

    private void Start()
    {
        //Selection();
        //Bubble();
        //Insertion();
        //Quick(array, 0, 9);
    }
    void Selection() // 가장 작은 값을 앞으로 보내기
    {
        for(int i = 0; i < 10; i++)
        {
            min = 999;
            for(int j = i; j < 10; j++)
            {
                if(min > array[j])
                {
                    min = array[j];
                    index = j;
                }
            }
            temp = array[i];
            array[i] = array[index];
            array[index] = temp;
        }
        for(int i = 0; i < 10; i++)
        {
            Debug.Log(array[i]);
        }
    }

    void Bubble()
    { 
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 9 - i; j++)
            {
                if(array[j] > array[j + 1])
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        for(int i = 0; i < 10; i++)
        {
            print(array[i]);
        }
    }

    void insertion()
    {
        for (int i = 0; i < 9; i++)
        {
            int j;
            j = i;
            while(array[j] > array[j + 1])
            {
                temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
                j--;
            }
        }
        for(int i = 0; i < 10; i++)
        {
            print(array[i]);
        }
    }

    void Quick(int[] array, int start, int end)
    {
        if (start >= end) return;

        int pivot = start;
        int i = pivot + 1;
        int j = end;

        while(i <= j)
        {
            while(i <= end && array[i] <= array[pivot])
            {
                i++;
            }
            while(j > start && array[j] >= array[pivot])
            {
                j--;
            }

            if(i >= j)
            {
                break;
            }

            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        temp = array[j];
        array[j] = array[pivot];
        array[pivot] = temp;

        Quick(array, start, j - 1);
        Quick(array, j + 1, end);

        for(int index = 0; index < 10; index++)
        {
            print(array[index]);
        }
    }
    void Quick2(int[] arr, int start, int end)
    {
        if (start >= end)   // 원소가 1개일때
            return;

        int pivot = start;  // 피봇 값
        int i = start + 1;
        int j = end;

        while (i <= j)// 엇갈릴 때까지 반복
        {
            while(arr[i] <= arr[pivot])// 피봇 값보다 큰 값을 만날 때까지
            {
                i++;
            }

            while(j > start && arr[j] >= arr[pivot])// 피봇 값보다 작은 값을 만날 때까지
            {
                j--;
            }

            if(i > j)// 현재 엇갈린 상태면 피봇 값과 교체
            {
                temp = arr[j];
                arr[j] = arr[pivot];
                arr[pivot] = temp;
            }
            else
            {
                temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }

            Quick2(arr, start, j - 1);
            Quick2(arr, j + 1, end);
        }
    }
}
