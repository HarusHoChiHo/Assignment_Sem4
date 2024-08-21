package com.example.JavaSbProduct;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
public class JavaSbProductApplication {

	public static void main(String[] args) {
		SpringApplication.run(JavaSbProductApplication.class, args);
	}

}
