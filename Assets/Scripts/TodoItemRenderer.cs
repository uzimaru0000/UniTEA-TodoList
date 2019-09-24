using UnityEngine;
using UI = UnityEngine.UI;
using UniTEA;

public class TodoItemRenderer : MonoBehaviour, IRenderer<Todo>
{
  [SerializeField]
  UI.Text titleView;

  [SerializeField]
  UI.Button toggle;

  [SerializeField]
  GameObject doneView;

  [SerializeField]
  UI.Button deleteButton;

  public void Render(Todo todo)
  {
    titleView.text = todo.title;
    titleView.color = todo.isDone ? Color.gray : Color.black;
    doneView.SetActive(todo.isDone);

    toggle.onClick.RemoveAllListeners();
    toggle
      .onClick
      .AddListener(() => UniTEAManager.TEA.Dispatch(new DoneTodoMsg(todo.id)));

    deleteButton.onClick.RemoveAllListeners();
    deleteButton
      .onClick
      .AddListener(() => UniTEAManager.TEA.Dispatch(new DeleteTodoMsg(todo.id)));
  }
}