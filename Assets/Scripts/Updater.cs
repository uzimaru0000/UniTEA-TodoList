using UniTEA;
using System.Collections.Generic;
using System.Linq;

public class Updater : IUpdater<Model, Msg>
{
  Counter idCounter;

  public Updater()
  {
    idCounter = new Counter();
  }


  public (Model, Cmd<Msg>) Update(IMessenger<Msg> msg, Model model)
  {
    switch (msg)
    {
      case InputTodoMsg inputMsg:
        return (new Model(model)
        {
          inputStr = inputMsg.value
        }, Cmd<Msg>.none);

      case CreateTodoMsg createTodoMsg:
        return (new Model
        {
          inputStr = "",
          todoList = model.todoList.Concat(new Todo[] {new Todo {
            id = idCounter.GetValue(),
            title = model.inputStr,
            isDone = false
          }}).ToArray()
        }, Cmd<Msg>.none);

      case DeleteTodoMsg deleteTodoMsg:
        UnityEngine.Debug.Log(deleteTodoMsg.value);
        return (new Model(model)
        {
          todoList = model.todoList.Where(x => x.id != deleteTodoMsg.value).ToArray()
        }, Cmd<Msg>.none);

      case DoneTodoMsg doneTodoMsg:
        return (new Model(model)
        {
          todoList = model.todoList.Select(x =>
          {
            return x.id == doneTodoMsg.value
              ? new Todo(x)
              {
                isDone = !x.isDone
              }
              : x;
          }).ToArray()
        }, Cmd<Msg>.none);
    }
    return (model, Cmd<Msg>.none);
  }
}

class Counter
{

  private int counter;

  public Counter(int init)
  {
    counter = init;
  }
  public Counter()
  {
    counter = 0;
  }

  public int GetValue()
  {
    return counter++;
  }
}
