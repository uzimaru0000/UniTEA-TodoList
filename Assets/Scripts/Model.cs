using System.Collections.Generic;
using UniTEA;

public struct Model
{
  public string inputStr;
  public Todo[] todoList;

  public Model(Model old)
  {
    this = old;
  }

  public static (Model, Cmd<Msg>) Init() => (
    new Model
    {
      inputStr = "",
      todoList = new Todo[] { }
    },
    Cmd<Msg>.none
  );
}

public struct Todo
{
  public int id;
  public string title;
  public bool isDone;

  public Todo(Todo old)
  {
    this = old;
  }
}
