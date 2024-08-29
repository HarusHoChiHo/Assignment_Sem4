package com.example.JavaSB.Services;

import com.example.JavaSB.Repositories.UserDetailsRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class JSBUserDetailsService implements UserDetailsService {

    UserDetailsRepository userDetailsRepository;


    public JSBUserDetailsService(UserDetailsRepository userDetailsRepository) {
        this.userDetailsRepository = userDetailsRepository;
    }

    @Override
    public UserDetails loadUserByUsername(String userName){
        UserDetails userDetails = userDetailsRepository.findByUserName(userName);

        if (userDetails == null){
            throw new UsernameNotFoundException(userName);
        }

        return userDetails;
    }
}
