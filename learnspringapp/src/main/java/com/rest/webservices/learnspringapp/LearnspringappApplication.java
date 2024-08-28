package com.rest.webservices.learnspringapp;

import com.rest.webservices.learnspringapp.aop.business.BusinessService1;
import com.rest.webservices.learnspringapp.aop.business.BusinessService2;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class LearnspringappApplication implements CommandLineRunner {

	private Logger logger = LoggerFactory.getLogger(getClass());

	private BusinessService1 businessService1;
	private BusinessService2 businessService2;

	public LearnspringappApplication(BusinessService1 businessService1, BusinessService2 businessService2) {
		this.businessService1 = businessService1;
		this.businessService2 = businessService2;
	}

	public static void main(String[] args) {
		SpringApplication.run(LearnspringappApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		logger.info("Max Value returned is {}", businessService1.calculateMax());
		logger.info("Min Value returned is {}", businessService2.calculateMin());
	}
}
