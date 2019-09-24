using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UpdateTest
{
  [Test]
  public void InputMsgTest()
  {
    var model = new Model
    {
      inputStr = "",
      todoList = new Todo[] { },
    };
    var updater = new Updater();

    var (newModel, _) = updater.Update(new InputTodoMsg("hoge"), model);
    Assert.AreEqual(newModel.inputStr, "hoge");
  }

  [Test]
  public void CreateMsgTest()
  {
    var model = new Model
    {
      inputStr = "hoge",
      todoList = new Todo[] { }
    };
    var updater = new Updater();

    var (newModel, _) = updater.Update(new CreateTodoMsg(), model);
    Assert.That(newModel.todoList, Is.EqualTo(new Todo[] {
      new Todo
      {
        id = 0,
        title = "hoge",
        isDone = false
      }
    }));
  }

  [Test]
  public void DeleteMsgTest()
  {
    var model = new Model
    {
      inputStr = "",
      todoList = new Todo[] {
        new Todo
        {
          id = 0,
          title = "hoge",
          isDone = false
        }
      }
    };
    var updater = new Updater();

    var (newModel, _) = updater.Update(new DeleteTodoMsg(0), model);
    Assert.That(newModel.todoList, Is.EqualTo(new Todo[] { }));
  }

  [Test]
  public void DoneMsgTest()
  {
    var model = new Model
    {
      inputStr = "",
      todoList = new Todo[] {
        new Todo
        {
          id = 0,
          title = "hoge",
          isDone = false
        }
      }
    };
    var updater = new Updater();

    var (newModel, _) = updater.Update(new DoneTodoMsg(0), model);
    Assert.That(newModel.todoList, Is.EqualTo(new Todo[]
    {
      new Todo
      {
        id = 0,
        title = "hoge",
        isDone = true
      }
    }));
  }
}
