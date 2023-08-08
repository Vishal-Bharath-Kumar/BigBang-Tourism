import React, { useState, useEffect } from "react";
import './TodoList.css';
import UserNavbar from "../User Navbar/UserNavbar";

const TodoList = () => {
  const [todos, setTodos] = useState([]);
  const [inputValue, setInputValue] = useState("");
  const [editingIndex, setEditingIndex] = useState(null);

  useEffect(() => {
    try {
      const storedTodos = localStorage.getItem("todos");
      if (storedTodos) {
        console.log("Loading todos from local storage...");
        const parsedTodos = JSON.parse(storedTodos);
        setTodos(parsedTodos);
      } else {
        console.log("No todos found in local storage. Initializing with an empty array.");
        setTodos([]);
      }
    } catch (error) {
      console.error("Error loading todos from local storage:", error);
    }
  }, []);

  useEffect(() => {
    try {
      console.log("Saving todos to local storage...");
      localStorage.setItem("todos", JSON.stringify(todos));
    } catch (error) {
      console.error("Error saving todos to local storage:", error);
    }
  }, [todos]);

  const handleInputChange = (e) => {
    setInputValue(e.target.value);
  };

  const addTodo = () => {
    if (inputValue.trim() === "") {
      return;
    }
    if (editingIndex !== null) {
      // Update existing todo
      setTodos((prevTodos) => {
        const updatedTodos = [...prevTodos];
        updatedTodos[editingIndex] = {
          ...updatedTodos[editingIndex],
          text: inputValue,
        };
        return updatedTodos;
      });
      setEditingIndex(null);
    } else {
      // Add new todo
      setTodos((prevTodos) => [
        ...prevTodos,
        { id: Date.now(), text: inputValue, completed: false },
      ]);
    }
    setInputValue("");
  };

  const deleteTodo = (index) => {
    setTodos((prevTodos) => prevTodos.filter((todo, i) => i !== index));
  };

  const editTodo = (index) => {
    setInputValue(todos[index].text);
    setEditingIndex(index);
  };

  const toggleTodo = (index) => {
    setTodos((prevTodos) => {
      const updatedTodos = [...prevTodos];
      updatedTodos[index] = {
        ...updatedTodos[index],
        completed: !updatedTodos[index].completed,
      };
      return updatedTodos;
    });
  };

  const completedCount = todos.filter((todo) => todo.completed).length;
  const remainingCount = todos.length - completedCount;

  

  return (
    <>
    <div className="TodoListBody">
      <UserNavbar />
      <div className="Todo">
        <h1 className="typing">Spark Planner</h1>
        <input
          className="TodoTextInput"
          type="text"
          placeholder="Add your plan..."
          value={inputValue}
          onChange={handleInputChange}
        />
        <button className="TodoButton" onClick={addTodo}>
          {editingIndex !== null ? "Update Plan" : "Add Plan"}
        </button>

        <ul className="TodoUl">
          {todos.map((todo, index) => (
            <li
              className="TodoLi"
              key={todo.id}
              style={{ textDecoration: todo.completed ? "line-through" : "none" }}
            >
              <input
                type="checkbox"
                checked={todo.completed}
                onChange={() => toggleTodo(index)}
              />
              {todo.text}
              <button className="TodoEditButton" onClick={() => editTodo(index)}>Edit</button>
              <button className="TodoDeleteButton" onClick={() => deleteTodo(index)}>Delete</button>
            </li>
          ))}
        </ul>
        <div className="TodoStatus">
          <div>
            <p>
              <span className="TodoCounter">Completed:</span> {completedCount}/{todos.length}
            </p>
          </div>
          <div>
            <p><span className="TodoCounter">Remaining:</span> {remainingCount}</p>
          </div>
        </div>
      </div>
      </div>
    </>
  );
};

export default TodoList;
