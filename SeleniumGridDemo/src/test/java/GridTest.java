
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.parallel.Execution;
import org.junit.jupiter.api.parallel.ExecutionMode;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.remote.RemoteWebDriver;
import org.openqa.selenium.safari.SafariOptions;

import java.net.URI;
import java.net.URL;
import java.util.List;


public class GridTest {

    private static WebDriver chrome = null;
    private static WebDriver safari = null;
    public String hubURL = "http://192.168.2.61:4444";

    @Test
    @Execution(ExecutionMode.CONCURRENT)
    void searchProgramWithChrome() {

        try {
            ChromeOptions options = new ChromeOptions();
            options.addArguments("start-maximized");
            chrome = new RemoteWebDriver(URL.of(URI.create(hubURL), null), options);

            chrome.get("https://www.centennialcollege.ca/");

//            new WebDriverWait(driver, Duration.ofSeconds(5)).until(d -> (long) d.findElements(By.id("searchTextBox"))
//                                                                                .size() > 0);
            Thread.sleep(5000);
            WebElement search_box = chrome.findElement(By.id("searchTextBox"));

            search_box.sendKeys("3408");

            search_box.submit();

            Thread.sleep(5000);

            WebElement targeted = chrome.findElement(By.linkText("Software Engineering Technician - Centennial College"));

            targeted.click();

            Thread.sleep(5000);

            String result =  chrome.findElement(By.xpath("//span[contains(text(), '3408')]")).getText();

            Assertions.assertEquals("3408", result);

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Test
    @Execution(ExecutionMode.CONCURRENT)
    void searchProgramWithSafari() {
        WebDriver driver = null;
        try {
            SafariOptions options = new SafariOptions();

            safari = new RemoteWebDriver(URL.of(URI.create(hubURL), null), options);

            safari.manage().window().maximize();

            Thread.sleep(2000);

            safari.get("https://www.centennialcollege.ca/");

//            new WebDriverWait(driver, Duration.ofSeconds(5)).until(d -> (long) d.findElements(By.id("searchTextBox"))
//                                                                                .size() > 0);
            Thread.sleep(5000);
            WebElement search_box = safari.findElement(By.id("searchTextBox"));
            search_box.click();
            search_box.sendKeys("3408");

            search_box.submit();

            Thread.sleep(5000);

            List<WebElement> links = safari.findElements(By.xpath("//a[contains(text(), 'Software Engineering Technician - Centennial College')]"));

            WebElement targeted = links.getFirst();

            targeted.click();

            Thread.sleep(5000);

            String result =  safari.findElement(By.xpath("//span[contains(text(), '3408')]")).getText();

            Assertions.assertEquals("3408", result);

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @AfterAll
    static void afterAll() {
        if (chrome != null){
            chrome.quit();
        }

        if (safari != null){
            safari.quit();
        }
    }
}
