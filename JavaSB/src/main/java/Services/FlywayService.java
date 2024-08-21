package Services;

import org.flywaydb.core.Flyway;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

//@Service
//public class FlywayService {
//
//    private final Flyway flyway;
//
//    @Autowired
//    public FlywayService(Flyway flyway) {
//        this.flyway = flyway;
//    }
//
//    public void migrateDatabase() {
//        flyway.migrate();
//    }
//
//    public void cleanDatabase() {
//        flyway.clean();
//    }
//}