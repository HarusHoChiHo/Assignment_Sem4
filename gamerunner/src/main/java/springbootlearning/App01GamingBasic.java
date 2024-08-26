package springbootlearning;

import springbootlearning.game.GameRunner;
import springbootlearning.game.MarioGame;
import springbootlearning.game.PacmanGame;
import springbootlearning.game.SuperContraGame;

public class App01GamingBasic {

    public static void main(String[] args) {
        var marioGame = new MarioGame();
        var superContraGame = new SuperContraGame();
        var pcGame = new PacmanGame();
        var gameRunner = new GameRunner(superContraGame);
        gameRunner.run();

    }
}
