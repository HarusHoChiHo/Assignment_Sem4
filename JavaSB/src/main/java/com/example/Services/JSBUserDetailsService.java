package com.example.Services;

import com.example.Repositories.UserDetailsRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class JSBUserDetailsService implements UserDetailsService {
    @Autowired
    UserDetailsRepository userDetailsRepository;

    @Override
    public UserDetails loadUserByUsername(String userName){
        UserDetails userDetails = userDetailsRepository.findByUserName(userName);

        if (userDetails == null){
            throw new UsernameNotFoundException(userName);
        }

        return userDetails;
    }
}
