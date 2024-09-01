package com.example.JavaSbAg.config;

import com.netflix.config.ConfigurationManager;
import io.swagger.v3.oas.annotations.OpenAPIDefinition;
import io.swagger.v3.oas.models.OpenAPI;
import io.swagger.v3.oas.models.info.Info;
import io.swagger.v3.oas.models.servers.Server;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.netflix.zuul.filters.ZuulProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

@OpenAPIDefinition
@Configuration
public class OpenAPIConfigs {
    private static final Logger log = LoggerFactory.getLogger(OpenAPIConfigs.class);

//    @Value("${zuul}")
//    private ZuulProperties properties;

    private List<Server> servers = new ArrayList<>();

    @Bean
    public OpenAPI myOpenAPI() {

        log.info("Configuration");
        //log.info(String.valueOf(properties.getRoutes().size()));

        //properties.getRoutes().forEach((key, value) -> log.info("Key: {}, value: {}", key, value));

        Info info = new Info()
                .title("JavaSB")
                .version("1.0")
                .description("JavaSB API");

        return new OpenAPI().info(info).servers(servers);
    }

}
