package Swagger;

import io.swagger.v3.oas.models.OpenAPI;
import io.swagger.v3.oas.models.info.Info;
import org.springdoc.core.models.GroupedOpenApi;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import javax.swing.*;

@Configuration
public class OpenAPIConfig {

    @Bean
    public GroupedOpenApi productAPI() {
        return GroupedOpenApi.builder().group("product").pathsToMatch("/api/product/**").build();
    }

    @Bean
    public OpenAPI customOpenAPI() {
        return new OpenAPI().info(new Info().title("Aggregated Microservices API").version("1.0").description("API " +
                "document for all microservices"));
    }
}
