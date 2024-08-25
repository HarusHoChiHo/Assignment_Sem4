package com.example.Components;

import com.example.Models.JSBUserDetails;
import com.example.Services.JSBUserDetailsService;
import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.security.Keys;
import io.jsonwebtoken.security.Password;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Component;

import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.function.Function;

@Component
public class JwtTokenUtil {

    @Autowired
    private JSBUserDetailsService jsbUserDetailsService;

    @Value("${jwt.secret}")
    private String secret;

    private static Password key;

    private static final long JWT_TOKEN_VALIDITY = 5 * 60 * 60;

    public JwtTokenUtil() {
        key = Keys.password(secret.toCharArray());
    }

    public String getUsernameFromToken(String token) {
        return getClaimFromToken(token, Claims::getSubject);
    }

    public Date getExpirationDateFromToken(String token) {
        return getClaimFromToken(token, Claims::getExpiration);
    }

    public <T> T getClaimFromToken(String token, Function<Claims, T> claimsResolver) {
        final Claims claims = getAllClaimsFromToken(token);
        return claimsResolver.apply(claims);
    }

    public Boolean validateToken(String token, UserDetails userDetails){
        final String username = getUsernameFromToken(token);
        return (username.equals(userDetails.getUsername())) && !isTokenExpired(token);
    }

    public Boolean validateToken(String token, String username){
        final String usernameFromToken = getUsernameFromToken(token);
        return (username.equals(usernameFromToken)) && !isTokenExpired(token);
    }

    public Boolean validateToken(String token){
        final UserDetails userDetails = jsbUserDetailsService.loadUserByUsername(getUsernameFromToken(token));
        return (userDetails != null && !isTokenExpired(token));
    }

    public String generateToken(UserDetails userDetails){
        Map<String, Object> claims = new HashMap<>();
        return doGenerateToken(claims, userDetails.getUsername());
    }

    private Claims getAllClaimsFromToken(String token) {
        return Jwts.parser().verifyWith(key).build().parseSignedClaims(token).getPayload();
    }

    private Boolean isTokenExpired(String token) {
        final Date expiration = getExpirationDateFromToken(token);
        return expiration.before(new Date());
    }

    private String doGenerateToken(Map<String, Object> claims, String subject) {
        return Jwts.builder().claims(claims).subject(subject).issuedAt(new Date(System.currentTimeMillis())).expiration(new Date(System.currentTimeMillis())).signWith(key).compact();
    }

}
