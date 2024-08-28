package com.example.springboot.myfirstwebapp.todo;

import jakarta.validation.Valid;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.SessionAttributes;

import java.time.LocalDate;

//@Controller
@SessionAttributes("name")
public class TodoController {

    private TodoService todoService;

    public TodoController(TodoService todoService) {
        super();
        this.todoService = todoService;
    }

    @RequestMapping(value = "/list-todos")
    public String listAllTodos(ModelMap model) {
        model.addAttribute("todos", todoService.findByUsername(getLoggedinUserName(model).toString()));
        return "listTodos";
    }

    @RequestMapping(value = "/add-todo", method = RequestMethod.GET)
    public String showNewTodoPage(ModelMap model) {

        model.addAttribute("todo", new Todo(0, model.containsKey("name") ? getLoggedinUserName(model).toString() : "", "Default Desc", LocalDate.now(), false));
        return "todo";
    }


    @RequestMapping(value = "/add-todo", method = RequestMethod.POST)
    public String addNewTodo(@Valid Todo todo, BindingResult result) {

        if (result.hasErrors()) {
            return "todo";
        }

        todoService.addTodo(todo.getUsername(), todo.getDescription(), todo.getTargetDate(), false);
        return "redirect:list-todos";
    }

    @RequestMapping(value = "/delete-todo")
    public String deleteTodo(@RequestParam int id) {
        todoService.deleteById(id);
        return "redirect:list-todos";
    }

    @RequestMapping(value = "/update-todo", method = RequestMethod.GET)
    public String showUpdateTodoPage(@RequestParam int id, ModelMap model) {
        model.addAttribute("todo", todoService.findById(id));
        return "todo";
    }

    @RequestMapping(value = "/update-todo", method = RequestMethod.POST)
    public String updateTodo(@Valid Todo todo, BindingResult result) {

        if (result.hasErrors()) {
            return "todo";
        }

        todoService.updateTodo(todo);
        return "redirect:list-todos";
    }

    private Object getLoggedinUserName(ModelMap model) {
        return model.get("name");
    }
}
