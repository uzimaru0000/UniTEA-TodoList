using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UI = UnityEngine.UI;
using UniTEA;

public struct TodoList
{
  public IEnumerable<Todo> list;

  public TodoList(IEnumerable<Todo> _list)
  {
    list = _list;
  }
}

[RequireComponent(typeof(UI.ScrollRect))]
public class TodoListRenderer : MonoBehaviour, IRenderer<TodoList>
{
  [SerializeField]
  TodoItemRenderer todoItemRenderer;

  UI.ScrollRect scrollRect;
  UI.ScrollRect ScrollRect
  {
    get
    {
      if (!scrollRect)
      {
        scrollRect = GetComponent<UI.ScrollRect>();
      }

      return scrollRect;
    }
  }

  int scrollItemsNum
  {
    get => ScrollRect.content.childCount;
  }

  public void Render(TodoList todoList)
  {
    if (todoList.list == null) return;

    if (scrollItemsNum < todoList.list.Count())
    {
      var createItemNum = todoList.list.Count() - scrollItemsNum;

      for (var i = 0; i < createItemNum; i++)
      {
        Instantiate(todoItemRenderer, ScrollRect.content);
      }
    }

    foreach (Transform go in ScrollRect.content)
    {
      go.gameObject.SetActive(false);
    }

    for (var i = 0; i < todoList.list.Count(); i++)
    {
      Debug.Log(i);
      var item = todoList.list.ElementAt(i);
      var listItem = ScrollRect.content.GetChild(i);
      listItem.gameObject.SetActive(true);
      listItem.GetComponent<TodoItemRenderer>().Render(item);
    }
  }
}