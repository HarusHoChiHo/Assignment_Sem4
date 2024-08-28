package com.example.springboot.myfirstwebapp.security;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.Customizer;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configurers.AbstractHttpConfigurer;
import org.springframework.security.config.annotation.web.configurers.HeadersConfigurer;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.provisioning.InMemoryUserDetailsManager;
import org.springframework.security.web.SecurityFilterChain;

import java.util.function.Function;

@Configuration
public class SpringSecurityConfiguration {

    @Bean
    public InMemoryUserDetailsManager createUserDetailsManager() {
        Function<String, String> passwordEncoder = input -> new BCryptPasswordEncoder().encode(input);
        UserDetails userDetails_origin = getUserDetails(passwordEncoder, "in28minutes", "dummy");
        UserDetails userDetails_second = getUserDetails(passwordEncoder, "ranga", "dummy");
        return new InMemoryUserDetailsManager(userDetails_origin, userDetails_second);
    }

    private static UserDetails getUserDetails(Function<String, String> passwordEncoder, String username, String password) {
        return User.builder()
                   .passwordEncoder(passwordEncoder)
                   .username(username)
                   .password(password)
                   .roles( "USER", "ADMIN")
                   .build();
    }

    @Bean
    public PasswordEncoder passwordEncoder() {
        return new BCryptPasswordEncoder();
    }

    @Bean
    public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
        http.authorizeHttpRequests(auth -> auth.anyRequest().authenticated());

        http.csrf(AbstractHttpConfigurer::disable);
        http.headers(headers -> headers.frameOptions(HeadersConfigurer.FrameOptionsConfig::disable));
        http.formLogin(Customizer.withDefaults());

        return http.build();
    }
}
