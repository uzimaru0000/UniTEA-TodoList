using UniTEA;

public class CreateTodoMsg : IMessenger<Msg>
{
  public Msg GetMessage() => Msg.CreateTodo;
}
