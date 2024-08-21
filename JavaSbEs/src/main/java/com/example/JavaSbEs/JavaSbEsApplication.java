package com.example.JavaSbEs;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@SpringBootApplication
@EnableEurekaServer
public class JavaSbEsApplication {

	public static void main(String[] args) {

		SpringApplication.run(JavaSbEsApplication.class, args);
	}

}
