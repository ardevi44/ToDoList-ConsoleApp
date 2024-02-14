using System;
using System.Collections.Generic;

namespace ToDoListApp
{

  public class ToDoList
  {
    private List<string> _TODOs;

    private string _userInput;

    private bool _isAppRunning = true;

    private string _lastToDoAdded;

    public void FillToDoList()
    {
      _TODOs = new List<string>() { };
      InsertToDo();
    }

    private List<string> GetToDos()
    {
      return _TODOs;
    }

    private void SetUserOption(string option)
    {
      _userInput = option;
    }

    private string GetUserInput()
    {
      return _userInput;
    }

    private void ShowOptionMessage()
    {
      var message =
      "\nWhat do you want to do?" +
      "\n[S]ee all TODOs" +
      "\n[A]dd a TODO" +
      "\n[R]emove a TODO" +
      "\n[E]xit" +
      "\n-> ";

      Console.Write(message);
      var option = Console.ReadLine();
      SetUserOption(option);
    }

    private void InsertToDo()
    {
      Console.Write("Hello!");
      do
      {
        ShowOptionMessage();
        switch (GetUserInput())
        {
          case "S":
          case "s":
            ShowAllToDos();
            break;
          case "A":
          case "a":
            // Add a new Task in the List
            AddNewToDo();
            break;
          case "R":
          case "r":
            // Remove a ToDo
            RemoveToDo();
            break;
          case "E":
          case "e":
            Console.WriteLine("Exit the app...");
            _isAppRunning = false;
            break;
          default:
            Console.WriteLine("Invalid option, try again");
            break;
        }
      } while (_isAppRunning);
    }

    private void ShowAllToDos()
    {
      int taskNumber = 1;
      if (_TODOs.Count == 0)
      {
        Console.WriteLine("\nNo TODOs have been added yet.\n");
        return;
      }
      Console.WriteLine("\n");
      foreach (var toDo in _TODOs)
      {
        Console.WriteLine($"{taskNumber}. {toDo}");
        taskNumber++;
      }
      Console.WriteLine("\n");
    }

    private void AddNewToDo()
    {
      bool isToDoEmpty;
      bool isToDoInList;
      do
      {
        isToDoEmpty = false;
        isToDoInList = false;

        Console.Write("\nEnter a TODO description: ");
        _lastToDoAdded = Console.ReadLine();

        if (_lastToDoAdded == String.Empty)
        {
          isToDoEmpty = true;
          Console.WriteLine("\nThe description cannot be empty");
        }
        else if (_TODOs.Contains(_lastToDoAdded))
        {
          isToDoInList = true;
          Console.WriteLine("\nThe description must be unique");
        }
        else
        {
          _TODOs.Add(_lastToDoAdded);
          Console.WriteLine($"\nTODO successfully added: \"{_lastToDoAdded}\"");
        }
      } while (isToDoEmpty || isToDoInList);
    }

    private void RemoveToDo()
    {
      if (_TODOs.Count == 0)
      {
        Console.WriteLine("No TODOs have been added yet.");
        return;
      }

      bool isIndexNumber;
      bool isIndexInRange;

      do
      {
        isIndexNumber = true;
        isIndexInRange = true;

        ShowAllToDos();

        Console.Write("Select the index of the TODO you want to remove: ");
        string index = Console.ReadLine();

        isIndexNumber = int.TryParse(index, out int indexNumber);

        if (index == String.Empty)
        {
          Console.WriteLine("Selected index cannot be empty");
        }
        else if (!isIndexNumber)
        {
          Console.WriteLine("The input is not a number");
        }
        else if (indexNumber < 1 || indexNumber > _TODOs.Count)
        {
          isIndexInRange = false;
          Console.WriteLine("The index doesn't match");
        }
        else
        {
          var toDoToRemove = _TODOs[indexNumber - 1];
          _TODOs.RemoveAt(indexNumber - 1);
          Console.WriteLine($"TODO removed: {toDoToRemove}");
        }
      } while (!isIndexNumber || !isIndexInRange);
    }
  }
}