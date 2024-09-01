package com.example.JavaSB.service;

import com.example.JavaSB.model.User;

public interface IUserService {

    User getUserById(Integer userId);

    User getAuthenticatedUser();
}
