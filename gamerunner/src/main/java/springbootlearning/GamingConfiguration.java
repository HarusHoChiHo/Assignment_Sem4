package springbootlearning;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import springbootlearning.game.GameRunner;
import springbootlearning.game.GamingConsole;
import springbootlearning.game.PacmanGame;

@Configuration
public class GamingConfiguration {

    @Bean
    public GamingConsole game(){
        return new PacmanGame();
    }

    @Bean
    public GameRunner gameRunner(GamingConsole game){
        return new GameRunner(game);
    }
}
