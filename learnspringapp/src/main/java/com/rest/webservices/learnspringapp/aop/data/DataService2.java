package com.rest.webservices.learnspringapp.aop.data;

import org.springframework.stereotype.Component;

@Component
public class DataService2 {

    public int[] retrieveData() {
        return new int[] {11, 22, 33};
    }

}
