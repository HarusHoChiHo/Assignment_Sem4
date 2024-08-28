package com.rest.webservices.learnspringapp.aop.data;

import org.springframework.stereotype.Component;

@Component
public class DataService1 {

    public int[] retrieveData() {
        return new int[] {1, 2, 3};
    }

}
