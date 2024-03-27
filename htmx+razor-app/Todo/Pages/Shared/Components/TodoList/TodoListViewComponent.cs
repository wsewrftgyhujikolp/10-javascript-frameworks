using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;


public class CardViewComponent : ViewComponent
{
   
    public IViewComponentResult Invoke()
    {
        foreach (KeyValuePair<string, object> item in this.ViewData)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }

        return View(new TodoListViewModel()
        {
            Todos = new List<TodoItem>()
            {
                new TodoItem() { Text = "Learn .NET Core", IsDone = true, Id = 1 },
            }
        });
    }
}