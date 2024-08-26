package springbootlearning;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import springbootlearning.game.*;

public class App03SpringBeans {

    public static void main(String[] args) {

        try (var context = new AnnotationConfigApplicationContext(GamingConfiguration.class)) {

            context.getBean(GamingConsole.class)
                   .up();

            context.getBean(GameRunner.class).run();
        }

    }
}
