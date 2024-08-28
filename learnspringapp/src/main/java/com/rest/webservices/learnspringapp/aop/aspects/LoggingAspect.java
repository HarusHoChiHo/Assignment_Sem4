package com.rest.webservices.learnspringapp.aop.aspects;

import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.annotation.Configuration;

@Configuration
@Aspect
public class LoggingAspect {

    private Logger logger = LoggerFactory.getLogger(getClass());

    @Before("com.rest.webservices.learnspringapp.aop.aspects.CommonPointcutConfig.trackTimeAnnotation()")
    public void logMethodCallBeforeExec(JoinPoint joinPoint) {
        logger.info("Before Annotation Aspect - Method is called - {} with arguments: {}", joinPoint, joinPoint.getArgs());
    }

//    @Before("com.rest.webservices.learnspringapp.aop.aspects.CommonPointcutConfig.businessAndDataPackageConfig()")
//    public void logMethodCallBeforeExec(JoinPoint joinPoint) {
//        logger.info("Before Aspect - Method is called - {} with arguments: {}", joinPoint, joinPoint.getArgs());
//    }
//
//    @Before("com.rest.webservices.learnspringapp.aop.aspects.CommonPointcutConfig.businessPackageConfig()")
//    public void logMethodCallBeforeBusinessExec(JoinPoint joinPoint) {
//        logger.info("Before Business Aspect - Method is called - {} with arguments: {}", joinPoint, joinPoint.getArgs());
//    }
//
//    @Before("com.rest.webservices.learnspringapp.aop.aspects.CommonPointcutConfig.dataPackageConfigUsingBean()")
//    public void logMethodCallBeforeBean(JoinPoint joinPoint) {
//        logger.info("Before Bean Aspect - Method is called - {} with arguments: {}", joinPoint, joinPoint.getArgs());
//    }
//
//    @After("com.rest.webservices.learnspringapp.aop.aspects.CommonPointcutConfig.businessAndDataPackageConfig()")
//    public void logMethodCallAfterExec(JoinPoint joinPoint) {
//        logger.info("After Aspect - {} has executed with arguments: {}", joinPoint, joinPoint.getArgs());
//    }
//
//    @AfterThrowing(pointcut = "com.rest.webservices.learnspringapp.aop.aspects.CommonPointcutConfig.businessAndDataPackageConfig()", throwing = "exception")
//    public void logMethodCallAfterThrow(JoinPoint joinPoint, Exception exception) {
//        logger.info("After Throw Aspect - {} throws exception: {} with arguments: {}", joinPoint, exception.getMessage(), joinPoint.getArgs());
//    }
//
//    @AfterReturning(pointcut = "com.rest.webservices.learnspringapp.aop.aspects.CommonPointcutConfig.dataPackageConfig()", returning = "resultValue")
//    public void logMethodCallAfterThrow(JoinPoint joinPoint, Object resultValue) {
//        logger.info("After Returning Aspect - {} returns: {} with arguments: {}", joinPoint, resultValue, joinPoint.getArgs());
//    }

}
