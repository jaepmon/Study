using System;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

namespace Algorithm
{
    
     class MyLinkedListNode<T>
     {
         public T Data;
         public LinkedListNode<T> Next;
         public LinkedListNode<T> Prev;
     }
    
     class MyLinkedList<T>
     {
         public MyLinkedListNode<T> head = null;
         public MyLinkedListNode<T> tail = null;
         public int count = 0;
    
         public MyLinkedListNode<T> AddLast(T data)
         {
             MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
             newRoom.Data = data;
    
    
             if (head == null)
             {
                 head = newRoom;
             }
             if (tail != null)
             {
                 tail.Next = newRoom;
                 newRoom.Prev = tail;
             }
    
             tail = newRoom;
             count++;
    
             return newRoom;
         }
         public void Remove(MyLinkedListNode<T> room)
         {
             if (room == head)
             {
                 head = head.Next;
             }
             if (room == tail)
             {
                 tail = tail.Prev;
             }
             if (room.Prev != null)
             {
                 room.Prev.Next = room.Next;
             }
             if (room.Next != null)
             {
                 room.Next.Prev = room.Prev;
             }
             count--;
         }
     }
    
}
