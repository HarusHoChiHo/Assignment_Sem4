package springbootlearning.gamerunner;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import springbootlearning.game.GameRunner;
import springbootlearning.game.MarioGame;
import springbootlearning.game.PacmanGame;
import springbootlearning.game.SuperContraGame;

public class App02GamingBasic {

    public static void main(String[] args) {

        try (var context = new AnnotationConfigApplicationContext(HelloWorldConfiguration.class)) {
            System.out.println(context.getBean("name"));
            System.out.println(context.getBean("age"));
            System.out.println(context.getBean("person"));
            System.out.println(context.getBean("person2"));
            System.out.println(context.getBean("person3"));
            System.out.println(context.getBean("address2"));
            System.out.println(context.getBean(Address.class));
        }
    }
}
