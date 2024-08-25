package com.example.config;

import io.swagger.v3.oas.annotations.OpenAPIDefinition;
import io.swagger.v3.oas.models.OpenAPI;
import io.swagger.v3.oas.models.info.Info;
import io.swagger.v3.oas.models.servers.Server;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.netflix.zuul.filters.ZuulProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.ArrayList;
import java.util.List;

@OpenAPIDefinition
@Configuration
public class OpenAPIConfigs {
    private static final Logger log = LoggerFactory.getLogger(OpenAPIConfigs.class);

    @Value("${zuul.routes}")
    private List<ZuulProperties.ZuulRoute> routes;

    private List<Server> servers = new ArrayList<>();

    @Bean
    public OpenAPI myOpenAPI() {

        log.info("Configuration");
        log.info(String.valueOf(routes.size()));

        for (ZuulProperties.ZuulRoute route : routes) {
            log.info(route.getRoute(route.getUrl()).getFullPath());
        }

        Info info = new Info()
                .title("JavaSB")
                .version("1.0")
                .description("JavaSB API");

        return new OpenAPI().info(info).servers(servers);
    }

}
