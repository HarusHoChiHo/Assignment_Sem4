package com.rest.webservices.learnspringapp.aop.business;

import com.rest.webservices.learnspringapp.aop.annotation.TrackTime;
import com.rest.webservices.learnspringapp.aop.data.DataService1;
import com.rest.webservices.learnspringapp.aop.data.DataService2;
import org.springframework.stereotype.Service;

import java.util.Arrays;

@Service
public class BusinessService2 {

    private DataService2 dataService2;

    public BusinessService2(DataService2 dataService2) {
        this.dataService2 = dataService2;
    }

    @TrackTime
    public int calculateMin(){
        int[] data = dataService2.retrieveData();
        //throw new RuntimeException("Exception in calculateMax");
        return Arrays.stream(data).min().orElse(Integer.MIN_VALUE);
    }

    public void calculateSum() {
        int[] data = dataService2.retrieveData();
        int sum = 0;
        for (int value : data) {
            sum += value;
        }
        System.out.println("Sum: " + sum);
    }

}
