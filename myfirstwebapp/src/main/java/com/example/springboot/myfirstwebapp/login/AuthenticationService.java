package com.example.springboot.myfirstwebapp.login;

import org.springframework.stereotype.Service;

@Service
public class AuthenticationService {

    public boolean authenticate(String username, String password) {
        // in real world, this method would connect to a database to authenticate the user
        return username.equalsIgnoreCase("in28minutes") && password.equals("dummy");
    }
}
