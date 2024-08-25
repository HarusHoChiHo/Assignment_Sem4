package com.example.Repositories;

import com.example.Models.JSBUserDetails;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UserDetailsRepository extends JpaRepository<JSBUserDetails, Integer> {
    JSBUserDetails findByName(String name);
    JSBUserDetails findByUserName(String userName);
}
