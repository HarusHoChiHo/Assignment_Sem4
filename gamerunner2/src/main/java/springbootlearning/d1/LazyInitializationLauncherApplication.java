package springbootlearning.d1;

import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Lazy;
import org.springframework.stereotype.Component;

import java.util.Arrays;

@Component
class A {

}

@Component
@Lazy
class B {

    private A classA;

    public B(A classA) {
        System.out.println("Initialized");
        this.classA = classA;
    }
}

@Configuration
@ComponentScan
public class LazyInitializationLauncherApplication {

    public static void main(String[] args) {

        try (var context = new AnnotationConfigApplicationContext(LazyInitializationLauncherApplication.class)) {

            //Arrays.stream(context.getBeanDefinitionNames()).forEach(System.out::println);

            context.getBean(B.class);
        }

    }
}
