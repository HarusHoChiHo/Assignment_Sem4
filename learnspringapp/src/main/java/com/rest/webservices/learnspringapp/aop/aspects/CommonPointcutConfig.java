package com.rest.webservices.learnspringapp.aop.aspects;

import org.aspectj.lang.annotation.Pointcut;

public class CommonPointcutConfig {


    @Pointcut("execution(* com.rest.webservices.learnspringapp.aop.*.*.*(..))")
    public void businessAndDataPackageConfig() {

    }

    @Pointcut("execution(* com.rest.webservices.learnspringapp.aop.business.*.*(..))")
    public void businessPackageConfig() {

    }

    @Pointcut("execution(* com.rest.webservices.learnspringapp.aop.data.*.*(..))")
    public void dataPackageConfig() {

    }

    @Pointcut("bean(*Service*)")
    public void dataPackageConfigUsingBean(){}

    @Pointcut("@annotation(com.rest.webservices.learnspringapp.aop.annotation.TrackTime)")
    public void trackTimeAnnotation(){}

}
