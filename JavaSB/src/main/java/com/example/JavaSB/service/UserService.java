package com.example.JavaSB.service;

import com.example.JavaSB.model.User;
import com.example.JavaSB.repository.UserRepository;

public class UserService implements IUserService{

    private final UserRepository userRepository;

    public UserService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public User getUserById(Integer userId) {
        return userRepository.findById(userId).orElseThrow();
    }

    @Override
    public User getAuthenticatedUser() {
        return null;
    }
}
