FROM amazoncorretto:17-alpine-jdk

RUN apk add --no-cache curl

WORKDIR /app

COPY pom.xml .

COPY src ./src

COPY .mvn .mvn
COPY mvnw .

RUN chmod +x mvnw

RUN ./mvnw package -DskipTests

EXPOSE 8081

ENTRYPOINT ["java", "-jar", "target/JavaSbProduct-0.0.1-SNAPSHOT.jar"]