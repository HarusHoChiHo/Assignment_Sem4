package com.example.springboot.myfirstwebapp.todo;

import com.example.springboot.myfirstwebapp.todo.Repositories.TodoRepository;
import jakarta.validation.Valid;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.SessionAttributes;

import java.time.LocalDate;

@Controller
@SessionAttributes("name")
public class TodoControllerJpa {

    private TodoService todoService;

    private TodoRepository todoRepository;

    public TodoControllerJpa(TodoService todoService, TodoRepository todoRepository) {
        super();
        this.todoService = todoService;
        this.todoRepository = todoRepository;
    }

    @RequestMapping(value = "/list-todos")
    public String listAllTodos(ModelMap model) {
        model.addAttribute("todos", todoRepository.findByUsername(getLoggedinUserName(model).toString()));

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

        todo.setUsername(todo.getUsername());
        todoRepository.save(todo);
        //todoService.addTodo(todo.getUsername(), todo.getDescription(), todo.getTargetDate(), todo.isDone());
        return "redirect:list-todos";
    }

    @RequestMapping(value = "/delete-todo")
    public String deleteTodo(@RequestParam int id) {
        //todoService.deleteById(id);
        todoRepository.deleteById(id);
        return "redirect:list-todos";
    }

    @RequestMapping(value = "/update-todo", method = RequestMethod.GET)
    public String showUpdateTodoPage(@RequestParam int id, ModelMap model) {
        model.addAttribute("todo", todoRepository.findById(id).get());
        return "todo";
    }

    @RequestMapping(value = "/update-todo", method = RequestMethod.POST)
    public String updateTodo(ModelMap model, @Valid Todo todo, BindingResult result) {

        if (result.hasErrors()) {
            return "todo";
        }

        //todoService.updateTodo(todo);
        todo.setUsername(model.get("name").toString());
        todoRepository.save(todo);
        return "redirect:list-todos";
    }

    private Object getLoggedinUserName(ModelMap model) {
        return model.get("name");
    }
}
