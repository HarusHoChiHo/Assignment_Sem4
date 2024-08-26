package springbootlearning.h1;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import springbootlearning.game.GameRunner;

import java.util.Arrays;


@Configuration
@ComponentScan
public class XmlConfigurationContextLauncherApplication {

    public static void main(String[] args) {

        try (var context = new ClassPathXmlApplicationContext("contextConfiguration.xml")) {

            Arrays.stream(context.getBeanDefinitionNames()).forEach(System.out::println);

            System.out.println(context.getBean("game"));
            System.out.println(context.getBean("gameRunner"));

            context.getBean(GameRunner.class).run();
        }

    }
}
