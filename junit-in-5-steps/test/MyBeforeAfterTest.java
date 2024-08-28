import org.junit.jupiter.api.*;

public class MyBeforeAfterTest {

    @BeforeAll
    static void beforeAll() {
        System.out.println("Before all test");
    }

    @BeforeEach
    void beforeEach() {
        System.out.println("Before each test");
    }

    @Test
    void test1() {
        System.out.println("Test 1");
    }

    @Test
    void test2() {
        System.out.println("Test 2");
    }

    @Test
    void test3() {
        System.out.println("Test 3");
    }

    @AfterEach
    void afterEach() {
        System.out.println("After each test");
    }

    @AfterAll
    static void afterAll() {
        System.out.println("After all test");
    }
}
