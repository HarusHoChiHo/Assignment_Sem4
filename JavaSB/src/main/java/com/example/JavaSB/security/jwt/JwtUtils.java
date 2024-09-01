package com.example.JavaSB.security.jwt;

import com.example.JavaSB.security.JsbUserDetails;
import io.jsonwebtoken.*;
import io.jsonwebtoken.io.Decoders;
import io.jsonwebtoken.security.Keys;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.stereotype.Component;

import javax.crypto.SecretKey;
import java.nio.charset.StandardCharsets;
import java.util.Date;
import java.util.List;

@Component
public class JwtUtils {

    @Value("${auth.token.jwSecret}")
    private String jwtSecret;

    @Value("${auth.token.expirationInMils}")
    private int expirationTime;

    public String generateTokenForUser(Authentication authentication) {
        JsbUserDetails principal = (JsbUserDetails) authentication.getPrincipal();

        List<String> roles = principal.getAuthorities()
                                      .stream()
                                      .map(GrantedAuthority::getAuthority)
                                      .toList();

        return Jwts.builder()
                   .subject(principal.getEmail())
                   .claim("id", principal.getId())
                   .claim("roles", roles)
                   .issuedAt(new Date())
                   .expiration(new Date(new Date().getTime() + expirationTime))
                   .signWith(key())
                   .compact();
    }

    private SecretKey key() {
        return Keys.hmacShaKeyFor(jwtSecret.getBytes(StandardCharsets.UTF_8));
    }

    public boolean validateToken(String token) {
        try {
            Jwts.parser()
                .verifyWith(key())
                .build()
                .parseSignedClaims(token);
            return true;
        } catch (ExpiredJwtException | UnsupportedJwtException | MalformedJwtException |
                 IllegalArgumentException exception) {
            throw new JwtException(exception.getMessage());
        }
    }

    public String getUsernameFromToken(String token) {
        return Jwts.parser()
                   .verifyWith(key())
                   .build()
                   .parseSignedClaims(token)
                   .getPayload()
                   .getSubject();
    }
}
