package com.rest.webservices.restful_web_services.todo;

import jakarta.validation.Valid;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Service
public class TodoService {
    private static List<Todo> todos = new ArrayList<>();

    private static int todoCount = 0;

    static {
        todos.add(new Todo(++todoCount, "in28minutes", "Learn AWS", LocalDate.now()
                                                                             .plusYears(1), false));
        todos.add(new Todo(++todoCount, "in28minutes", "Learn DevOps", LocalDate.now()
                                                                                .plusYears(1), false));
        todos.add(new Todo(++todoCount, "in28minutes", "Learn Hibernate", LocalDate.now()
                                                                                   .plusYears(1), false));
    }

    public TodoService() {
    }

    public List<Todo> findByUsername(String username) {

        todos.stream().map(todo -> todo.getUsername().equals(username)).forEach(System.out::println);

        return todos.stream()
                    .filter(todo -> todo.getUsername().equals(username))
                    .toList();
    }

    public void addTodo(String name, String description, LocalDate targetDate, boolean isDone) {
        todos.add(new Todo(++todoCount, name, description, targetDate, isDone));
    }

    public void deleteById(int id) {
        todos.removeIf(todo -> todo.getId() == id);
    }

    public Todo findById(int id) {
        return todos.stream()
                    .filter(todo -> todo.getId() == id)
                    .findFirst()
                    .get();
    }

    public void updateTodo(@Valid Todo todo) {
        deleteById(todo.getId());
        todos.add(todo);
    }
}
