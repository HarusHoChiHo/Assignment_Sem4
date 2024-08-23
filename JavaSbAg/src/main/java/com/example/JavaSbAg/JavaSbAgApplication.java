package com.example.JavaSbAg;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
public class JavaSbAgApplication {

	public static void main(String[] args) {
		SpringApplication.run(JavaSbAgApplication.class, args);
	}

}
