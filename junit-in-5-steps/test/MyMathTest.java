import junit.MyMath;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class MyMathTest {

        @Test
        void calculateSum_ThreeMemberArray(){
                MyMath myMath = new MyMath();
                int result = myMath.calculateSum(new int[]{1,2,3});
                System.out.println(result);
                assertEquals(6, result);

        }

        @Test
        void calculateSum_ZeroLengthArray(){
                MyMath myMath = new MyMath();
                int result = myMath.calculateSum(new int[]{});
                System.out.println(result);
                assertEquals(0, result);

        }
}
