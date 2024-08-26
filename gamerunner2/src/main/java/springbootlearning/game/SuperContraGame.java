package springbootlearning.game;

import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;

@Component
@Qualifier("SuperContraGameQualifier")
public class SuperContraGame implements GamingConsole {

    public void up(){
        System.out.println("sc: up");
    }

    public void down(){
        System.out.println("sc: Sit down");
    }

    public void left(){
        System.out.println("sc: Go back");
    }

    public void right(){
        System.out.println("sc: Accelerate");
    }
}
