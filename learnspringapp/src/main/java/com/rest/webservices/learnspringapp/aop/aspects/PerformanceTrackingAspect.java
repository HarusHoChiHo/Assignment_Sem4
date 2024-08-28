package com.rest.webservices.learnspringapp.aop.aspects;

import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.annotation.Configuration;

@Configuration
@Aspect
public class PerformanceTrackingAspect {

    private Logger logger = LoggerFactory.getLogger(getClass());

    @Around("execution(* com.rest.webservices.learnspringapp.aop.*.*.*(..))")
    public Object findExecutionTime(ProceedingJoinPoint joinPoint) throws Throwable {
        long startTimeMillis = System.currentTimeMillis();

        Object returnValue = joinPoint.proceed();

        long endTimeMillis = System.currentTimeMillis();

        long executionTime = endTimeMillis - startTimeMillis;

        //logger.info("Around Aspect - {} Method executed in {} ms", joinPoint, executionTime);

        return returnValue;
    }
}
