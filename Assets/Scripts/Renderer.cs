using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniTEA;
using UI = UnityEngine.UI;
using EventSystems = UnityEngine.EventSystems;

public class Renderer : MonoBehaviour, IRenderer<Model>
{

  [SerializeField]
  UI.InputField input;

  [SerializeField]
  TodoListRenderer todoListRenderer;

  public void Render(Model model)
  {
    input.text = model.inputStr;
    todoListRenderer.Render(new TodoList(model.todoList));
  }
}
