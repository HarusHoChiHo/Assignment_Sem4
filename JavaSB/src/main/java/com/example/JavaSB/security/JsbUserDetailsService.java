package com.example.JavaSB.security;

import com.example.JavaSB.model.User;
import com.example.JavaSB.repository.UserRepository;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import javax.swing.text.html.Option;
import java.util.Optional;

@Service
public class JsbUserDetailsService implements UserDetailsService {

    private final UserRepository userRepository;

    public JsbUserDetailsService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException {
        User user = Optional.ofNullable(userRepository.findByEmail(email)).orElseThrow(() -> new UsernameNotFoundException("User Not Found!"));

        return JsbUserDetails.buildJsbUserDetails(user);
    }
}
