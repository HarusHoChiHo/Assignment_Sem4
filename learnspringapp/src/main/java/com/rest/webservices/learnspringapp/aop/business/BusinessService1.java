package com.rest.webservices.learnspringapp.aop.business;

import com.rest.webservices.learnspringapp.aop.annotation.TrackTime;
import com.rest.webservices.learnspringapp.aop.data.DataService1;
import org.springframework.stereotype.Service;

import java.util.Arrays;

@Service
public class BusinessService1 {

    private DataService1 dataService1;

    public BusinessService1(DataService1 dataService1) {
        this.dataService1 = dataService1;
    }

    @TrackTime
    public int calculateMax(){
        int[] data = dataService1.retrieveData();
        //throw new RuntimeException("Exception in calculateMax");
        return Arrays.stream(data).max().orElse(Integer.MIN_VALUE);
    }

    public void calculateSum() {
        int[] data = dataService1.retrieveData();
        int sum = 0;
        for (int value : data) {
            sum += value;
        }
        System.out.println("Sum: " + sum);
    }

}
