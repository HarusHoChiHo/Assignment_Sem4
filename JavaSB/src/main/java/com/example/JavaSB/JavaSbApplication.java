package com.example.JavaSB;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
public class JavaSbApplication {
	public static void main(String[] args) {

		SpringApplication.run(JavaSbApplication.class, args);

	}


}
