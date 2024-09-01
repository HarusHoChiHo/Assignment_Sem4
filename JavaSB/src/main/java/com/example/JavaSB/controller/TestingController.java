package com.example.JavaSB.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TestingController {

    @GetMapping(path = "/testing")
    @ResponseBody
    public String testing(){
        return "Testing Success";
    }

}
